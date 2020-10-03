using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryPatternCore.Models;
using RepositoryPatternCore.Repositories.Definitions;

namespace RepositoryPatternCore.Repositories.Implementations
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(RepositoryDbContext context) : base(context)
        { }






        public RepositoryDbContext db
        {
            get { return db as RepositoryDbContext; }
        }
    }
}
