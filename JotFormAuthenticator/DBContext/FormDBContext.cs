using JotFormAuthenticator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JotFormAuthenticator.DBContext
{
    public class FormDBContext : DbContext
    {
        public FormDBContext(DbContextOptions<FormDBContext> options) : base(options) { }
        public DbSet<FormModel> Forms { get; set; }
        public DbSet<FieldModel> Fields { get; set; }


        public override int SaveChanges()
        {
            var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

            AddedEntities.ForEach(E =>
            {
                E.Property("CreatedOn").CurrentValue = DateTime.Now;
            });

            var EditedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

            EditedEntities.ForEach(E =>
            {
                E.Property("UpdatedOn").CurrentValue = DateTime.Now;
            });

            return base.SaveChanges();
        }
    }

}

