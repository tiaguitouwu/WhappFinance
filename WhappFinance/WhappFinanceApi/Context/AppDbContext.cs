using Microsoft.EntityFrameworkCore;
using System.Data;
using WhappFinanceApi.Models;

namespace WhappFinanceApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyLowerCaseConvention(modelBuilder);
            //ApplyUsuarioConfiguration(modelBuilder);
            //ApplyTodoConfiguration(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
        private void ApplyLowerCaseConvention(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetSchema("dbo");

                var tableName = entity.GetTableName();
                if (!string.IsNullOrEmpty(tableName))
                {
                    entity.SetTableName(tableName.ToLower());
                }

                foreach (var property in entity.GetProperties())
                {
                    var columnName = property.GetColumnName();
                    if (!string.IsNullOrEmpty(columnName))
                    {
                        property.SetColumnName(columnName.ToLower());
                    }
                }
            }
        }

        public DbSet<ClientData> ClientData { get; set;}
        
    }
}
