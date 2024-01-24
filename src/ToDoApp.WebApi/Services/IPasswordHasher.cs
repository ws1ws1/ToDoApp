namespace ToDoApp.WebApi.Services
{
    public interface IPasswordHasher
    {
        string Generate(string password);

        bool Verify(string passwordHash, string inputPassword);
    }
}
