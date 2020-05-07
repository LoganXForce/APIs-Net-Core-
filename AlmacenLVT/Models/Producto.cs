using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmacenLVT.Models
{
    public class Producto
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public string CodigoEntrada { get; set; }
        public int ProveedorID { get; set; }
        public DateTime FechaEntrada { get; set; }
        public Proveedor Proveedor { get; set; }


        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Producto> mapeoProducto)
            {
                mapeoProducto.HasKey(x => x.ProductoID);
                mapeoProducto.Property(x => x.Nombre).HasColumnName("Nombre");
                mapeoProducto.Property(x => x.Descripcion).HasColumnName("Descripcion");
                mapeoProducto.ToTable("Producto");
                mapeoProducto.HasOne(x => x.Proveedor);
            }
        }
    }
}
