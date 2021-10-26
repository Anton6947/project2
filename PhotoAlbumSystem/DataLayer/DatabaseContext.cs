using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DatabaseContext : IdentityDbContext
    {


        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<MetaData> MetaDatas { get; set; }
        public virtual DbSet<AccessType> AcessTypes { get; set; }
        public virtual DbSet<AlbumAccess> AlbumAccessors { get; set; }
        public virtual DbSet<PhotoAccess> PhotoAccessors { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }



    }
}
