using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces;

namespace CodigosPostales.Repositories
{
    public class CodigoPostalRepository: ICodigosPostalesRepository
    {
        readonly string _url;

        public CodigoPostalRepository(IConfiguration configuration)
        {
            _url = configuration.GetSection("CodigosPostalesApiRest").Value;
        }

        public async Task<List<CodigoPostalEntity>> ObtenerCodigosPostales(string codigoPostal)
        {
            List<CodigoPostalEntity> lista;
            HttpResponseMessage httpResponseMessage;
            string urlApiRest;

            urlApiRest = $"{_url}/api/v2/index.php/CodigosPostales/{codigoPostal}";
            using (var httpClient = new HttpClient())
            {
                httpResponseMessage = await httpClient.GetAsync(urlApiRest);
            }
            if(httpResponseMessage.IsSuccessStatusCode)
            {
                string json;

                json =  await httpResponseMessage.Content.ReadAsStringAsync();

                lista = JsonConvert.DeserializeObject<List<CodigoPostalEntity>>(json);
            }
            else
            {
                lista= new List<CodigoPostalEntity>();
            }

            return lista;
        }

    }//end class
}