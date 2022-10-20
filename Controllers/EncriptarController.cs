using Microsoft.AspNetCore.Mvc;

namespace Prueba.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EncriptarController : Controller
    {
        char[] abecedario = "abcdefghijklmnñopqrstuvwxyzabcdefghijklmnñopqrstuvwxyz".ToCharArray();

        [HttpPost("/encriptar")]
        public dynamic encriptar(int num, string p)
        {
            char[] palabra = p.ToCharArray();
            List<string> palabraEncriptada = new List<string>();

            for(int i = 0; i < palabra.Length; i++)
            {
                int indexLetra = Array.IndexOf(abecedario, palabra[i]);
                string letra = abecedario[indexLetra + num].ToString();
                palabraEncriptada.Add(letra);
            }
            return new
            {
                palabra = string.Join( "", palabra),
                encriptada = string.Join("", palabraEncriptada)

            };
        }

        [HttpPost("/desencriptar")]
        public dynamic desencriptar(int num, string p)
        {
            char[] palabra = p.ToCharArray();
            List<string> palabraDecencriptada = new List<string>();
            Array.Reverse(abecedario, 0, abecedario.Length);

            for (int i = 0; i < palabra.Length; i++)
            {
                int indexLetra = Array.IndexOf(abecedario, palabra[i]);
                string letra = abecedario[indexLetra + num].ToString();
                palabraDecencriptada.Add(letra);
            }
            return new
            {
                palabra = string.Join("", palabra),
                decencriptada = string.Join("", palabraDecencriptada),
            };
        }
    }
}
