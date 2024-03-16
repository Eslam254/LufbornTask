using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.ViewModels
{
    public class UpdateProductRequest : IRequest<bool>
    {
        public Guid Id { get;  set; }
        public string Productname { get; set; }
        public string Merchanname { get; set; }
        public decimal price { get; set; }
        public decimal tax { get; set; }
        public decimal deliveryCharge { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
    }
}
