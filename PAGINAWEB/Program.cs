using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace PAGINAWEB
{
    public class Program
    {
        static string database = "base.db";
        static async Task Main(string[] args)
        {
            using (var db = new DatabaseDBContext())
            {
                await db.Database.EnsureCreatedAsync();

                /*var usuario1 = new Usuario()
                {
                    UserIdId = 1,
                    Name = "pepe",
                    Surname = "papa"
                };
                db.Usuarios.Add(usuario1);*/

                await db.SaveChangesAsync();
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });



        public class Usuario
        {
            public int UserId { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
        }

        public class Menu
        {
            public int MenuId { get; set; }
            public string Nombreitem { get; set; }
            public string Descripcion { get; set; }
            public int Precio { get; set; }
            public string Tipo { get; set; }
        }

        public class DatabaseDBContext : DbContext
        {
            /*public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<Menu> Menu { get; set; }*/

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite(connectionString: "FileName=" + database, sqliteOptionsAction: op =>
                {
                    op.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName
                        );
                });
                base.OnConfiguring(optionsBuilder);
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Usuario>().ToTable("Usuarios");
                modelBuilder.Entity<Usuario>(entity =>
                {
                    entity.HasKey(e => e.UserId);
                });
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Menu>().ToTable("Menu");
                modelBuilder.Entity<Menu>(entity =>
                {
                    entity.HasKey(e => e.MenuId);
                });
                base.OnModelCreating(modelBuilder);
            }
        }
    }
}