using System;
using System.Linq;
using System.Windows.Forms;
using WalletFinanzas.Models;
using WalletFinanzas.Services;

namespace WalletFinanzas
{
    public partial class CotizarProductoForm : Form
    {
        private readonly ServicioFinanzas _servicioFinanzas;
        private readonly ServicioIA _servicioIA;

        // Asumo que tienes un ProgressBar llamado progressBar2 en tu formulario.
        // Ejemplo (normalmente esto está en el archivo Designer.cs):
        // private System.Windows.Forms.ProgressBar progressBar2;

        public CotizarProductoForm()
        {
            InitializeComponent();
            _servicioFinanzas = new ServicioFinanzas();
            _servicioIA = new ServicioIA();

            // Asegúrate de que la ProgressBar no sea visible al inicio
            if (this.progressBar2 != null) // Comprueba si el control existe
            {
                this.progressBar2.Visible = false;
            }
        }

        private async void btnSubirImagen_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog { Filter = "Imágenes PNG|*.png" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    lblEstadoProcesamiento.Text = "Procesando imagen...";
                    lblEstadoProcesamiento.Visible = true;
                    Application.DoEvents(); // Permite que la UI se actualice

                    try
                    {
                        var (nombre, costo) = await _servicioIA.ProcesarImagenCotización(dialog.FileName);

                        if (string.IsNullOrEmpty(nombre) || costo <= 0)
                        {
                            throw new Exception("No se pudo extraer la información de la imagen.");
                        }

                        txtNombreProducto.Text = nombre.Length > 100 ? nombre.Substring(0, 97) + "..." : nombre;
                        txtCostoProducto.Text = costo.ToString("F2");

                        lblEstadoProcesamiento.Text = "Imagen procesada correctamente.";
                    }
                    catch (Exception ex)
                    {
                        lblEstadoProcesamiento.Text = $"Error: {ex.Message}";
                    }
                    finally
                    {
                        // Usar un Timer para ocultar el mensaje después de un tiempo
                        var timer = new System.Windows.Forms.Timer { Interval = 3000 }; // Especificar System.Windows.Forms.Timer
                        timer.Tick += (s, args) =>
                        {
                            lblEstadoProcesamiento.Visible = false;
                            timer.Stop();
                            timer.Dispose(); // Liberar recursos del timer
                        };
                        timer.Start();
                    }
                }
            }
        }

        private async void btnCotizar_Click(object sender, EventArgs e)
        {
            // Validación de campos de entrada
            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text) || txtNombreProducto.Text.Length > 100 ||
                !decimal.TryParse(txtCostoProducto.Text, out decimal costo) || costo <= 0 ||
                !int.TryParse(txtCuotas.Text, out int cuotas) || cuotas <= 0)
            {
                MessageBox.Show("Completa los campos correctamente: Nombre (hasta 100 caracteres), Costo (número positivo) y Cuotas (número entero positivo).", "Datos Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Iniciar ProgressBar
            if (this.progressBar2 != null)
            {
                progressBar2.Style = ProgressBarStyle.Marquee; // Estilo de animación continua
                progressBar2.MarqueeAnimationSpeed = 30; // Velocidad de la animación (milisegundos por frame, menor es más rápido)
                progressBar2.Visible = true;
            }
            btnCotizar.Enabled = false; // Deshabilitar botón para evitar múltiples clics
            btnSubirImagen.Enabled = false; // Opcional: deshabilitar otros controles

            try
            {
                // Simular un poco de trabajo para que la ProgressBar sea visible si la operación es muy rápida
                // await Task.Delay(500); // Puedes quitar esto si tu operación de IA ya toma tiempo

                decimal pagoMensual = costo / cuotas;

                // Agregar categoría y obtener su nombre.
                // Considera si el nombre de la categoría debe ser más genérico o si el nombre del producto es adecuado.
                // Si el nombre del producto es muy largo o variable, podría crear muchas categorías.
                // Una alternativa sería tener categorías predefinidas o una lógica más robusta para asignarlas.
                string nombreCategoriaParaProducto = txtNombreProducto.Text.Length > 50 ? txtNombreProducto.Text.Substring(0, 47) + "..." : txtNombreProducto.Text;
                int idCategoría = _servicioIA.AgregarCategoría(new Categoría { Nombre = nombreCategoriaParaProducto, Tipo = "Gasto" });
                string categoríaNombre = _servicioIA.ObtenerNombreCategoría(idCategoría) ?? "Gasto General Adquisición";


                // Generar recomendación (operación potencialmente larga)
                string recomendacionTexto = await _servicioIA.GenerarRecomendaciónCotización(
                    _servicioFinanzas.ObtenerEstadísticasIngresos().Values.Sum(),
                    _servicioFinanzas.ObtenerEstadísticasGastos().Values.Sum(),
                    txtNombreProducto.Text,
                    costo,
                    cuotas,
                    categoríaNombre);

                var cotización = new Cotización
                {
                    NombreProducto = txtNombreProducto.Text,
                    Costo = costo,
                    Cuotas = cuotas,
                    PagoMensual = pagoMensual,
                    Recomendación = recomendacionTexto,
                    Fecha = DateTime.Now,
                    Origen = "Manual", // O podría ser "Imagen" si se usó la carga de imagen
                    DatosOrigen = null, // Podrías guardar aquí la ruta de la imagen si se usó
                    IdCategoría = idCategoría
                };

                _servicioFinanzas.AgregarCotización(cotización);

                // Mostrar recomendación
                MessageBox.Show(cotización.Recomendación, "Recomendación Financiera", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos después de una cotización exitosa
                txtNombreProducto.Clear();
                txtCostoProducto.Clear();
                txtCuotas.Clear();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show($"Error al procesar la cotización: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Detener y ocultar ProgressBar
                if (this.progressBar2 != null)
                {
                    progressBar2.Visible = false;
                    progressBar2.Style = ProgressBarStyle.Blocks; // Opcional: resetear estilo
                }
                btnCotizar.Enabled = true; // Rehabilitar botón
                btnSubirImagen.Enabled = true; // Opcional: rehabilitar otros controles
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}