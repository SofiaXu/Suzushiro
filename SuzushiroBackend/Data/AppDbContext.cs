using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuzushiroBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuzushiroBackend.Data
{
    public class AppDbContext : IdentityDbContext<UserModel, UserRoleModel, int>
    {
        public DbSet<BindingDirectoryModel> BindingDirectories { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BindingDirectoryModel>(buildAction =>
            {
                buildAction.HasKey(bd => new { bd.Name, bd.Path });
                buildAction.ToTable("SuzushiroBindingDirectories");
            });
            base.OnModelCreating(builder);
        }
    }
}
