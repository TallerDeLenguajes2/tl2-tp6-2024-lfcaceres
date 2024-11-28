using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MiWebApi.Controllers;

public class LoginController : Controller
{
    private readonly IUsuarioRepository _userRepository;

    private readonly ILogger<LoginController> _logger;



    public LoginController(IUsuarioRepository userRepository, ILogger<LoginController> logger)
    {
        _logger = logger;
        _userRepository = userRepository;

    }

    public IActionResult Index()
    {
        try
        {
            var log = new LoginViewModel()
            {
                //Revisa la cookie para saber si esta autenticado, si lo esta sera true
                Autenticado = HttpContext.Session.GetString("IsAuthenticated") == "true"
            };
            return View(log);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            Console.Write("ERROR Controlador Get Index");
            return View("Index");  
        }


    }
    
    public IActionResult Login(LoginViewModel model)
    {
        try
        {
            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                return View("Index");
            }
            Usuario usuario = _userRepository.GetUser(model.Username, model.Password);
            if(usuario != null) //ingresa correctamente
            {
                HttpContext.Session.SetString("IsAuthenticated", "true");
                HttpContext.Session.SetString("User", usuario.Username);
                HttpContext.Session.SetString("AccessLevel", usuario.AccessLevel.ToString());
                _logger.LogInformation("El usuario: "+ usuario.Username+" ingresó correctamente");
                return RedirectToAction("Index", "Home");
            }else
            {
                _logger.LogWarning("Intento de acceso invalido - Usuario: "+ usuario.Username + "Clave ingresada: "+ usuario.Password);
                // Si la autenticación falla, almacenamos un mensaje en TempData
                TempData["ErrorMessage"] = "Usuario o contraseña incorrectos.";
            }
            return View("Index",model);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
             Console.Write("ERROR Controlador Post Index");
             model.Autenticado = false;
            return View("Index", model);
        }

    }

    public IActionResult Logout()
    {
        try
        {
            // Limpiar la sesión
            HttpContext.Session.Clear();

            // Redirigir a la vista de login
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            
            _logger.LogError(ex.ToString());
            ViewBag.ErrorMessage = "No se pudo desloguear el usuario";
            return View("Index");
        }
    }
    [HttpGet]

    public IActionResult CrearUsuario()
    {
        try
        {
            return View();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return View("Index");
        }
    }

    [HttpPost]

    public IActionResult AltaUsuario(CrearUsuarioViewModel usuarioVM)
    {
        try
        {            
            if(!ModelState.IsValid) return RedirectToAction ("CrearUsuario");
            Usuario usuario = new Usuario(usuarioVM);
            _userRepository.AltaUsuario(usuario);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return View("Index");
        }
    }
}