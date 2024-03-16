using Store.Application.Interfaces;
using Store.Application.Services;
using Store.Domain.Commands;
using Store.Domain.Core.Events;
using Store.Domain.Events;
using Store.Domain.Interfaces;
using Store.Infra.CrossCutting.Bus;
using Store.Infra.Data.Context;
using Store.Infra.Data.EventSourcing;
using Store.Infra.Data.Repository;
using Store.Infra.Data.Repository.EventSourcing;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;
using Store.Application.ViewModels;
using Store.Domain.Models;
using System.Collections.Generic;

namespace Store.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, ValidationResult>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, ValidationResult>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, ValidationResult>, CustomerCommandHandler>();

            services.AddScoped<IRequestHandler<AddProductCommand, bool>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand, bool>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteProductCommand, bool>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllProductsRequest, IEnumerable<Product>>, GetAllProductsRequestHandler>();
            services.AddScoped<IRequestHandler<GetProuctByIdRequest, Product>, GetProductByIdReuestHandler>();


            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<StoreContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();
        }
    }
}