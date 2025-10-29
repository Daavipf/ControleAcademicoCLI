namespace ControleAcademico.Core;

public class User
{
    public string Name { get; }
    public string Password { get; private set; }

    public User(string name, string pswd)
    {
        Name = name;
        Password = pswd;
    }

    public bool CheckPassword(string pswd)
    {
        return Password == pswd;
    }
}
