using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ShopApp.DataAcces
{
    // DEFINICIÓN DE ENTIDADES
    public record Category(int Id, string Nombre);

    public record Product(int Id, string Nombre, string Descripcion, decimal Precio, int CategoryId)
    {
        public Category? Category { get; set; }
    }

    public record Client(int Id, string Nombre, string Direccion);

    // CLASE DBCONTEXT
    public class ShopDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }

        public ShopDbContext()
        {
            Database.EnsureCreated();
        }

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("ShopComputer");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Carga de datos iniciales - Categorías
            modelBuilder.Entity<Category>().HasData(
                new Category(1, "Electronicos"),
                new Category(2, "Computadoras"),
                new Category(3, "Telefonos Moviles"),
                new Category(4, "Dispositivos de Escritorio"),
                new Category(5, "Microfonos y Audio"),
                new Category(6, "Artefactos del Hogar"),
                new Category(7, "Juguetes y Juegos")
            );

            // Carga de datos iniciales (Seed Data) - Productos
            modelBuilder.Entity<Product>().HasData(
                new Product(1, "Radio Digital", "Es una radio de banda ancha", 100, 1),
                new Product(2, "Reloj electrónico", "Reloj digital sumergible", 50, 1),
                new Product(3, "Laptop HP", "Laptop Escritorio", 900, 2),
                new Product(4, "Laptop Acer", "Laptop Gamer", 1200, 2),
                new Product(5, "Macbook Apple", "Gran Capacidad", 1500, 2),
                new Product(6, "Samsung Galaxy", "Smartphone 5G", 1800, 3),
                new Product(7, "Iphone 14", "Apple disp", 1500, 3)
            );
        }
    }
}