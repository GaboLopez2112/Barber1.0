using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
//namespace BarberApp.Services;

public class BarberService
{
    private readonly HttpClient _httpClient;

    public BarberService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("http://localhost:8080/");
    }

    // Método para obtener los cortes e ingresos del día
    public async Task<ResumenDia> ObtenerResumenDiaAsync(long idBarbero)
    {
        var response = await _httpClient.GetStringAsync($"api/barberos/barberos/{idBarbero}/resumen");

        // Aquí deserializas la respuesta JSON a un objeto
        return JsonConvert.DeserializeObject<ResumenDia>(response);
    }
}

public class ResumenDia
{
    public int Cortes { get; set; }
    public decimal Ingresos { get; set; }
}