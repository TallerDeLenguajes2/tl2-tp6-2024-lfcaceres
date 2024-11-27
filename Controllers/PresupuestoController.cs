using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using claseCliente;
using AltaPresupuesto;
using AltaProductoPresupuesto;
using Microsoft.Data.Sqlite;

public class PresupuestoController : Controller
{
    private readonly IPresupuestoRepository presupuesto;

    public PresupuestoController(IPresupuestoRepository _presupuesto)
    {
        presupuesto = _presupuesto;
    }

    public IActionResult ListarPresupuesto()
    {

        return View(presupuesto.ListarPresupuestos());
    }


    [HttpGet]
    public IActionResult CrearPresupuesto()
    {
        ClienteRepository lista = new ClienteRepository();
        List<Cliente> listaCliente = lista.ListarCliente();
        AltaPresupuestoViewModel presu = new AltaPresupuestoViewModel(presupuesto.ListarPresupuestos().Count + 1, listaCliente);
        return View(presu);
    }
    [HttpPost]

    public IActionResult CrearPresupuesto(AltaPresupuestoViewModel presu)
    {

        Presupuesto nuevoPresu = new Presupuesto(presu.IdCliente);
        presupuesto.CrearNuevo(nuevoPresu);
        return RedirectToAction("ListarPresupuesto");
    }

    [HttpGet]
    public IActionResult AgregarProductoPresupuesto(AltaPresupuestoViewModel presu)
    {

        ProductoRepository productos = new ProductoRepository();
        List<Producto> listaProducto = productos.ListarProducto();
        AltaProductoPresupuestoViewModel alta = new AltaProductoPresupuestoViewModel(presu.IdPresupuesto, listaProducto);
        return View(alta);
    }
    [HttpPost]

    public IActionResult AgregarProductoPresupuesto(AltaProductoPresupuestoViewModel presu)
    {
        PresupuestoDetalle nuevoDetalle = new PresupuestoDetalle();

        nuevoDetalle.CargaDetalle(presu.Detalle.Producto, presu.Detalle.Cantidad);


        return RedirectToAction("ListarPresupuesto");
    }


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