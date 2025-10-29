namespace ControleAcademico.Core;

public class UserRepository
{
    public Dictionary<string, User> users;

    public UserRepository()
    {
        users = new Dictionary<string, User>();
    }

    public void Create(string name, string pswd)
    {
        if (!users.ContainsKey(name))
        {
            User newUser = new User(name, pswd);
            users.Add(name, newUser);
        }
    }

    public User? Read(string name)
    {
        if (users.ContainsKey(name))
        {
            return users[name];
        }

        return null;
    }

    public bool HasUser(string name)
    {
        return users.ContainsKey(name);
    }
}