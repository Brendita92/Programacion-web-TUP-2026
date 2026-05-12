using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers;

public class ProductosController : Controller
{
    [HttpGet]
    public IActionResult Detalle(int id)
    {
        var producto = CrearProductos().FirstOrDefault(p => p.Id == id);

        if (producto is null)
        {
            return NotFound();
        }

        return View(producto);
    }

    [HttpGet]
    public IActionResult Listado()
    {
        var productos = CrearProductos();

        return View(productos);
    }

    private static List<Producto> CrearProductos()
    {
        return
        [
            new Producto
            {
                Id = 1,
                Nombre = "Notebook Lenovo IdeaPad",
                Descripcion = "Equipo para estudio, programacion y tareas de oficina.",
                Precio = 850000,
                Stock = 6
            },
            new Producto
            {
                Id = 2,
                Nombre = "Mouse Logitech M280",
                Descripcion = "Mouse inalambrico ergonomico.",
                Precio = 24500,
                Stock = 18
            },
            new Producto
            {
                Id = 3,
                Nombre = "Monitor Samsung 24",
                Descripcion = "Monitor Full HD para escritorio.",
                Precio = 185000,
                Stock = 9
            }
        ];
    }
}
