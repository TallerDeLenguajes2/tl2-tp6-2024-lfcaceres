public class LoginViewModel{
    string username;

    string password;

    bool autenticado;

    private AccessLevel accessLevel;

    public LoginViewModel()
    {
        //autenticado = false;
    }

    public string Username { get => username; set => username = value; }
    public string Password { get => password; set => password = value; }
    public bool Autenticado { get => autenticado; set => autenticado = value; }
}