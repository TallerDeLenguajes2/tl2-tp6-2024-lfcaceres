using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Microsoft.Data.Sqlite;

public class ProductoController : Controller
{
    ProductoRepository producto;

    public ProductoController()
    {
        producto = new ProductoRepository();
    }

    public IActionResult ListarProducto()
    {
        
        return View(producto.ListarProducto());
    }


    [HttpPost]
    public IActionResult CrearProducto()
    {
        producto.CrearNuevo(prod);
        return View(producto.CrearNuevo(prod));
    }

}