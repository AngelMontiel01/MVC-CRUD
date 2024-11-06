using Microsoft.AspNetCore.Mvc;
using ETIGRTEC.Models;
using ETIGRTEC.Services;
using System.Threading.Tasks;

namespace ETIGRTEC.Controllers
{
    //API  DESDE EL PRODUCT SERVICES
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        // LLAMAREMOS EL PRODUCT SERVICE Y LO PONDREMOS COMO CONSTRUCTOR A UNA VARIABLES
        private readonly ProductService _productService;

        //LA VARIABLE SERA UN NUEVO PROCESO DE PRODUCT SERVICES
        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }
        //METODO HTTP GET PARA LAS TAREAS

        //DARA UN RESULTADO OK SI SE CONSIGUIO LLAMAR LOSD DATOS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //LLAMAREMOS EL PRODUCTSERVICE PARA OBTENER EL METODO GETALL DE PRODUCTOS
            var products = await _productService.GetAllProductsAsync();
            return Ok(products); 
        }

        //GET POR MEDIO DE ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //AQUI SERIA LO MISMO QUE EL GET PERO POR MEDIO DE ID DESDE PRODUCTSERVICES
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }
            return Ok(product);
        }

        //PARA CREAR INSERTAREMOS LOS DATOS AL BODY DE PRODUCTO PARA LOGRAR ESTOS DATOS
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productService.CreateProductAsync(product);
            return Ok(new { message = "Product created successfully" });
        }
        //LO MISMO QUE CREAR, INSERTAREMOS LOS DATOS LA BODY PARA LOGRAR LA FUNCIÓN
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productService.UpdateProductAsync(id, product);
            return Ok(new { message = "Product updated successfully" });
        }

        //ELIMINAREMOS LOS DATOS POR MEDIO DE ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok(new { message = "Product deleted successfully" });
        }

        //SE HARA EN CASI TODO UN AWAIT DE ESPERA PARA LLAMAR EL PROCESO DE PRODUCTSERVICES QUE ESTOS PROCESOS LOGRARAN LOS METODOS DE VERBOS DE HTTP 

    }
}
