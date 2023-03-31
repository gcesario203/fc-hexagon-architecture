using Microsoft.AspNetCore.Mvc;
using Application.Product.Contracts;

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

                if(result.Item2 != null)
                    return BadRequest(result.Item2);

                return Ok(result.Item1);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}