using AutoMapper;
using MediatR;
using Store.Application.ViewModels;
using Store.Domain.Interfaces;
using Store.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Application.Services
{
    public class GetAllProductsRequestHandler : IRequestHandler<GetAllProductsRequest, IEnumerable<Product>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IProductRepository _productRepository;

        public GetAllProductsRequestHandler(IMapper mapper, IMediator mediator, IProductRepository productRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new Exception("Invalid Request");
            }
            var product = await _productRepository.GetAll();
            if (product == null)
            {
                return new List<Product>();
            }
            return product;
        }
    }
}
