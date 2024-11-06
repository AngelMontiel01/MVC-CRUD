using ETIGRTEC.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETIGRTEC.Services
{
    public class ProductService
    {

        //LLAMAMOS LA URL POR MEDIO DE UN READONLY CON VARIABLE PRIVADA
        private readonly string _baseUrl = "https://api.escuelajs.co/api/v1/products";

        // RESTCLIENT DE RESTSHARP PARA LAS VARIABLE DEL CLIENTE
        private readonly RestClient _client;


        //CONSTRUCTOR
        public ProductService()
        {
            _client = new RestClient();
        }

        //PROCESOS PARA OBTENER LOS VERBOS HTTP DESDE EL CONTROLADOR 
        public async Task<List<Product>> GetAllProductsAsync()
        {
            //LLAMAREMOS LA URL Y LE PONEMOS EL METODO GET PARA HACER EL PROCESO
            var request = new RestRequest(_baseUrl, Method.Get);
            var response = await _client.ExecuteAsync(request);

           
            var products = response.IsSuccessful ? JsonConvert.DeserializeObject<List<Product>>(response.Content) : new List<Product>();

        
            foreach (var product in products)
            {
                if (product.Images != null && product.Images.Any())
                {
                    //SI LA IMAGEN TIENE MAS DE UNA URL OBTENDRA LA PRIMERA
                    product.Images = new List<string> { product.Images.First() };
                }
            }

            return products;
        }

        //OBTENDREMOS EL PRODUCTO POR ID PARA DIFERENTES PROCESOS
        public async Task<Product> GetProductByIdAsync(int id)
        {
            //LLAMAREMOS LA URL Y LE MANDAREMOS UN ID DE VARIABLE PARA HACERLO POR PRODUCTO
            var request = new RestRequest($"{_baseUrl}/{id}", Method.Get);
            var response = await _client.ExecuteAsync(request);
            //DESERIALIREMOS EL OBJETO PRODUCTO PARA TENER UN MEJOR METODO DE DATOS
            return response.IsSuccessful ? JsonConvert.DeserializeObject<Product>(response.Content) : null;
        }


        public async Task CreateProductAsync(Product product)
        {
            //CREAR PRODUCTO,METODO POST 
            var request = new RestRequest(_baseUrl, Method.Post).AddJsonBody(product);
            await _client.ExecuteAsync(request);
        }

        public async Task UpdateProductAsync(int id, Product product)
        {
            //ACTUALIZAR PRODUCTO POR MEDIO DE METODO PUT
            var request = new RestRequest($"{_baseUrl}/{id}", Method.Put)
                            .AddJsonBody(product);

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                throw new Exception("Error updating product");
            }
        }


        public async Task DeleteProductAsync(int id)
        {
            //ELIMINAR EL PRODUCTO
            var request = new RestRequest($"{_baseUrl}/{id}", Method.Delete);
            await _client.ExecuteAsync(request);
        }
    }
}
