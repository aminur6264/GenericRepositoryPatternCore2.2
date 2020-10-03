using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPatternCore.Repositories.Definitions
{
    public partial interface IUnitOfWork : IDisposable
    {
        //ICourseRepository Courses { get; }
        //IAuthorRepository Authors { get; }
        //IUserRepository Users { get; }
        IProductRepository Products { get; }
        int Complete();
    }
}
