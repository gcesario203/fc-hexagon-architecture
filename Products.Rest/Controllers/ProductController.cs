using Microsoft.AspNetCore.Mvc;
using Application.Product.Contracts;
using Adapters.Product.DTOs;

namespace Products.Rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var result = _service.GetById(id);

                if (result.Item2 != null || result.Item1 == null)
                    return BadRequest(result.Item2);

                return Ok(result.Item1);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductDTO product)
        {
            try
            {
                product.Validate();
                var result = _service.Create(product.Name, product.Value);

                if (result.Item2 != null || result.Item1 == null)
                    return BadRequest(result.Item2);

                return CreatedAtAction("GetById", result.Item1);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("[action]/{id}")]
        public IActionResult Enable(string id)
        {
            try
            {
                var result = _service.GetById(id);

                if (result.Item2 != null || result.Item1 == null)
                    return BadRequest(result.Item2);

                var enableResult = _service.Enable(result.Item1);

                if (enableResult.Item2 != null || enableResult.Item1 == null)
                    return BadRequest(enableResult.Item2);

                return Ok(enableResult.Item1);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("[action]/{id}")]
        public IActionResult Disable(string id)
        {
            try
            {
                var result = _service.GetById(id);

                if (result.Item2 != null || result.Item1 == null)
                    return BadRequest(result.Item2);

                var DisableResult = _service.Disable(result.Item1);

                if (DisableResult.Item2 != null || DisableResult.Item1 == null)
                    return BadRequest(DisableResult.Item2);

                return Ok(DisableResult.Item1);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}