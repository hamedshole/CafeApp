using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CafeApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IApplicationUnit applicationUnit)
        {
            _service = applicationUnit.Products;
        }

        // GET: api/<TablesController>
        [HttpGet]
        public async Task<ActionResult<PagedList<ProductDto>>> Get(ListProductParameter parameter)
        {
            try
            {
                var res = await _service.GetPaged(parameter.GetSpecifications(), parameter);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        


        // GET api/<TablesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(Guid id)
        {
            try
            {
                var res = _service.GetBy(new GetProductParameter(id).GetSpecifications());
                return Ok(await Task.FromResult(res));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // POST api/<TablesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductParameter value)
        {
            try
            {
                await _service.CreateAsync(value);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        // PUT api/<TablesController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductParameter value)
        {
            try
            {
                await _service.UpdateAsync(value);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // DELETE api/<TablesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
