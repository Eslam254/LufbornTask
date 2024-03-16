using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.ViewModels
{
    public class DeleteProductRequest : IRequest<bool>
    {
        public Guid Id { get; set; }

    }
}
