using AlmacenLVT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmacenLVT
{
    public class ProductosDBContext : DbContext
    {
        public ProductosDBContext(DbContextOptions opciones) : base(opciones)
        {

        }

        public DbSet<Producto> Producto { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }


       protected override void OnModelCreating(ModelBuilder modeloCreador)
        {
            new Producto.Mapeo(modeloCreador.Entity<Producto>());
            new Proveedor.Mapeo(modeloCreador.Entity<Proveedor>());
        }


    }
}
