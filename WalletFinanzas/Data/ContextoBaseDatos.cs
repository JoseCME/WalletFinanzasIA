using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WalletFinanzas.Models;

namespace WalletFinanzas.Data
{
    public class ContextoBaseDatos
    {
        private readonly string connectionString = "Server=DESKTOP-OQRPO5C\\SQLEXPRESS01;Database=WalletFinanzasVV;Trusted_Connection=True;";

        public void AgregarIngreso(Ingreso ingreso)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Ingresos (Descripción, Monto, Fecha, IdCategoría, Origen, DatosOrigen) " +
                              "VALUES (@Descripción, @Monto, @Fecha, @IdCategoría, @Origen, @DatosOrigen)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Descripción", ingreso.Descripción);
                    cmd.Parameters.AddWithValue("@Monto", ingreso.Monto);
                    cmd.Parameters.AddWithValue("@Fecha", ingreso.Fecha);
                    cmd.Parameters.AddWithValue("@IdCategoría", ingreso.IdCategoría);
                    cmd.Parameters.AddWithValue("@Origen", ingreso.Origen);
                    cmd.Parameters.AddWithValue("@DatosOrigen", (object)ingreso.DatosOrigen ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AgregarGasto(Gasto gasto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Gastos (Descripción, Monto, Fecha, IdCategoría, Origen, DatosOrigen) " +
                              "VALUES (@Descripción, @Monto, @Fecha, @IdCategoría, @Origen, @DatosOrigen)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Descripción", gasto.Descripción);
                    cmd.Parameters.AddWithValue("@Monto", gasto.Monto);
                    cmd.Parameters.AddWithValue("@Fecha", gasto.Fecha);
                    cmd.Parameters.AddWithValue("@IdCategoría", gasto.IdCategoría);
                    cmd.Parameters.AddWithValue("@Origen", gasto.Origen);
                    cmd.Parameters.AddWithValue("@DatosOrigen", (object)gasto.DatosOrigen ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AgregarCotización(Cotización cotización)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Cotizaciones (NombreProducto, Costo, Cuotas, PagoMensual, Recomendación, Fecha, Origen, DatosOrigen, IdCategoría) " +
                              "VALUES (@NombreProducto, @Costo, @Cuotas, @PagoMensual, @Recomendación, @Fecha, @Origen, @DatosOrigen, @IdCategoría)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NombreProducto", cotización.NombreProducto);
                    cmd.Parameters.AddWithValue("@Costo", cotización.Costo);
                    cmd.Parameters.AddWithValue("@Cuotas", cotización.Cuotas);
                    cmd.Parameters.AddWithValue("@PagoMensual", cotización.PagoMensual);
                    cmd.Parameters.AddWithValue("@Recomendación", cotización.Recomendación);
                    cmd.Parameters.AddWithValue("@Fecha", cotización.Fecha);
                    cmd.Parameters.AddWithValue("@Origen", cotización.Origen);
                    cmd.Parameters.AddWithValue("@DatosOrigen", (object)cotización.DatosOrigen ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IdCategoría", cotización.IdCategoría);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int AgregarCategoría(Categoría categoría)
        {
            if (string.IsNullOrWhiteSpace(categoría.Nombre) || string.IsNullOrWhiteSpace(categoría.Tipo))
            {
                throw new ArgumentException("El nombre y tipo de la categoría no pueden estar vacíos.");
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        MERGE INTO Categorías AS target
                        USING (SELECT @Nombre AS Nombre, @Tipo AS Tipo) AS source
                        ON target.Nombre = source.Nombre AND target.Tipo = source.Tipo
                        WHEN NOT MATCHED THEN
                            INSERT (Nombre, Tipo)
                            VALUES (source.Nombre, source.Tipo)
                        OUTPUT INSERTED.IdCategoría;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", categoría.Nombre);
                        cmd.Parameters.AddWithValue("@Tipo", categoría.Tipo);
                        object result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            throw new Exception("No se pudo obtener el IdCategoría. La consulta no devolvió un valor.");
                        }
                        return (int)result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar la categoría '{categoría.Nombre}' (Tipo: {categoría.Tipo}): {ex.Message}");
            }
        }

        public List<Ingreso> ObtenerIngresos()
        {
            List<Ingreso> ingresos = new List<Ingreso>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT i.IdIngreso, i.Descripción, i.Monto, i.Fecha, i.IdCategoría, i.Origen, i.DatosOrigen, c.Nombre " +
                              "FROM Ingresos i JOIN Categorías c ON i.IdCategoría = c.IdCategoría";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ingresos.Add(new Ingreso
                        {
                            IdIngreso = reader.GetInt32(0),
                            Descripción = reader.GetString(1),
                            Monto = reader.GetDecimal(2),
                            Fecha = reader.GetDateTime(3),
                            IdCategoría = reader.GetInt32(4),
                            Origen = reader.GetString(5),
                            DatosOrigen = reader.IsDBNull(6) ? null : reader.GetString(6)
                        });
                    }
                }
            }
            return ingresos;
        }

        public List<Gasto> ObtenerGastos()
        {
            List<Gasto> gastos = new List<Gasto>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT g.IdGasto, g.Descripción, g.Monto, g.Fecha, g.IdCategoría, g.Origen, g.DatosOrigen, c.Nombre " +
                              "FROM Gastos g JOIN Categorías c ON g.IdCategoría = c.IdCategoría";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        gastos.Add(new Gasto
                        {
                            IdGasto = reader.GetInt32(0),
                            Descripción = reader.GetString(1),
                            Monto = reader.GetDecimal(2),
                            Fecha = reader.GetDateTime(3),
                            IdCategoría = reader.GetInt32(4),
                            Origen = reader.GetString(5),
                            DatosOrigen = reader.IsDBNull(6) ? null : reader.GetString(6)
                        });
                    }
                }
            }
            return gastos;
        }

        public decimal CalcularBalance()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT (SELECT ISNULL(SUM(Monto), 0) FROM Ingresos) - (SELECT ISNULL(SUM(Monto), 0) FROM Gastos)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    return (decimal)cmd.ExecuteScalar();
                }
            }
        }

        public Dictionary<string, decimal> ObtenerEstadísticasIngresos()
        {
            Dictionary<string, decimal> estadísticas = new Dictionary<string, decimal>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT c.Nombre, ISNULL(SUM(i.Monto), 0) " +
                              "FROM Categorías c LEFT JOIN Ingresos i ON c.IdCategoría = i.IdCategoría " +
                              "WHERE c.Tipo = 'Ingreso' GROUP BY c.Nombre";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        estadísticas[reader.GetString(0)] = reader.GetDecimal(1);
                    }
                }
            }
            return estadísticas;
        }

   
       

            public Dictionary<string, decimal> ObtenerGastosAgrupadosPorSemana()
            {
                var estadisticasSemanales = new Dictionary<string, decimal>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                   
                    string query = @"
                    SELECT 
                        CAST(YEAR(Fecha) AS VARCHAR(4)) + '-W' + RIGHT('0' + CAST(DATEPART(wk, Fecha) AS VARCHAR(2)), 2) AS SemanaAño,
                        SUM(Monto) AS TotalSemanal
                    FROM Gastos
                    GROUP BY YEAR(Fecha), DATEPART(wk, Fecha)
                    ORDER BY SemanaAño";
                    

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            estadisticasSemanales[reader.GetString(0)] = reader.GetDecimal(1);
                        }
                    }
                }
                return estadisticasSemanales;
            }

            public Dictionary<string, decimal> ObtenerEstadísticasGastos()
        {
            Dictionary<string, decimal> estadísticas = new Dictionary<string, decimal>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT c.Nombre, ISNULL(SUM(g.Monto), 0) " +
                              "FROM Categorías c LEFT JOIN Gastos g ON c.IdCategoría = g.IdCategoría " +
                              "WHERE c.Tipo = 'Gasto' GROUP BY c.Nombre";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        estadísticas[reader.GetString(0)] = reader.GetDecimal(1);
                    }
                }
            }
            return estadísticas;
        }
    }
}