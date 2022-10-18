using Microsoft.OpenApi.Any;

namespace Prueba
{
    public class Producto
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int[] listaDePrecios { get; set; }
        public string imagen { get; set; }
        public bool productoParaVenta { get; set; }
        public int porcentajeIva { get; set; }
    }
}
