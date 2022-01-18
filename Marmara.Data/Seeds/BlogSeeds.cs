using Marmara.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marmara.Data.Seeds
{
    public class BlogSeeds:IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasData(
                new Blog { Id = 1, Context = "Bugün okul yok.", Title = "Okul yok", Date = DateTime.Now, CategoryId = 1 },
                new Blog { Id = 2, Context = "Bugün okul güzel.", Title = "Okul güzel", Date = DateTime.Now.AddDays(10), CategoryId = 1 },
                new Blog { Id = 3, Context = "Tanışma toplantısına davetlisin.", Title = "Etkileşim kulübü", Date = DateTime.Now, CategoryId = 2 }
                );
        }
    }
}
