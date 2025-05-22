using BarberApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberApp.Services
{
    public class CorteService
    {
        private readonly HttpClient _httpClient;

        public CorteService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:8080/");
        }

        public async Task<bool> RegistrarCorteAsync(CorteModel corte)
        {
            var json = JsonConvert.SerializeObject(corte);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/barberos/cortes", content);
            return response.IsSuccessStatusCode;
        }
    }
}
