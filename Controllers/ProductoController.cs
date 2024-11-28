using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using AltaProducto;
using Microsoft.Data.Sqlite;

public class ProductoController : Controller
{
    IProductoRepostory producto;

    public ProductoController(IProductoRepostory _producto)
    {
        producto = _producto;
    }

    public IActionResult ListarProducto()
    {

        return View(producto.ListarProducto());
    }


    [HttpGet]
    public IActionResult CrearProducto()
    {
        AltaProductoViewModel producto = new AltaProductoViewModel();
        return View(producto);
    }

    [HttpPost]
    public IActionResult CrearProducto(Producto prod)
    {
        if(!ModelState.IsValid) return RedirectToAction("ListarProducto");

        prod.IdProducto = producto.ListarProducto().Count + 1;
        producto.CrearNuevo(prod);
        return RedirectToAction("ListarProducto");
    }

    [HttpGet]
    public IActionResult ModificarProducto(int id1)
    {
        // si creo un boton en listarproducto para modificar el producto, mando el id y el get lo recibe 
        Producto prod = new Producto();
        prod.IdProducto = id1;
        return View(prod);
    }
    [HttpPost]
    public IActionResult ModificarProducto(Producto produc)
    {

        producto.ModificarProducto(produc.IdProducto, produc);
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