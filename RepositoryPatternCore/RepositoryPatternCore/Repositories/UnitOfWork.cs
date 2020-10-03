using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternCore.Models;
using RepositoryPatternCore.Repositories.Definitions;
using RepositoryPatternCore.Repositories.Implementations;

namespace RepositoryPatternCore.Repositories
{
    public partial class UnitOfWork : IUnitOfWork
    {
       private readonly RepositoryDbContext db = new RepositoryDbContext(new DbContextOptions<RepositoryDbContext>());

        public UnitOfWork()
        {
            Products = new ProductRepository(db);
        }

        #region Security
        public IProductRepository Products { get; private set; }
        #endregion







        public int Complete()
        {
            return db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
