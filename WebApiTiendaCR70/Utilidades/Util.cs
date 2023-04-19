using Microsoft.OpenApi.Writers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Linq;
using WebApiTiendaCR70.Modelos;

namespace WebApiTiendaCR70.Utilidades
{
    public class Util
    {

        public string ObtenerValorEtiqueta(string cadena, string etiqueta)
        {
            string valor = string.Empty;

            if (!string.IsNullOrEmpty(cadena))
            {

                var xml = XDocument.Parse(cadena);
                var elemento = xml.Descendants().FirstOrDefault(e => e.Name.LocalName == etiqueta);
                if (elemento != null)
                    valor = elemento.Value;
            }

            return valor;
        }


        public string CrearRespuestaJson(string codigo, string estado)
        {
            RespuestaJson respuesta = new RespuestaJson();  
            respuesta.Estado = estado;
            respuesta.CodigoEnvio = codigo;
            return JsonConvert.SerializeObject(respuesta);
        }

    }


  

}
