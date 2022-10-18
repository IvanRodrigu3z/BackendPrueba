using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using System;
using System.Collections;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;
namespace Prueba.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductosController : Controller
    {
    static ArrayList listProducts = new ArrayList() {
        new Producto
        {
            id = 1,
            codigo = "34SDF23",
            descripcion = "esto es un producto",
            listaDePrecios = new int[]{23,34,454},
            imagen = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ktronix.com%2Fbombillo-inteligente-led-wiz-tipo-vintage-wi-fi-luz-calida-ref-a19%2Fp%2F8718699785055&psig=AOvVaw3HWnyWIRfstCf4yA2o_9nB&ust=1665877426011000&source=images&cd=vfe&ved=0CAkQjRxqFwoTCKjwu5Pz4PoCFQAAAAAdAAAAABAE",
            productoParaVenta = true,
            porcentajeIva = 19
        },
        new Producto
        {
            id = 2,
            codigo = "3dDFV",
            descripcion = "otro producto",
            listaDePrecios = new int[]{23,45,56},
            imagen = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ktronix.com%2Fbombillo-inteligente-led-wiz-tipo-vintage-wi-fi-luz-calida-ref-a19%2Fp%2F8718699785055&psig=AOvVaw3HWnyWIRfstCf4yA2o_9nB&ust=1665877426011000&source=images&cd=vfe&ved=0CAkQjRxqFwoTCKjwu5Pz4PoCFQAAAAAdAAAAABAE",
            productoParaVenta = true,
            porcentajeIva = 19
        }
      };

    string jsonProducts = JsonConvert.SerializeObject(listProducts);

    [HttpPost("/añadir")]
        public dynamic addProduct(Producto producto)
        {
            int id = listProducts.Count + 1;
            Producto productoNuevo = new Producto
            {
                id= id,
                codigo = producto.codigo,
                descripcion = producto.descripcion,
                listaDePrecios = producto.listaDePrecios,
                imagen = producto.imagen,
                productoParaVenta = producto.productoParaVenta,
                porcentajeIva = producto.porcentajeIva
            };
            listProducts.Add(productoNuevo);
            jsonProducts = JsonConvert.SerializeObject(listProducts);

            return new
            {
                message = "Registro exitoso",
                success = true,
                result = producto,
                productos = jsonProducts
            };
        }

        [HttpGet("/productos")]
        public dynamic getProductos()
        {
            return jsonProducts;
        }

        [HttpGet("/producto/{id}")]
        public dynamic getProducto(int id)
        { 
            id -= 1;
            Producto[] listProducts = JsonConvert.DeserializeObject<Producto[]>(jsonProducts);
            return listProducts[id];
        }

    [HttpDelete("/eliminar/{id}")]
        public dynamic removeProduct(int id)
        {
            id -= 1;
            listProducts = JsonConvert.DeserializeObject<ArrayList>(jsonProducts);
            listProducts.RemoveAt(id);
            jsonProducts = JsonConvert.SerializeObject(listProducts);
            return new
            {
              success = true,
              message = "producto eliminado",
            };

        }

        [HttpPut("/producto/{id}")]
        public dynamic editProduct(int id)
        {
            
            return listProducts.IndexOf(1);

        }
    }
}
