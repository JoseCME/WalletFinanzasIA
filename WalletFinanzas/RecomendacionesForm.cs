using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WalletFinanzas.Services;

namespace WalletFinanzas
{
    public partial class RecomendacionesForm : Form
    {
        private readonly ServicioFinanzas _servicioFinanzas;
        private readonly ServicioIA _servicioIA;
        private const string MensajeInicial = "Presione 'Generar Recomendación' para obtener una nueva.";

        public RecomendacionesForm()
        {
            InitializeComponent();
            _servicioFinanzas = new ServicioFinanzas();
            _servicioIA = new ServicioIA();

            if (this.progressBar1 != null)
            {
                this.progressBar1.Visible = false;
            }

            CargarMensajeInicialRecomendaciones();
        }

        private void CargarMensajeInicialRecomendaciones()
        {
            if (this.txtRecomendaciones != null)
            {
                this.txtRecomendaciones.Text = MensajeInicial;
            }
        }

        private async void btnGenerarRecomendación_Click(object sender, EventArgs e)
        {
            if (this.progressBar1 != null)
            {
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 30;
                progressBar1.Visible = true;
            }
            if (this.btnGenerarRecomendación != null)
            {
                btnGenerarRecomendación.Enabled = false;
            }

            try
            {
                decimal ingresoTotal = _servicioFinanzas.ObtenerEstadísticasIngresos().Values.Sum();
                decimal gastoTotal = _servicioFinanzas.ObtenerEstadísticasGastos().Values.Sum();

                string recomendación = await _servicioIA.GenerarRecomendaciónFinanciera(ingresoTotal, gastoTotal);

                if (this.txtRecomendaciones != null)
                {
                    if (txtRecomendaciones.Text == MensajeInicial)
                    {
                        txtRecomendaciones.Text = string.Empty;
                    }

                    txtRecomendaciones.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm}: {recomendación}{Environment.NewLine}{Environment.NewLine}");
                    txtRecomendaciones.ScrollToCaret();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar la recomendación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (this.progressBar1 != null)
                {
                    progressBar1.Visible = false;
                    progressBar1.Style = ProgressBarStyle.Blocks;
                }
                if (this.btnGenerarRecomendación != null)
                {
                    btnGenerarRecomendación.Enabled = true;
                }
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}