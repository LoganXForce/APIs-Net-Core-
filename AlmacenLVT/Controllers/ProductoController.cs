using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmacenLVT.Models;
using AlmacenLVT.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmacenLVT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _productoService;
        public ProductoController(ProductoService productoService)
        {
            _productoService = productoService;
        }


        [HttpGet]
        [Route("obtener")]
        public IActionResult Obtener()
        {

            var resultado = _productoService.Obtener();
            return Ok(resultado);
        }

        [HttpGet]
        [Route("PorProductoID/{ProductoID}")]
        public IActionResult ProductoPorID(int ProductoID)
        {
            return Ok(_productoService.ObtenerPorID(ProductoID));
        }


        [HttpPost]
        [Route("agregar")]
        public IActionResult Agregar([FromBody] Producto _producto)
        {
            var resultado = _productoService.AgregarProducto(_producto);
            if(resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            return Ok(resultado);
        }

        [HttpPut]
        [Route("editar")]
        public IActionResult Editar([FromBody] Producto _producto)
        {
            var resultado = _productoService.EditarProducto(_producto);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            return Ok(resultado);
        }

        [HttpDelete]
        [Route("eliminar/{ProductoID}")]
        public IActionResult Eliminar(int ProductoID)
        {
            var resultado = _productoService.EliminarProducto(ProductoID);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}