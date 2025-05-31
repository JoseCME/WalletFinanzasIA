using System;
using System.Windows.Forms;
using NAudio.Wave;
using System.IO;
using System.Threading.Tasks;
using WalletFinanzas.Models;
using WalletFinanzas.Services;
using System.Linq;

namespace WalletFinanzas
{
    public partial class IngresarDatosForm : Form
    {
        private readonly ServicioFinanzas _servicioFinanzas;
        private readonly ServicioIA _servicioIA;
        private WaveInEvent waveIn;
        private WaveFileWriter waveWriter;
        private MemoryStream audioStream;
        private bool isRecording;

        public IngresarDatosForm()
        {
            InitializeComponent();
            _servicioFinanzas = new ServicioFinanzas();
            _servicioIA = new ServicioIA();
            isRecording = false;
            ActualizarLabels();
        }

        private void ActualizarLabels()
        {
            decimal balance = _servicioFinanzas.ObtenerBalance();
            decimal ingresosTotal = _servicioFinanzas.ObtenerEstadísticasIngresos().Values.Sum();
            decimal gastosTotal = _servicioFinanzas.ObtenerEstadísticasGastos().Values.Sum();
            lblBalance.Text = $"Balance: Q{balance:F2}";
            lblIngresos.Text = $"Ingresos: Q{ingresosTotal:F2}";
            lblGastos.Text = $"Gastos: Q{gastosTotal:F2}";
        }

