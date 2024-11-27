using System.Security.Principal;

public class Usuario
{
    int id;
    string username;

    string nombre;

    string password;

    private AccessLevel accessLevel;

    public Usuario()
    {
    }
    public Usuario(CrearUsuarioViewModel usuVM)
    {
        username = usuVM.Username;
        nombre = usuVM.Nombre;
        password = usuVM.Password;
        accessLevel = usuVM.AccessLevel;
    }


    public int Id { get => id; set => id = value; }
    public string Username { get => username; set => username = value; }
    public string Password { get => password; set => password = value; }
    public AccessLevel AccessLevel { get => accessLevel; set => accessLevel = value; }
    public string Nombre { get => nombre; set => nombre = value; }
}

public enum AccessLevel
{
    Admin, 

    Cliente

}