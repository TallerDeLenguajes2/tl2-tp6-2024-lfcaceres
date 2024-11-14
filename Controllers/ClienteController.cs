using Microsoft.AspNetCore.Mvc;
using claseCliente;

public class ClienteController : Controller
{
    ClienteRepository clienteR;

    public ClienteController()
    {
        this.clienteR = new ClienteRepository();
    }

    public IActionResult ListarCliente()
    {
        
        return View(clienteR.ListarCliente());
    }


    [HttpGet]
    public IActionResult CrearCliente()
    {
        Cliente producto = new Cliente();
        return View(producto);
    }
    [HttpPost]

    public IActionResult CrearCliente(Cliente cli)
    {
        
        cli.ClienteId = clienteR.ListarCliente().Count +1;
        clienteR.CrearNuevo(cli);
        return RedirectToAction("ListarCliente");
    }

    [HttpGet]
    public IActionResult ModificarCliente()
    {
        return View(new Producto());
    }
    [HttpPost]
    public IActionResult ModificarCliente(Cliente cli)
    {

        clienteR.ModificarCliente(cli.ClienteId,cli);
        return RedirectToAction("ListarCliente");
    }

    [HttpGet]
    public IActionResult EliminarCliente()
    {
        return View(new Cliente());
    }
    [HttpPost]
    public IActionResult EliminarCliente(Cliente cli)
    {

        clienteR.EliminarCliente(cli.ClienteId);
        return RedirectToAction("ListarCliente");
    }
}