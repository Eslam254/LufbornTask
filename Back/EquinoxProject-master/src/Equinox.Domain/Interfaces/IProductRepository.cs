using NetDevPack.Data;
using Store.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Interfaces   
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetById(Guid id);
        Task<Product> GetByName(string email);
        Task<IEnumerable<Product>> GetAll();

        void Add(Product product);
        void Update(Product product);
        void Remove(Product product);
    }
}
