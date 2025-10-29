namespace ControleAcademico.Tests;

public class AuthTest
{
    private UserRepository repo;
    private AuthSession session;

    public AuthTest()
    {
        repo = new UserRepository();
        session = new AuthSession(repo);
    }

    [Fact]
    public void TestLogin()
    {
        var ex = Assert.Throws<AuthenticationException>(() => session.Login("davi", "123"));
        Assert.Equal("Usuário não cadastrado", ex.Message);
    }

    [Fact]
    public void TestRegister()
    {
        Assert.False(repo.HasUser("davi"));
        session.Register("davi", "123", "123");
        Assert.True(repo.HasUser("davi"));
    }

    [Fact]
    public void TestRegisterAndLogin()
    {
        Assert.False(repo.HasUser("davi"));
        session.Register("davi", "123", "123");
        Assert.True(repo.HasUser("davi"));
        session.Login("davi", "123");
        Assert.True(session.HasActiveUser);
        Assert.Equal("davi", session.ActiveUser?.Name);
    }

    [Fact]
    public void TestRegisterAlreadyExistingUser()
    {
        session.Register("davi", "123", "123");
        var ex = Assert.Throws<InvalidOperationException>(() => session.Register("davi", "123", "123"));
        Assert.Equal("Usuário já cadastrado", ex.Message);
    }

    [Fact]
    public void TestLogout()
    {
        session.Register("davi", "123", "123");
        session.Login("davi", "123");
        session.Logout();
        Assert.False(session.HasActiveUser);
    }

    [Fact]
    public void TestLogoutException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => session.Logout());
        Assert.Equal("Nenhum usuário logado", ex.Message);
    }
}
