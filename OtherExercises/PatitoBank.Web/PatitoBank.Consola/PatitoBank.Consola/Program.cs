using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


namespace PatitoBank.Consola
{
    public class Program
    {
        static void Main(string[] args)
        {
            crearCuenta();
        }
        private static async Task<Cuenta> crearCuenta(Cuenta cuenta)
        {
            string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(cuenta);
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.PostAsync("https://localhost:7294", new StringContent(jsonContent, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            string respondeBody = await response.Content.ReadAsStringAsync();

            Cuenta cuenta = Newtonsoft.Json.JsonConvert.DeserializeObject<Cuenta>(respondeBody);

        }
    }
   
}
