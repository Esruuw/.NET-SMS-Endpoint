using StudentApi.Dtos.Auth;

public interface IAuthService
{
    Task<string?> LoginAsync(LoginDto dto);
    Task RegisterAsync(RegisterDto dto);
    Task<bool> ChangePasswordAsync(string username, ChangePasswordDto dto);
}