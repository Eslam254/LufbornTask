using MediatR;
using NetDevPack.Data;
using NetDevPack.Messaging;
using Store.Domain.Interfaces;
using Store.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Domain.Commands
{
    public class ProductCommandHandler : CommandHandler,
         IRequestHandler<AddProductCommand, bool>,
        IRequestHandler<UpdateProductCommand, bool>,
        IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IMediator mediator;
        private readonly IProductRepository _productRepository;
      
        public ProductCommandHandler(IProductRepository productRepository )
        {       
            _productRepository = productRepository;
            
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddError("Invalid Request.");
                return false;
            }
            var product = await _productRepository.GetById(request.Id).ConfigureAwait(false);
            if (product == null)
            {
                AddError("Invalid Request.");
                return false;
            }
             _productRepository.Remove(product);
            await Commit(_productRepository.UnitOfWork);
            return true;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddError("Invalid Request.");
                return false;
            }
            var product = await _productRepository.GetById(request.Id).ConfigureAwait(false);
            if (product == null)
            {
                AddError("Invalid Request.");
                return false;
            }
            product.price = request.price;
            product.tax = request.tax;
            product.deliveryCharge = request.deliveryCharge;
            product.Merchanname = request.Merchanname;
            product.Productname = request.Productname;
            product.description = request.description;
            product.quantity = request.quantity;
            _productRepository.Update(product);
            await Commit(_productRepository.UnitOfWork);
            return true;
        }

        public async Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddError("Invalid Request.");
                return false;
            }
             Product product = new Product();
             product.Id = Guid.NewGuid();
             product.Productname = request.Productname;
             product.price = request.price;
             product.tax = request.tax;
             product.quantity = request.quantity;
             product.deliveryCharge = request.deliveryCharge;
             product.description = request.description;
             product.Merchanname = request.Merchanname;
            _productRepository.Add(product);
            await Commit(_productRepository.UnitOfWork);
             return true;
        }
    }
}
