namespace jwt_rest.Services
{
    public interface IJwtService
    {
        string CreateToken(string name);
    }
}
