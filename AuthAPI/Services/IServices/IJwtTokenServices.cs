namespace AuthAPI.Services.IServices
{
    public interface IJwtTokenServices
    {
        string GenerateToken(string userId, string Username);
    }
}
