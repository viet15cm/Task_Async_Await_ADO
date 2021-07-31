using Async_Await.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Async_Await.DataContextLayer
{
    class DataContext : DbContext
    {

       
        public DbSet<Student> students { get; set; }
        public DbSet<Teacher> teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            

            optionsBuilder.UseSqlServer(DataSource.Intances().GetDataSourceSever());
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            //https://www.entityframeworktutorial.net/efcore/configure-one-to-one-relationship-using-fluent-api-in-ef-core.aspx
            
            modelBuilder.Entity<Student>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Teacher>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Teacher>()
                            .HasMany<Student>(g => g.Students)
                            .WithOne(s => s.Teacher)
                            .HasForeignKey(s => s.TeacherId);

        }


    }
}
