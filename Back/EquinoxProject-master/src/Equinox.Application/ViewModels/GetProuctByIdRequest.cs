using MediatR;
using Store.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.ViewModels
{
    public class GetProuctByIdRequest : IRequest<Product>
    {
        public Guid Id { get; set; }
    }
}
