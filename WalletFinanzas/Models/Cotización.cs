using System;

namespace WalletFinanzas.Models
{
    public class Cotización
    {
        public int IdCotización { get; set; }
        public string NombreProducto { get; set; }
        public decimal Costo { get; set; }
        public int Cuotas { get; set; }
        public decimal PagoMensual { get; set; }
        public string Recomendación { get; set; }
        public DateTime Fecha { get; set; }
        public string Origen { get; set; } 
        public string DatosOrigen { get; set; }
        public int IdCategoría { get; set; }
    }
}