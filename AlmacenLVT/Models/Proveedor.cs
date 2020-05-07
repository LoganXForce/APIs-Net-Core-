using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmacenLVT.Models
{
    public class Proveedor
    {
        public int ProveedorID { get; set; }
        public string NombreProveedor { get; set; }
        public string Domicilio { get; set; }
        public string PaisProcedencia { get; set; }
        public string Sucursal { get; set; }


        public class Mapeo
        {
            public Mapeo(EntityTypeBuilder<Proveedor> mapeoProveedor)
            {
                mapeoProveedor.HasKey(x => x.ProveedorID);
                mapeoProveedor.Property(x => x.NombreProveedor).HasColumnName("NombreProveedor");
                mapeoProveedor.Property(x => x.Domicilio).HasColumnName("Domicilio");
                mapeoProveedor.ToTable("Proveedor");
                
            }
        }


    }
}
