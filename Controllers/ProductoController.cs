using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Microsoft.Data.Sqlite;

class ProductoController : Controller
{
    public ProductoController()
    {
    }

    public IActionResult ListarProducto()
    {
        return View();
    }
}