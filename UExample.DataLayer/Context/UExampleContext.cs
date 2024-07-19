using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UExample.DataLayer
{
    public class UExampleContext : DbContext
    {
        #region Context
        public UExampleContext(DbContextOptions<UExampleContext> options) : base(options)
        {

        }


        public DbSet<User> users { get; set; }
        public DbSet<UserDetail> userDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            var cascadeFKs = builder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;


            base.OnModelCreating(builder);
        }
        #endregion
    }
}
