using System.Collections.Generic;
using WalletFinanzas.Data;
using WalletFinanzas.Models;

namespace WalletFinanzas.Services
{
    public class ServicioFinanzas
    {
        private readonly ContextoBaseDatos _db;

        public ServicioFinanzas()
        {
            _db = new ContextoBaseDatos();
        }

        public Dictionary<string, decimal> ObtenerGastosSemanales()
        {
            return _db.ObtenerGastosAgrupadosPorSemana();
        }

        public void AgregarIngreso(Ingreso ingreso)
        {
            _db.AgregarIngreso(ingreso);
        }

        public void AgregarGasto(Gasto gasto)
        {
            _db.AgregarGasto(gasto);
        }

        public void AgregarCotización(Cotización cotización)
        {
            _db.AgregarCotización(cotización);
        }

        public List<Ingreso> ObtenerIngresos()
        {
            return _db.ObtenerIngresos();
        }

        public List<Gasto> ObtenerGastos()
        {
            return _db.ObtenerGastos();
        }

        public decimal ObtenerBalance()
        {
            return _db.CalcularBalance();
        }

        public Dictionary<string, decimal> ObtenerEstadísticasIngresos()
        {
            return _db.ObtenerEstadísticasIngresos();
        }

        public Dictionary<string, decimal> ObtenerEstadísticasGastos()
        {
            return _db.ObtenerEstadísticasGastos();
        }
    }
}