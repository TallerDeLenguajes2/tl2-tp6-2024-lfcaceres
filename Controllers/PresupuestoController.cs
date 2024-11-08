using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Microsoft.Data.Sqlite;

public class PresupuestoController : Controller
{
    PresupuestoRepository presupuesto;

    public PresupuestoController()
    {
        presupuesto = new PresupuestoRepository();
    }

    public IActionResult ListarPresupuesto()
    {
        
        return View(presupuesto.ListarPresupuestos());
    }


    [HttpGet]
    public IActionResult CrearPresupuesto()
    {
        Presupuesto presu = new Presupuesto();
        return View(presu);
    }
    [HttpPost]

    public IActionResult CrearProducto(Presupuesto presu)
    {
        
        presu.IdPresupuesto = presupuesto.ListarPresupuestos().Count +1;
        presupuesto.CrearNuevo(presu);
        return RedirectToAction("ListarProducto");
    }

    [HttpGet]
   /* public IActionResult ModificarPresupuesto()
    {
        return View(new Presupuesto());
    }
    [HttpPost]
    public IActionResult ModificarPresupuesto(Presupuesto presu)
    {

        presupuesto(presu.IdPresupuesto,presu);
        return RedirectToAction("ListarProducto");
    }*/

    [HttpGet]
    public IActionResult EliminarPresupuesto()
    {
        return View(new Producto());
    }
    [HttpPost]
    public IActionResult EliminarPresupuesto(Presupuesto presu)
    {

        presupuesto.EliminarPresupuesto(presu.IdPresupuesto);
        return RedirectToAction("ListarProducto");
    }
}