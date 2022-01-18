using Marmara.Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marmara.Entity.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBlogRepository Blogs { get; }
        ICategoryRepository Categories { get; }
    }
}