        private void btnGuardarIngreso_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtMontoIngreso.Text, out decimal monto) || monto <= 0 || string.IsNullOrWhiteSpace(txtDescripciónIngreso.Text))
            {
                MessageBox.Show("Completa la descripción y el monto correctamente.");
                return;
            }

            try
            {
                string categoría = string.IsNullOrWhiteSpace(txtCategoriaIngreso.Text) ? txtDescripciónIngreso.Text : txtCategoriaIngreso.Text;
                int idCategoría = _servicioIA.AgregarCategoría(new Categoría { Nombre = categoría, Tipo = "Ingreso" });

                var ingreso = new Ingreso
                {
                    Descripción = txtDescripciónIngreso.Text,
                    Monto = monto,
                    Fecha = DateTime.Now,
                    IdCategoría = idCategoría,
                    Origen = "Manual",
                    DatosOrigen = null
                };

                _servicioFinanzas.AgregarIngreso(ingreso);
                ActualizarLabels();
                txtDescripciónIngreso.Clear();
                txtMontoIngreso.Clear();
                txtCategoriaIngreso.Clear();
                MessageBox.Show("Ingreso guardado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnAgregarGasto_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtMontoGasto.Text, out decimal monto) || monto <= 0 || string.IsNullOrWhiteSpace(txtDescripciónGasto.Text))
            {
                MessageBox.Show("Completa la descripción y el monto correctamente.");
                return;
            }

            try
            {
                string categoría = string.IsNullOrWhiteSpace(txtCategoriaIngreso.Text) ? txtDescripciónGasto.Text : txtCategoriaIngreso.Text;
                int idCategoría = _servicioIA.AgregarCategoría(new Categoría { Nombre = categoría, Tipo = "Gasto" });

                var gasto = new Gasto
                {
                    Descripción = txtDescripciónGasto.Text,
                    Monto = monto,
                    Fecha = DateTime.Now,
                    IdCategoría = idCategoría,
                    Origen = "Manual",
                    DatosOrigen = null
                };

                _servicioFinanzas.AgregarGasto(gasto);
                ActualizarLabels();
                txtDescripciónGasto.Clear();
                txtMontoGasto.Clear();
                txtCategoriaGasto.Clear();
                MessageBox.Show("Gasto agregado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void btnSubirImagenGasto_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog { Filter = "Imágenes PNG|*.png" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    lblEstadoProcesamiento.Text = "Procesando imagen...";
                    lblEstadoProcesamiento.Visible = true;
                    Application.DoEvents();

                    try
                    {
                        var (descripción, monto, idCategoría) = await _servicioIA.ProcesarImagenGasto(dialog.FileName);
                        if (string.IsNullOrEmpty(descripción) || monto <= 0)
                        {
                            throw new Exception("No se pudo extraer la información de la imagen.");
                        }

                        txtDescripciónGasto.Text = descripción.Length > 100 ? descripción.Substring(0, 97) + "..." : descripción;
                        txtMontoGasto.Text = monto.ToString("F2");
                        txtCategoriaGasto.Text = _servicioIA.ObtenerNombreCategoría(idCategoría) ?? "Gasto general";

                        lblEstadoProcesamiento.Text = "Imagen procesada. Presione 'Agregar' para guardar el gasto.";
                    }
                    catch (Exception ex)
                    {
                        lblEstadoProcesamiento.Text = $"Error: {ex.Message}";
                    }
                    finally
                    {
                        var timer = new Timer { Interval = 3000 };
                        timer.Tick += (s, args) =>
                        {
                            lblEstadoProcesamiento.Visible = false;
                            timer.Stop();
                        };
                        timer.Start();
                    }
                }
            }
        }

        private async void btnGrabarAudioGasto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isRecording)
                {
                    btnGrabarAudioGasto.Text = "Detener grabación";
                    lblEstadoProcesamiento.Text = "Grabando...";
                    lblEstadoProcesamiento.Visible = true;
                    isRecording = true;

                    audioStream = new MemoryStream();
                    waveIn = new WaveInEvent
                    {
                        WaveFormat = new WaveFormat(16000, 16, 1)
                    };
                    waveWriter = new WaveFileWriter(audioStream, waveIn.WaveFormat);

                    waveIn.DataAvailable += (s, args) =>
                    {
                        waveWriter.Write(args.Buffer, 0, args.BytesRecorded);
                    };

                    waveIn.RecordingStopped += async (s, args) =>
                    {
                        waveWriter.Close();
                        byte[] audioBytes = audioStream.ToArray();
                        audioStream.Dispose();

                        lblEstadoProcesamiento.Text = "Procesando audio...";

                        using (var processingForm = new Form
                        {
                            Text = "Procesando",
                            Size = new System.Drawing.Size(200, 100),
                            FormBorderStyle = FormBorderStyle.FixedDialog,
                            StartPosition = FormStartPosition.CenterParent,
                            ControlBox = false
                        })
                        {
                            var label = new Label
                            {
                                Text = "Procesando...",
                                Dock = DockStyle.Fill,
                                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                            };
                            processingForm.Controls.Add(label);
                            processingForm.Show(this);

                            try
                            {
                                var (descripción, monto, idCategoría) = await _servicioIA.ProcesarAudioGasto(audioBytes);
                                if (string.IsNullOrEmpty(descripción) || monto <= 0)
                                {
                                    throw new Exception("No se pudo extraer la información del audio.");
                                }

                                txtDescripciónGasto.Text = descripción.Length > 100 ? descripción.Substring(0, 97) + "..." : descripción;
                                txtMontoGasto.Text = monto.ToString("F2");
                                txtCategoriaGasto.Text = _servicioIA.ObtenerNombreCategoría(idCategoría) ?? "Gasto general";

                                lblEstadoProcesamiento.Text = "Audio procesado. Presione 'Agregar' para guardar el gasto.";
                            }
                            catch (Exception ex)
                            {
                                lblEstadoProcesamiento.Text = $"Error: {ex.Message}";
                            }
                            finally
                            {
                                processingForm.Close();
                                var timer = new Timer { Interval = 3000 };
                                timer.Tick += (s2, args2) =>
                                {
                                    lblEstadoProcesamiento.Visible = false;
                                    timer.Stop();
                                };
                                timer.Start();
                            }
                        }
                    };

                    waveIn.StartRecording();
                }
                else
                {
                    isRecording = false;
                    btnGrabarAudioGasto.Text = "Grabar audio gasto";
                    waveIn.StopRecording();
                    waveIn.Dispose();
                }
            }
            catch (Exception ex)
            {
                lblEstadoProcesamiento.Text = $"Error: {ex.Message}";
                if (isRecording)
                {
                    isRecording = false;
                    btnGrabarAudioGasto.Text = "Grabar audio gasto";
                    waveIn?.StopRecording();
                    waveIn?.Dispose();
                    waveWriter?.Close();
                    audioStream?.Dispose();
                }
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}