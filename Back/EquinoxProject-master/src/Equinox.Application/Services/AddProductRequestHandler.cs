using AutoMapper;
using MediatR;
using NetDevPack.Mediator;
using Store.Application.ViewModels;
using Store.Domain.Commands;
using Store.Domain.Interfaces;
using Store.Infra.Data.Repository.EventSourcing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Application.Services
{
    public class AddProductRequestHandler : IRequestHandler<AddProductRequest, bool>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AddProductRequestHandler(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<bool> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new Exception("Invalid Request");
            }
            var product = _mapper.Map<AddProductCommand>(request);
            if (product == null)
            {
                throw new Exception("Invalid Request");
            }
            return await _mediator.Send(product);
        }
    }
}
