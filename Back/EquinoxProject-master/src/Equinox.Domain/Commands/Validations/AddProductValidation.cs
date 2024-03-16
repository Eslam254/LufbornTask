using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Commands.Validations
{
    public class AddProductValidation : ProductValidation<AddProductCommand>
    {
        public AddProductValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}
