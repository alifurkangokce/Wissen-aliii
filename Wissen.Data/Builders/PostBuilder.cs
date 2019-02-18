using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wissen.Model;

namespace Wissen.Data.Builders
{
   public class PostBuilder
    {
        public PostBuilder(EntityTypeConfiguration<Post> entity)
        {
            entity.Property(d => d.Title).IsRequired().HasMaxLength(200);
            entity.Property(d => d.Description).HasMaxLength(2000);
            entity.HasOptional(p => p.Category).WithMany(m => m.Posts).HasForeignKey(p => p.CategoryId);

        }
    }
}
