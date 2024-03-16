using MediatR;
using Store.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.ViewModels
{
    public class GetAllProductsRequest : IRequest<IEnumerable<Product>>
    {
    }

    public class GetAllProductsResponse
    {
        public string Productname { get; set; }
        public string Merchanname { get; set; }
        public decimal price { get; set; }
        public decimal tax { get; set; }
        public decimal deliveryCharge { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
    }
}
