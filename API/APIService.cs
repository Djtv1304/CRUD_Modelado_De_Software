using Ejemplo1.Models;
using Newtonsoft.Json;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejemplo1.API
{
    public class APIService : IAPIService
    {

        private static string _baseURL;

        HttpClient httpClient = new HttpClient();

        public APIService()
        {

            _baseURL = "http://apiservicios.ecuasolmovsa.com:3009/";

            httpClient.BaseAddress = new Uri(_baseURL);

        }

        public async Task<List<CentroCostos>> GetCentroCostos()
        {

            // Send a GET request to the API
            HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "api/Varios/CentroCostosSelect");

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of Producto objects
                List<CentroCostos> listaCentroCostos = JsonConvert.DeserializeObject<List<CentroCostos>>(content);

                return listaCentroCostos;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }

        public async Task<CentroCostos> InsertCentroCostos(CentroCostos newCentroCostos)
        {

            // Construir la URL con los parámetros
            string url = $"{_baseURL}api/Varios/CentroCostosInsert" +
                         $"?codigocentrocostos={newCentroCostos.Codigo}" +
                         $"&descripcioncentrocostos={Uri.EscapeDataString(newCentroCostos.NombreCentroCostos)}";

            // Send a POST request to the API with the constructed URL
            HttpResponseMessage response = await httpClient.PostAsync(url, null);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a CentroCostos object
                CentroCostos centroCostosInserted = JsonConvert.DeserializeObject<CentroCostos>(content);

                return centroCostosInserted;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }


        public async Task<CentroCostos> DeleteCentroCostos(CentroCostos CentroCostosToDelete)
        {

            // Construir la URL con los parámetros
            string url = $"{_baseURL}api/Varios/CentroCostosDelete" +
                         $"?codigocentrocostos={CentroCostosToDelete.Codigo}";

            // Send a POST request to the API with the constructed URL
            HttpResponseMessage response = await httpClient.GetAsync(url);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();


                return null;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }

        public async Task UpdateCentroCostos(CentroCostos CentroCostosToUpdate)
        {

            // Construir la URL con los parámetros
            string url = $"{_baseURL}api/Varios/CentroCostosUpdate" +
                         $"?codigocentrocostos={CentroCostosToUpdate.Codigo}" +
                         $"&descripcioncentrocostos={Uri.EscapeDataString(CentroCostosToUpdate.NombreCentroCostos)}";

            // Send a POST request to the API with the constructed URL
            HttpResponseMessage response = await httpClient.GetAsync(url);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();


            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }
    }
}
