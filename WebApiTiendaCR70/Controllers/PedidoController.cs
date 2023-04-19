using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml.Linq;
using WebApiTiendaCR70.Utilidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiTiendaCR70.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private const string url = "https://run.mocky.io/v3/19217075-6d4e-4818-98bc-416d1feb7b84";

        // GET: api/<PedidoController>
        [HttpGet]
        public async Task<ActionResult<string>> PedidoJson()
        {
            try
            {
                string contenido = string.Empty;
                Util util = new Util();
                var cliente = new HttpClient();
                var response = await cliente.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var rstaServicio = await response.Content.ReadAsStringAsync();
                    contenido = util.CrearRespuestaJson(util.ObtenerValorEtiqueta(rstaServicio, "Codigo"), util.ObtenerValorEtiqueta(rstaServicio, "Mensaje"));
                }

                return contenido;

            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }


        // GET: api/<PedidoController>
        [HttpGet("PedidoXML")]
        public async Task<ActionResult<string>> PedidoXML()
        {
            try
            {
                string contenido = string.Empty;
                Util util = new Util();
                var cliente = new HttpClient();
                var response = await cliente.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    contenido = await response.Content.ReadAsStringAsync();

                }

                return contenido;

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
