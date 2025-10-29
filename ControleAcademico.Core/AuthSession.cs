using System.Security.Authentication;

namespace ControleAcademico.Core;

public class AuthSession
{
    public User? ActiveUser { get; private set; }
    public bool HasActiveUser => ActiveUser != null;
    private UserRepository repo;

    public AuthSession(UserRepository systemRepository)
    {
        ActiveUser = null;
        repo = systemRepository;
    }

    public void Login(string name, string password)
    {
        User? user = FindUser(name) ?? throw new AuthenticationException("Usuário não cadastrado");
        if (user.CheckPassword(password))
        {
            ActiveUser = user;
        }
        else
        {
            throw new AuthenticationException("Login inválido");
        }
    }

    private User? FindUser(string name)
    {
        return repo.Read(name);
    }

    public void Register(string name, string password, string confirmPassword, Role role)
    {
        if (repo.HasUser(name))
        {
            throw new InvalidOperationException("Usuário já cadastrado");
        }
        else
        {
            if (password == confirmPassword)
            {
                repo.Create(name, password, role);
            }
            else
            {
                throw new InvalidOperationException("Senhas não conferem");
            }

        }
    }

    public void Logout()
    {
        if (!HasActiveUser)
        {
            throw new InvalidOperationException("Nenhum usuário logado");
        }
        ActiveUser = null;
    }
}