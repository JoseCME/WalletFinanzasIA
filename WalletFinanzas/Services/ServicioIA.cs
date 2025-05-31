using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WalletFinanzas.Data;
using WalletFinanzas.Models;

namespace WalletFinanzas.Services
{
    public class ServicioIA
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string nvidiaInvokeUrl = "https://integrate.api.nvidia.com/v1/chat/completions";
        private readonly string deepgramUrl = "https://api.deepgram.com/v1/listen?model=nova-2&language=es";
        private readonly string nvidiaApiKey = "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";
        private readonly string deepgramApiKey = "cf4a369e002e22b27319e9d5087ac8054da123c0";
        private readonly bool stream = true;
        private readonly ContextoBaseDatos _db;
        private readonly string connectionString = "Server=DESKTOP-OQRPO5C\\SQLEXPRESS01;Database=WalletFinanzasVV;Trusted_Connection=True;";

        public ServicioIA()
        {
            _db = new ContextoBaseDatos();
            ConfigurarHttpClient();
        }

        private void ConfigurarHttpClient()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", nvidiaApiKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(stream ? "text/event-stream" : "application/json"));
        }

        public async Task<(string Descripción, decimal Monto, int IdCategoría)> ProcesarImagenGasto(string imagePath)
        {
            string imageBase64 = ConvertImageToBase64(imagePath);
            if (imageBase64.Length > 180000)
            {
                throw new Exception("La imagen es demasiado grande.");
            }

            var payload = new
            {
                model = "meta/llama-4-maverick-17b-128e-instruct",
                messages = new[]
                {
                    new
                    {
                        role = "user",
                        content = $"Analiza la imagen y extrae el nombre específico del producto o servicio (ej. 'Jean Paul Gutier', 'Netflix'), su monto y una categoría adecuada (ej. 'Ropa', 'Suscripciones'). El nombre debe ser preciso, no genérico. El monto suele estar precedido por 'Q' o '$'. Si está en dólares ('$'), conviértelo a quetzales (1 USD = 7.8 Q). Devuelve solo: Descripción: [texto], Monto: [número] Q, Categoría: [texto]. <img src=\"data:image/png;base64,{imageBase64}\" />"
                    }
                },
                max_tokens = 512,
                temperature = 1.6,
                top_p = 1.00,
                stream = stream
            };

            var jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            string fullResponse = await ProcesarRespuestaNvidia(content);
            var (descripción, monto, categoría) = ExtraerDatosGasto(fullResponse);
            int idCategoría = ObtenerOCrearCategoría(string.IsNullOrWhiteSpace(categoría) ? "Gasto general" : categoría, "Gasto");

            return (descripción, monto, idCategoría);
        }

        public async Task<(string Descripción, decimal Monto, int IdCategoría)> ProcesarAudioGasto(byte[] audioBytes)
        {
            try
            {
                string transcript = await TranscribeAudioAsync(audioBytes);
                if (string.IsNullOrWhiteSpace(transcript))
                {
                    throw new Exception("La transcripción del audio está vacía.");
                }

                var payload = new
                {
                    model = "meta/llama-4-maverick-17b-128e-instruct",
                    messages = new[]
                    {
                        new
                        {
                            role = "user",
                            content = $"Extrae del siguiente texto (\"{transcript}\") el nombre específico del servicio o lugar donde se gastó (ej. Netflix, YouTube, Amazon Prime) y el monto numérico (si está en letras, conviértelo a número). Si no se menciona un servicio claro, usa el nombre más específico posible. También asigna una categoría adecuada (ej. 'Suscripciones', 'Compras'). Devuelve únicamente: Descripción: [texto], Monto: [número], Categoría: [texto]"
                        }
                    },
                    max_tokens = 512,
                    temperature = 1.6,
                    top_p = 1.00,
                    stream = stream
                };

                var jsonPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                string fullResponse = await ProcesarRespuestaNvidia(content);
                var (descripción, monto, categoría) = ExtraerDatosGasto(fullResponse);
                int idCategoría = ObtenerOCrearCategoría(string.IsNullOrWhiteSpace(categoría) ? "Gasto general" : categoría, "Gasto");

                return (descripción, monto, idCategoría);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al procesar el audio: {ex.Message}");
            }
        }

        public async Task<(string NombreProducto, decimal Costo)> ProcesarImagenCotización(string imagePath)
        {
            string imageBase64 = ConvertImageToBase64(imagePath);
            if (imageBase64.Length > 180000)
            {
                throw new Exception("La imagen es demasiado grande.");
            }

            var payload = new
            {
                model = "meta/llama-4-maverick-17b-128e-instruct",
                messages = new[]
            {
            new
            {
                role = "user",
                content = $"Analiza la imagen y extrae únicamente el nombre específico del producto y su precio de venta. El nombre debe ser preciso, no genérico. El precio suele estar precedido por 'Q' o '$'. Si está en dólares ('$'), conviértelo a quetzales (1 USD = 7.8 Q). Devuelve solo: Nombre del Producto: [texto], Precio: [número]. <img src=\"data:image/png;base64,{imageBase64}\" />"
            }
        },
                max_tokens = 512,
                temperature = 1.6,
                top_p = 1.00,
                stream = stream
            };

            var jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            string fullResponse = await ProcesarRespuestaNvidia(content);
            var (nombre, costo) = ExtraerDatosCotizaciónSimple(fullResponse);

            return (nombre, costo);
        }

        private (string NombreProducto, decimal Costo) ExtraerDatosCotizaciónSimple(string response)
        {
            string nombre = "";
            decimal costo = 0;

            Match nombreMatch = Regex.Match(response, @"Nombre del Producto:\s*([^\n]+?)(?:\s*,\s*Precio:|\s*$)");
            if (nombreMatch.Success)
            {
                nombre = nombreMatch.Groups[1].Value.Trim();
            }

            Match costoMatch = Regex.Match(response, @"Precio:\s*(\d+\.?\d*)\s*(?:Q|quetzales)?");
            if (costoMatch.Success && decimal.TryParse(costoMatch.Groups[1].Value, out decimal parsedCosto))
            {
                costo = parsedCosto;
            }

            return (nombre, costo);
        }

        public async Task<string> GenerarRecomendaciónFinanciera(decimal ingresoTotal, decimal gastoTotal)
        {
            var estadísticasGastos = _db.ObtenerEstadísticasGastos();
            string resumenGastos = string.Join("; ", estadísticasGastos.Select(kv => $"{kv.Key}: Q{kv.Value:F2}"));

            var categoríasEsenciales = new List<string> { "Luz", "Agua", "Alimentos", "Salud", "Vivienda" };
            var gastosNoEsenciales = estadísticasGastos
                .Where(kv => !categoríasEsenciales.Contains(kv.Key, StringComparer.OrdinalIgnoreCase))
                .OrderByDescending(kv => kv.Value)
                .ToList();

            string resumenNoEsenciales = gastosNoEsenciales.Any()
                ? string.Join("; ", gastosNoEsenciales.Select(kv => $"{kv.Key}: Q{kv.Value:F2}"))
                : "Ningún gasto no esencial";

            var payload = new
            {
                model = "meta/llama-4-maverick-17b-128e-instruct",
                messages = new[]
                {
            new
            {
                role = "user",
                content = $"Con un ingreso total de Q{ingresoTotal:F2} y gastos totales de Q{gastoTotal:F2}, donde los gastos por categoría son: {resumenGastos}, y los gastos no esenciales son: {resumenNoEsenciales}, genera una recomendación financiera breve. Sugiere moderar el gasto en categorías no esenciales con mayor gasto. Devuelve solo: Consejo: [texto]. Máximo 350 caracteres."
            }
        },
                max_tokens = 512,
                temperature = 1.00,
                top_p = 1.00,
                stream = stream
            };

            var jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            string fullResponse = await ProcesarRespuestaNvidia(content);
            Match match = Regex.Match(fullResponse, @"Consejo:\s*([^$]+)");
            return match.Success ? match.Groups[1].Value.Trim() : "No se pudo generar la recomendación.";
        }

        public int ObtenerOCrearCategoría(string nombreCategoria, string tipoCategoria)
        {
            try
            {
                using (var conn = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    conn.Open();

                    string queryBuscar = "SELECT IdCategoría FROM Categorías WHERE LOWER(TRIM(Nombre)) = LOWER(TRIM(@Nombre)) AND Tipo = @Tipo";
                    using (var cmdBuscar = new System.Data.SqlClient.SqlCommand(queryBuscar, conn))
                    {
                        cmdBuscar.Parameters.AddWithValue("@Nombre", nombreCategoria.Trim());
                        cmdBuscar.Parameters.AddWithValue("@Tipo", tipoCategoria);

                        object resultado = cmdBuscar.ExecuteScalar();
                        if (resultado != null && int.TryParse(resultado.ToString(), out int idExistente))
                        {
                            return idExistente;
                        }
                    }

                    string queryInsertar = "INSERT INTO Categorías (Nombre, Tipo) OUTPUT INSERTED.IdCategoría VALUES (@Nombre, @Tipo)";
                    using (var cmdInsertar = new System.Data.SqlClient.SqlCommand(queryInsertar, conn))
                    {
                        cmdInsertar.Parameters.AddWithValue("@Nombre", nombreCategoria.Trim());
                        cmdInsertar.Parameters.AddWithValue("@Tipo", tipoCategoria);

                        object resultadoInsertar = cmdInsertar.ExecuteScalar();
                        if (resultadoInsertar != null && int.TryParse(resultadoInsertar.ToString(), out int nuevoId))
                        {
                            return nuevoId;
                        }
                    }
                }

                return CrearCategoríaPorDefecto();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener/crear categoría: {ex.Message}");
                return CrearCategoríaPorDefecto();
            }
        }

        private int CrearCategoríaPorDefecto()
        {
            try
            {
                using (var conn = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    conn.Open();

                    string queryBuscarDefault = "SELECT IdCategoría FROM Categorías WHERE Nombre = 'Gasto General' AND Tipo = 'Gasto'";
                    using (var cmd = new System.Data.SqlClient.SqlCommand(queryBuscarDefault, conn))
                    {
                        object resultado = cmd.ExecuteScalar();
                        if (resultado != null && int.TryParse(resultado.ToString(), out int idDefault))
                        {
                            return idDefault;
                        }
                    }

                    string queryCrearDefault = "INSERT INTO Categorías (Nombre, Tipo) OUTPUT INSERTED.IdCategoría VALUES ('Gasto General', 'Gasto')";
                    using (var cmd = new System.Data.SqlClient.SqlCommand(queryCrearDefault, conn))
                    {
                        object resultado = cmd.ExecuteScalar();
                        if (resultado != null && int.TryParse(resultado.ToString(), out int nuevoId))
                        {
                            return nuevoId;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear categoría por defecto: {ex.Message}");
            }

            return 1;
        }

        public int AgregarCategoría(Categoría categoría)
        {
            return ObtenerOCrearCategoría(categoría.Nombre, categoría.Tipo);
        }

        public string ObtenerNombreCategoría(int idCategoría)
        {
            try
            {
                using (var conn = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Nombre FROM Categorías WHERE IdCategoría = @IdCategoría";
                    using (var cmd = new System.Data.SqlClient.SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdCategoría", idCategoría);
                        object result = cmd.ExecuteScalar();
                        return result?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener nombre de categoría: {ex.Message}");
                return null;
            }
        }

        private async Task<string> ProcesarRespuestaNvidia(StringContent content)
        {
            try
            {
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, nvidiaInvokeUrl))
                {
                    requestMessage.Headers.Add("Authorization", $"Bearer {nvidiaApiKey}");
                    requestMessage.Content = content;

                    var response = await client.SendAsync(requestMessage);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception($"Error en la API de NVIDIA: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                    }

                    string fullResponse = "";
                    using (var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync()))
                    {
                        string line;
                        while ((line = await streamReader.ReadLineAsync()) != null)
                        {
                            if (line.StartsWith("data:"))
                            {
                                string jsonData = line.Substring("data:".Length).Trim();
                                if (!string.IsNullOrEmpty(jsonData) && jsonData != "[DONE]")
                                {
                                    try
                                    {
                                        JObject jsonObject = JObject.Parse(jsonData);
                                        JToken deltaContent = jsonObject?["choices"]?[0]?["delta"]?["content"];
                                        if (deltaContent != null)
                                        {
                                            fullResponse += deltaContent.ToString();
                                        }
                                    }
                                    catch (JsonReaderException) { }
                                }
                                else if (jsonData == "[DONE]")
                                {
                                    break;
                                }
                            }
                        }
                    }
                    return fullResponse;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al procesar la respuesta de NVIDIA: {ex.Message}");
            }
        }

        public async Task<string> GenerarRecomendaciónCotización(decimal ingresoTotal, decimal gastoTotal, string nombreProducto, decimal costoProducto, int cuotas, string categoría)
        {
            var estadísticasGastos = _db.ObtenerEstadísticasGastos();
            string resumenGastos = string.Join("; ", estadísticasGastos.Select(kv => $"{kv.Key}: Q{kv.Value:F2}"));

            var categoríasEsenciales = new List<string> { "Luz", "Agua", "Alimentos", "Salud", "Vivienda" };
            bool esEsencial = categoríasEsenciales.Contains(categoría, StringComparer.OrdinalIgnoreCase);

            decimal pagoMensual = costoProducto / cuotas;
            decimal balance = ingresoTotal - gastoTotal;
            decimal porcentajeGastoTotal = (gastoTotal + costoProducto) / ingresoTotal * 100;
            var gastosNoEsenciales = estadísticasGastos
                .Where(kv => !categoríasEsenciales.Contains(kv.Key, StringComparer.OrdinalIgnoreCase))
                .Sum(kv => kv.Value);
            decimal porcentajeNoEsenciales = ingresoTotal > 0 ? (gastosNoEsenciales / ingresoTotal * 100) : 0;

            var payload = new
            {
                model = "meta/llama-4-maverick-17b-128e-instruct",
                messages = new[]
                {
                    new
                    {
                        role = "user",
                        content = $"Actúa como un asesor financiero personal. Tu tarea es evaluar la viabilidad de comprar el producto '{nombreProducto}' y generar una recomendación clara y justificada. **Datos para el Análisis:** * **Producto:** '{nombreProducto}' * **Categoría:** '{categoría}' * **Costo Total:** Q{costoProducto:F2} * **Modalidad de Pago:** {cuotas} cuotas de Q{pagoMensual:F2} cada una. * **Finanzas del Usuario:** * Ingreso Total Mensual: Q{ingresoTotal:F2} * Gasto Total Mensual (actual, sin nueva compra): Q{gastoTotal:F2} * Balance Mensual Actual (Ingreso Total - Gasto Total): Q{balance:F2} * Porcentaje de Gastos No Esenciales sobre el Ingreso: {porcentajeNoEsenciales:F2}% * Resumen de Gastos (para contexto, si es necesario): {resumenGastos} **Lógica de Decisión y Justificación:** 1. **Evalúa la Esencialidad:** * Si la '{categoría}' (ej. 'Salud Urgente', 'Herramienta de Trabajo Indispensable') se considera esencial para el bienestar o generación de ingresos del usuario, prioriza su viabilidad si el `pagoMensual` es manejable. 2. **Evalúa la Asequibilidad del Pago Mensual:** * Calcula el impacto del `pagoMensual` en el `balance` mensual actual. Un nuevo balance de `Q{balance:F2} - Q{pagoMensual:F2}` debe ser saludable. * Considera si el `pagoMensual` es una porción razonable del `ingresoTotal` o del `balance` actual. 3. **Considera los Gastos No Esenciales:** * Si `porcentajeNoEsenciales` es >= 30%, la compra es generalmente riesgosa a menos que el producto sea absolutamente esencial y no haya forma de reducir estos gastos. **Reglas para la Recomendación:** * **VIABLE:** * **Si es Esencial:** Recomienda la compra si el `pagoMensual` se puede integrar al presupuesto sin causar un déficit o estrés financiero significativo. Justifica mencionando la importancia de la categoría, cómo el `balance` actual (Q{balance:F2}) puede absorber el `pagoMensual` (Q{pagoMensual:F2}), y el nuevo balance mensual proyectado. * **Si NO es Esencial:** Recomienda la compra SOLO SI el `balance` mensual actual (Q{balance:F2}) cubre holgadamente el `pagoMensual` (Q{pagoMensual:F2}), dejando un remanente positivo considerable, Y el `porcentajeNoEsenciales` es inferior al 30%. Justifica con el impacto del `pagoMensual` en el `balance` y la buena gestión de gastos no esenciales. * **NO VIABLE:** * Si el `pagoMensual` consume una parte demasiado grande del `balance` actual (Q{balance:F2}) o lo vuelve negativo. * Si el `porcentajeNoEsenciales` es >= 30% y el producto no es estrictamente esencial. * Si ambas condiciones anteriores se cumplen. * Justifica explicando por qué no es recomendable, basándote en que el `pagoMensual` (Q{pagoMensual:F2}) afectaría negativamente el `balance` (Q{balance:F2}), o que el alto `porcentajeNoEsenciales` ({porcentajeNoEsenciales:F2}%) sugiere que primero se deben ajustar otros gastos. Menciona el `costoProducto` (Q{costoProducto:F2}) como una carga financiera total a considerar. **Formato de Respuesta Obligatorio:** Devuelve ÚNICAMENTE tu recomendación y justificación en el siguiente formato exacto: Consejo: [Aquí tu texto de recomendación y justificación, usando los datos proporcionados y sin exceder los 3500 caracteres. Sé específico con los números.] **Ejemplo de cómo usar los datos en la justificación:** * Si es viable: \"Consejo: Sí es viable adquirir '{nombreProducto}'. Siendo de la categoría '{categoría}', y considerando tu balance actual de Q{balance:F2}, el pago mensual de Q{pagoMensual:F2} resultaría en un balance estimado de Q[balance - pagoMensual]. Además, tus gastos no esenciales del {porcentajeNoEsenciales:F2}% están bien gestionados.\" * Si no es viable: \"Consejo: No recomiendo comprar '{nombreProducto}' por ahora. Aunque tu balance es de Q{balance:F2}, destinar Q{pagoMensual:F2} mensualmente para este producto de categoría '{categoría}' reduciría significativamente tu capacidad de ahorro/maniobra. Adicionalmente, tu porcentaje de gastos no esenciales es del {porcentajeNoEsenciales:F2}%, lo que sugiere revisar primero esos egresos antes de asumir una deuda de Q{costoProducto:F2}.\" Asegúrate de que tu respuesta sea directa, personalizada con los datos, y siga estrictamente el formato \"Consejo: [texto]\"."
                    }
                },
                max_tokens = 5122,
                temperature = 0.77,
                top_p = 1.00,
                stream = stream
            };

            var jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            string fullResponse = await ProcesarRespuestaNvidia(content);
            Match match = Regex.Match(fullResponse, @"Consejo:\s*([^$]+)");
            return match.Success ? match.Groups[1].Value.Trim() : "No se pudo generar la recomendación.";
        }

        private async Task<string> TranscribeAudioAsync(byte[] audioBytes)
        {
            try
            {
                using (var deepgramClient = new HttpClient())
                {
                    deepgramClient.Timeout = TimeSpan.FromSeconds(30);
                    var deepgramUrlWithParams = "https://api.deepgram.com/v1/listen?language=es&sample_rate=16000&punctuate=true&encoding=linear16";
                    var request = new HttpRequestMessage(HttpMethod.Post, deepgramUrl);
                    request.Headers.Add("Authorization", "Token " + deepgramApiKey);
                    var content = new ByteArrayContent(audioBytes);
                    content.Headers.ContentType = new MediaTypeHeaderValue("audio/wav");
                    request.Content = content;

                    var response = await deepgramClient.SendAsync(request);
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Respuesta completa de Deepgram: " + jsonResponse);
                        File.AppendAllText("error_log.txt", $"{DateTime.Now}: Respuesta de Deepgram: {jsonResponse}\n");
                        throw new Exception($"Error en Deepgram: {response.StatusCode} - {jsonResponse}");
                    }

                    var jsonObject = JObject.Parse(jsonResponse);
                    string transcript = jsonObject["results"]?["channels"]?[0]?["alternatives"]?[0]?["transcript"]?.ToString();

                    if (string.IsNullOrEmpty(transcript))
                    {
                        Console.WriteLine("Respuesta completa de Deepgram: " + jsonResponse);
                        File.AppendAllText("error_log.txt", $"{DateTime.Now}: Respuesta de Deepgram (transcripción vacía): {jsonResponse}\n");
                        throw new Exception("La transcripción está vacía. Respuesta de Deepgram: " + jsonResponse);
                    }

                    Console.WriteLine("Transcripción: " + transcript);
                    return transcript;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error completo: " + ex.ToString());
                File.AppendAllText("error_log.txt", $"{DateTime.Now}: {ex.ToString()}\n");
                throw new Exception($"Error al transcribir el audio: {ex.Message}");
            }
        }
        private (string Descripción, decimal Monto, string Categoría) ExtraerDatosGasto(string response)
        {
            string descripción = "";
            decimal monto = 0;
            string categoría = "Gasto general";

            Match descripciónMatch = Regex.Match(response, @"Descripción:\s*([^\n]+?)(?:\s*,\s*Monto:|\s*$)");
            if (descripciónMatch.Success)
            {
                descripción = descripciónMatch.Groups[1].Value.Trim();
            }

            Match montoMatch = Regex.Match(response, @"Monto:\s*(\d+\.?\d*)\s*(?:Q|quetzales)");
            if (montoMatch.Success && decimal.TryParse(montoMatch.Groups[1].Value, out decimal parsedMonto))
            {
                monto = parsedMonto;
            }

            Match categoríaMatch = Regex.Match(response, @"Categoría:\s*([^\n]+?)(?:\s*$)");
            if (categoríaMatch.Success)
            {
                categoría = categoríaMatch.Groups[1].Value.Trim();
            }

            return (descripción, monto, categoría);
        }

        private (string NombreProducto, decimal Costo, string Categoría, string Recomendación) ExtraerDatosCotización(string response)
        {
            string nombre = "";
            decimal costo = 0;
            string categoría = "Producto general";
            string recomendación = "No disponible";

            Match nombreMatch = Regex.Match(response, @"Nombre del Producto:\s*([^\n]+?)(?:\s*,\s*Precio:|\s*$)");
            if (nombreMatch.Success)
            {
                nombre = nombreMatch.Groups[1].Value.Trim();
            }

            Match costoMatch = Regex.Match(response, @"Precio:\s*(\d+\.?\d*)\s*(?:Q|quetzales)");
            if (costoMatch.Success && decimal.TryParse(costoMatch.Groups[1].Value, out decimal parsedCosto))
            {
                costo = parsedCosto;
            }

            Match categoríaMatch = Regex.Match(response, @"Categoría:\s*([^\n]+?)(?:\s*,\s*Recomendación:|\s*$)");
            if (categoríaMatch.Success)
            {
                categoría = categoríaMatch.Groups[1].Value.Trim();
            }

            Match recomendaciónMatch = Regex.Match(response, @"Recomendación:\s*([^\n]+?)(?:\s*$)");
            if (recomendaciónMatch.Success)
            {
                recomendación = recomendaciónMatch.Groups[1].Value.Trim();
            }

            return (nombre, costo, categoría, recomendación);
        }

        private string ConvertImageToBase64(string imagePath)
        {
            try
            {
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                return Convert.ToBase64String(imageBytes);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al convertir la imagen a Base64: {ex.Message}");
            }
        }
    }
}