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


    [HttpGet]
    public IActionResult CrearProducto()
    {
        Producto producto = new Producto();
        return View(producto);
    }
    [HttpPost]

    public IActionResult CrearProducto(Producto prod)
    {
        
        prod.IdProducto = producto.ListarProducto().Count +1;
        producto.CrearNuevo(prod);
        return RedirectToAction("ListarProducto");
    }

    [HttpGet]
    public IActionResult ModificarProducto()
    {
        return View(new Producto());
    }
    [HttpPost]
    public IActionResult ModificarProducto(Producto produc)
    {

        producto.ModificarProducto(produc.IdProducto,produc);
        return RedirectToAction("ListarProducto");
    }

    [HttpGet]
    public IActionResult EliminarProducto()
    {
        return View(new Producto());
    }
    [HttpPost]
    public IActionResult EliminarProducto(Producto prod)
    {

        producto.EliminarProducto(prod.IdProducto);
        return RedirectToAction("ListarProducto");
    }
}