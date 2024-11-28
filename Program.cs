var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductoRepostory,ProductoRepository>();
builder.Services.AddScoped<IPresupuestoRepostory,PresupuestoRepository>();
builder.Services.AddScoped<IClienteRepository,ClienteRepository>();
builder.Services.AddScoped<IUsuarioRepository,UsuarioRepository>();

// se agrega estas dos lineas para la inyeccion de la cadena de conexion, se modifica el appsetting y se agrega al repositorio en el constructor
String CadenaDeConexion = builder.Configuration.GetConnectionString("SqliteConexion")!.ToString();
builder.Services.AddSingleton(CadenaDeConexion);

//PARTE DE AUTENTICACION
//se agrega esto para poder utilizar httpcontext
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Ajusta el tiempo de expiración según lo necesario
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


// Configuración del logging (por defecto ya está configurado para consola)
builder.Logging.ClearProviders();   // Limpiar proveedores previos si es necesario
builder.Logging.AddConsole();       // Agregar el log a la consola

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// PARTE DE AUTENTICACION
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
