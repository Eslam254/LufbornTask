using MediatR;
using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Commands
{
    public abstract class ProductCommand : IRequest<bool>
    {
        public Guid Id { get; protected set; }
        public string Productname { get; protected set; }
        public string Merchanname { get; protected set; }
        public decimal price { get; protected set; }
        public decimal tax { get; protected set; }
        public decimal deliveryCharge { get; protected set; }
        public string description { get; protected set; }
        public int quantity { get; protected set; }
    }
}
