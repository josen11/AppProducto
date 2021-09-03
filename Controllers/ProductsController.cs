using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.DTOs;
using ProductsApi.Models;
using ProductsApi.Repositories;

namespace ProductsApi.Controllers
{
    //Usamos los annotations para dar mayor informacion al Controller
    [ApiController]
    [Route("[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly IProductRepository _productRepository;
        //Nuestro constructor hara de referencia al Product Repository
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct (int id)
        {
            var product = await _productRepository.Get(id);
            if(product== null)
                return NotFound();
            
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts ()
        {
            var products = await _productRepository.GetAll();    
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct (CreateProductDto createProductDto)
        {
            //Entonces los DTO nos ayudaran a mandar solo los datos que requerimos para que sean aprovechados en el evento Create, sin necesidad de crear Entidades extras para ello.
            // Codigo en C# 8 para abajo
            /*var product = new Product{
                Name = createProductDto.Name,
                Price = createProductDto.Price,
                DateCreated = DateTime.Now
            };*/

            //Codigo en C# 9
            Product product = new (){
                Name = createProductDto.Name,
                Price = createProductDto.Price,
                DateCreated = DateTime.Now
            };
            await _productRepository.Add(product);    
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct (int id)
        {
            await _productRepository.Delete(id);    
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct (int id, UpdateProductDto updateProductDto)
        {
            Product product = new(){
                ProductId = id,
                Name = updateProductDto.Name,
                Price = updateProductDto.Price
            };
            await _productRepository.Update(product);
            return Ok();
        }
    }
}