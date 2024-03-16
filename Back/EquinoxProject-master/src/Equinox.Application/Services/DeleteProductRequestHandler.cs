using AutoMapper;
using MediatR;
using Store.Application.ViewModels;
using Store.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Application.Services
{
    public class DeleteProductRequestHandler : IRequestHandler<DeleteProductRequest, bool>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DeleteProductRequestHandler(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<bool> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new Exception("Invalid Request");
            }
            var product = _mapper.Map<DeleteProductCommand>(request);
            if (product == null)
            {
                throw new Exception("Invalid Request");
            }
            return await _mediator.Send(product);
        }
    }
}
