using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using Store.Domain.Interfaces;
using Store.Domain.Models;
using Store.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infra.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
       
        protected readonly StoreContext Db;
        protected readonly DbSet<Product> DbSet;

        public ProductRepository(StoreContext context)
        {
            Db = context;
            DbSet = Db.Set<Product>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public void Add(Product product)
        {
            DbSet.Add(product);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
           return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetById(Guid id)
        {
          return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> GetByName(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Productname == name);
        }

        public void Remove(Product product)
        {
            DbSet.Remove(product);
        }

        public void Update(Product product)
        {
            DbSet.Update(product);
        }
    }
}
