using Microsoft.AspNetCore.Mvc;
using ProductDependencyInjection.Exceptions;
using ProductDependencyInjection.Model;
using ProductDependencyInjection.Repositories.Interfaces;
using ProductDependencyInjection.Services.Interfaces;
using System;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductDependencyInjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;

        }

        // GET: api/<ProductController>
        [HttpGet("GetAllProduct")]
        public IActionResult Get()
        {
            var product = _productService.GetAllProducts();
            return (Ok(product));
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {

                return Ok(_productService.GetProductbyId(id));
            }
            catch (ProductValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                _productService.AddProduct(product);
                return Ok("Product Added");
            }
            catch (ProductValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productService.RemoveProductbyId(id);
                return Ok("Product Deleted");
            }
            catch (ProductValidationException ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public IActionResult DeleteProduct(Product product)
        {
            try
            {
                _productService.RemoveProduct(product);
                return Ok("Product delete");
            }
            catch (ProductValidationException ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpGet("FilterByName&Price")]
        public IActionResult Get(string name = null, double? minPrice = null, double? maxPrice = null)
        {
                       
            try
            {
                var filteredProducts = _productService.FilterProducts(name, minPrice, maxPrice);
                return Ok(filteredProducts);
            }
            catch (NoProductsFoundException ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("FIlterByName")]
        public IActionResult Get(string ? name)
        {
            Expression<Func<Product, bool>> predicate = p =>
                (string.IsNullOrEmpty(name) || p.Name.Contains(name));
            try
            {
                var filteredProducts = _productService.FilterProductByname(predicate);
                return Ok(filteredProducts);
            }
            catch (NoProductsFoundException ex)
            {

                return BadRequest(ex.Message);
            }
           
            
        }
    }
}
