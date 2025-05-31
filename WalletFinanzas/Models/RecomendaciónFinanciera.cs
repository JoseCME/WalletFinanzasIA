using System;

namespace WalletFinanzas.Models
{
    public class RecomendaciónFinanciera
    {
        public int IdRecomendación { get; set; }
        public DateTime Fecha { get; set; }
        public string Consejo { get; set; }
    }
}