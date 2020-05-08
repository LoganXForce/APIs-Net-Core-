using AlmacenLVT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmacenLVT.Services
{
    public class ProductoService
    {
        private readonly ProductosDBContext _productoDBContext;
        public ProductoService(ProductosDBContext productoDBContext)
        {
            _productoDBContext = productoDBContext;
        }


        public List<Producto> Obtener()
        {
           var resultado = _productoDBContext.Producto.Include(x => x.Proveedor).OrderByDescending(x => x.ProductoID).ToList();
            return resultado;
        }

        public Producto ObtenerPorID(int ProductoID)
        {
            try
            {
                var resultado = _productoDBContext.Producto.Where(x => x.ProductoID == ProductoID).FirstOrDefault();
                var proveedor = _productoDBContext.Proveedor.Where(x => x.ProveedorID == resultado.ProveedorID).FirstOrDefault();

                return resultado;
            }
            catch (Exception error)
            {
                return new Producto();
            }
        }


        public Boolean AgregarProducto(Producto _producto)
        {
            try { 
            _productoDBContext.Producto.Add(_producto);
            _productoDBContext.SaveChanges();
            return true;
            }
            catch(Exception error)
            {
                return false;
            }
        }

        public Boolean EditarProducto(Producto _producto)
        {
            try
            {
                var productoBaseDatos = _productoDBContext.Producto.Where(busqueda => busqueda.ProductoID == _producto.ProductoID).FirstOrDefault();
                productoBaseDatos.Nombre = _producto.Nombre;
                productoBaseDatos.Descripcion = _producto.Descripcion;
                productoBaseDatos.Cantidad = _producto.Cantidad;
                productoBaseDatos.Precio = _producto.Precio;
                productoBaseDatos.CodigoEntrada = _producto.CodigoEntrada;
                productoBaseDatos.ProveedorID = _producto.ProveedorID;
                productoBaseDatos.FechaEntrada = _producto.FechaEntrada;

                _productoDBContext.SaveChanges();

                return true;
            }
            catch(Exception error)
            {
                return false;
            }
        }

        public Boolean EliminarProducto(int ProductoID)
        {
            try
            {
                var productoBaseDatos = _productoDBContext.Producto.Where(busqueda => busqueda.ProductoID == ProductoID).FirstOrDefault();
                _productoDBContext.Producto.Remove(productoBaseDatos);
                _productoDBContext.SaveChanges();
                return true;

            }
            catch(Exception error)
            {
                return false;
            }
        }

    }
}
