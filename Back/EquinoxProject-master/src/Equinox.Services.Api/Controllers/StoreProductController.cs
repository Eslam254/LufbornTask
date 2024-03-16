using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Authorization;
using Store.Application.ViewModels;
using Store.Domain.Models;
using Store.Services.Api.Controllers;

namespace Store.Services.Api.Controllers
{
 
    public class StoreProductController : ApiController
    {
        private readonly IMediator _bus;

        public StoreProductController(IMediator bus)
        {
            _bus = bus;
        }

        [AllowAnonymous]
        [HttpGet("StoreProduct")]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _bus.Send(new GetAllProductsRequest() { });
        }
        [AllowAnonymous]
        [HttpGet("StoreProduct/{id:guid}")]
        public async Task<Product> Get(Guid id)
        {
            return await _bus.Send(new GetProuctByIdRequest() { Id = id });
        }


        [HttpPost("StoreProduct")]
        public async Task<IActionResult> Post([FromBody] AddProductRequest productRequest)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _bus.Send(productRequest));
        }


        [HttpPut("StoreProduct")]
        public async Task<IActionResult> Put([FromBody] UpdateProductRequest productRequest)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _bus.Send(productRequest));
        }

        [HttpDelete("StoreProduct")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _bus.Send(new DeleteProductRequest() { Id = id}));
        }
    }
}
