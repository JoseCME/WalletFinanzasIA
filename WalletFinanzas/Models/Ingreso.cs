using System;

namespace WalletFinanzas.Models
{
    public class Ingreso
    {
        public int IdIngreso { get; set; }
        public string Descripción { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCategoría { get; set; }
        public string Origen { get; set; } 
        public string DatosOrigen { get; set; }
    }
}