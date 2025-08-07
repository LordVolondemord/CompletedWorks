using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;
namespace TestProjLebedev.db
{
    class DB: DbContext
    {
        public DbSet<Dot> Dots { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        protected string connection;
        public DB(string connection)
        {
            this.connection = connection;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=testDB.db");
            //optionsBuilder.UseSqlite("Data Source=:memory:");
            optionsBuilder.UseSqlite(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dot>().HasData(
                    new Dot { id = 1, x = 150, y = 150, color = "00d9d5", radius = 150 },
                    new Dot { id = 2, x = 300, y = 300, color = "00d9d5", radius = 150 },
                    new Dot { id = 3, x = 450, y = 450, color = "00d9d5", radius = 150 }
                );

            modelBuilder.Entity<Comment>().HasData(
                    new Comment { id = 1, dotId = 1, color = "FF0000", text = "SomeText" },
                    new Comment { id = 2, dotId = 1, color = "FF0000", text = "SomeText1" },
                    new Comment { id = 3, dotId = 2, color = "FF0000", text = "SomeText2" },
                    new Comment { id = 4, dotId = 3, color = "FF0000", text = "SomeText3" }
                );
        }

    }
}
