using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApi.Application.Product.Queries;
using MyApi.Application.Product.Responses;

namespace MyApi.Presentation.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetAllProduct()
        {
            var query = new GetAllProductsQuery();
            var result = await _mediator.Send(query);

            return result.ToList();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
