using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WalletFinanzas.Services;

namespace WalletFinanzas
{
    public partial class MainForm : Form
    {
        private readonly ServicioFinanzas _servicioFinanzas;

        public MainForm()
        {
            InitializeComponent();
            _servicioFinanzas = new ServicioFinanzas();

            if (rbGastosPorCategoria != null)
            {
                rbGastosPorCategoria.Checked = true;
            }

            ActualizarBalanceYGráficos();
            ActualizarEstadoBotonCotizar();
        }

        private void Estadistica_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarBalanceYGráficos();
        }

        private void MostrarGastosSemanales()
        {
            chartEstadísticas.Titles.Clear();
            chartEstadísticas.Titles.Add("Gastos Semanales");
            var serieGastosSemanales = new Series("GastosSemanales")
            {
                ChartType = SeriesChartType.Line,
                IsValueShownAsLabel = false,
                BorderWidth = 2,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 6
            };

            var gastosSemanales = _servicioFinanzas.ObtenerGastosSemanales();

            if (!gastosSemanales.Any())
            {
                serieGastosSemanales.Points.AddXY("Sin Datos", 0);
            }
            else
            {
                foreach (var item in gastosSemanales)
                {
                    var point = serieGastosSemanales.Points.AddXY(item.Key, item.Value);
                    serieGastosSemanales.Points[point].ToolTip = $"Semana: {item.Key}\nMonto: Q{item.Value:F2}";
                }
            }
            chartEstadísticas.Series.Add(serieGastosSemanales);

            if (chartEstadísticas.Legends.IndexOf("GastosSemanalesLegend") == -1)
            {
                Legend legend = new Legend("GastosSemanalesLegend") { Docking = Docking.Bottom };
                chartEstadísticas.Legends.Add(legend);
            }
            serieGastosSemanales.Legend = "GastosSemanalesLegend";
            serieGastosSemanales.LegendText = "Gastos Semanales";

            chartEstadísticas.ChartAreas[0].AxisX.LabelStyle.Angle = (gastosSemanales.Count > 7) ? -45 : 0;
            chartEstadísticas.ChartAreas[0].AxisX.Interval = 1;
            chartEstadísticas.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartEstadísticas.ChartAreas[0].AxisY.Title = "Monto (Q)";
        }

        private void MostrarIngresosPorCategoria()
        {
            chartEstadísticas.Titles.Clear();
            chartEstadísticas.Titles.Add("Ingresos por Categoría");
            var serieIngresos = new Series("Ingresos")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };
            var estadísticasIngresos = _servicioFinanzas.ObtenerEstadísticasIngresos();

            if (!estadísticasIngresos.Any())
            {
                serieIngresos.Points.AddXY("Sin Datos", 0);
            }
            else
            {
                foreach (var item in estadísticasIngresos.OrderByDescending(kvp => kvp.Value))
                {
                    serieIngresos.Points.AddXY(item.Key, item.Value);
                }
            }
            chartEstadísticas.Series.Add(serieIngresos);
            if (chartEstadísticas.Legends.IndexOf("IngresosLegend") == -1)
            {
                Legend legend = new Legend("IngresosLegend") { Docking = Docking.Bottom };
                chartEstadísticas.Legends.Add(legend);
            }
            serieIngresos.Legend = "IngresosLegend";
            serieIngresos.LegendText = "Ingresos";
            chartEstadísticas.ChartAreas[0].AxisY.Title = "Monto (Q)";
        }

        private void MostrarGastosVsIngresos()
        {
            chartEstadísticas.Titles.Clear();
            chartEstadísticas.Titles.Add("Comparativa: Gastos Totales vs. Ingresos Totales");

            decimal totalIngresos = _servicioFinanzas.ObtenerIngresos().Sum(i => i.Monto);
            decimal totalGastos = _servicioFinanzas.ObtenerGastos().Sum(g => g.Monto);

            var serieComparativa = new Series("Comparativa")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            DataPoint dpIngresos = new DataPoint();
            dpIngresos.SetValueXY("Ingresos Totales", totalIngresos);
            dpIngresos.LabelFormat = "Q{0:F2}";
            serieComparativa.Points.Add(dpIngresos);

            DataPoint dpGastos = new DataPoint();
            dpGastos.SetValueXY("Gastos Totales", totalGastos);
            dpGastos.LabelFormat = "Q{0:F2}";
            serieComparativa.Points.Add(dpGastos);

            chartEstadísticas.Series.Add(serieComparativa);
            chartEstadísticas.ChartAreas[0].AxisY.Title = "Monto (Q)";
            if (chartEstadísticas.Legends.Any(l => l.Name == "GastosSemanalesLegend" || l.Name == "IngresosLegend"))
            {
            }
        }

        private void ActualizarBalanceYGráficos()
        {
            lblBalance.Text = $"Balance actual: Q{_servicioFinanzas.ObtenerBalance():F2}";

            chartEstadísticas.Series.Clear();
            chartEstadísticas.Titles.Clear();
            chartEstadísticas.Legends.Clear();
            chartEstadísticas.ChartAreas[0].AxisX.LabelStyle.Angle = 0;
            chartEstadísticas.ChartAreas[0].AxisX.Interval = 1;
            chartEstadísticas.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chartEstadísticas.ChartAreas[0].AxisY.Title = "";

            if (rbGastosPorCategoria != null && rbGastosPorCategoria.Checked)
            {
                MostrarGastosSemanales();
            }
            else if (rbIngresosPorCategoria != null && rbIngresosPorCategoria.Checked)
            {
                MostrarIngresosPorCategoria();
            }
            else if (rbGastosVsIngresos != null && rbGastosVsIngresos.Checked)
            {
                MostrarGastosVsIngresos();
            }
            else
            {
                if (rbGastosPorCategoria != null) MostrarGastosSemanales();
            }
        }

        private void ActualizarEstadoBotonCotizar()
        {
            btnCotizarProducto.Enabled = _servicioFinanzas.ObtenerIngresos().Any() && _servicioFinanzas.ObtenerGastos().Any();
        }

        private void btnIngresarDatos_Click(object sender, EventArgs e)
        {
            using (var form = new IngresarDatosForm())
            {
                form.ShowDialog();
                ActualizarBalanceYGráficos();
                ActualizarEstadoBotonCotizar();
            }
        }

        private void btnCotizarProducto_Click(object sender, EventArgs e)
        {
            using (var form = new CotizarProductoForm())
            {
                form.ShowDialog();
            }
        }

        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            using (var form = new HistorialForm())
            {
                form.ShowDialog();
            }
        }

        private void btnRecomendaciones_Click(object sender, EventArgs e)
        {
            using (var form = new RecomendacionesForm())
            {
                form.ShowDialog();
            }
        }
    }
}