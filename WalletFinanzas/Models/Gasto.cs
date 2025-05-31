using System;

namespace WalletFinanzas.Models
{
    public class Gasto
    {
        public int IdGasto { get; set; }
        public string Descripción { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCategoría { get; set; }
        public string Origen { get; set; } 
        public string DatosOrigen { get; set; }
    }
}