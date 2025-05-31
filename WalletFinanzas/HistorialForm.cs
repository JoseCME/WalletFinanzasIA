using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using WalletFinanzas.Services;

namespace WalletFinanzas
{
    public partial class HistorialForm : Form
    {
        private readonly ServicioFinanzas _servicioFinanzas;

        public HistorialForm()
        {
            InitializeComponent();
            _servicioFinanzas = new ServicioFinanzas();
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Tipo", typeof(string));
            dt.Columns.Add("Descripción", typeof(string));
            dt.Columns.Add("Monto", typeof(decimal));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Categoría", typeof(string));

            var ingresos = _servicioFinanzas.ObtenerIngresos();
            foreach (var ingreso in ingresos)
            {
                dt.Rows.Add("Ingreso", ingreso.Descripción, ingreso.Monto, ingreso.Fecha, ingreso.IdCategoría);
            }

            var gastos = _servicioFinanzas.ObtenerGastos();
            foreach (var gasto in gastos)
            {
                dt.Rows.Add("Gasto", gasto.Descripción, gasto.Monto, gasto.Fecha, gasto.IdCategoría);
            }

            dgvHistorial.DataSource = dt;
        }

        private void btnExportarCSV_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "Archivos CSV|*.csv", FileName = "HistorialFinanzas.csv" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(dialog.FileName))
                    {
                        writer.WriteLine("Tipo,Descripción,Monto,Fecha,Categoría");
                        foreach (DataRow row in ((DataTable)dgvHistorial.DataSource).Rows)
                        {
                            string tipo = row["Tipo"].ToString().Replace(",", ";");
                            string descripción = row["Descripción"].ToString().Replace(",", ";");
                            string monto = row["Monto"].ToString();
                            string fecha = row["Fecha"].ToString();
                            string categoría = row["Categoría"].ToString().Replace(",", ";");
                            writer.WriteLine($"{tipo},{descripción},{monto},{fecha},{categoría}");
                        }
                    }
                    MessageBox.Show("Historial exportado a CSV.");
                }
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}