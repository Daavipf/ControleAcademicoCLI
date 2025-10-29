namespace ControleAcademico.Core;

public class User
{
    public string Name { get; }
    public string Password { get; private set; }
    public Role Role { get; private set; }

    public User(string name, string pswd, Role role)
    {
        Name = name;
        Password = pswd;
        Role = role;
    }

    public bool CheckPassword(string pswd)
    {
        return Password == pswd;
    }
}
