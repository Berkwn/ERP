namespace ERP.Server.Application.Features.Auth.Login
{
    public sealed record LoginCommandResponse(
        string Token,
        string RefreshToken,
        string RefreshTokenExpires
        );
    

     
    
}
