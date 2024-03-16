using AutoMapper;
using Store.Application.ViewModels;
using Store.Domain.Commands;
using Store.Domain.Models;
using System.Collections.Generic;

namespace Store.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
                .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
            CreateMap<CustomerViewModel, UpdateCustomerCommand>()
                .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));

            CreateMap<AddProductRequest, AddProductCommand>().ReverseMap();
            CreateMap<UpdateProductRequest, UpdateProductCommand>().ReverseMap();
            CreateMap<DeleteProductRequest, DeleteProductCommand>().ReverseMap();
            CreateMap<GetAllProductsResponse, IEnumerable<Product>>().ReverseMap();
        }
    }
}
