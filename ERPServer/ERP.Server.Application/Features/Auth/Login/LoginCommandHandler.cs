using ERP.Server.Application.Services;
using ERPServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERP.Server.Application.Features.Auth.Login
{
    public sealed class LoginCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> singInManager, IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
    {
        public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser? user = await userManager.Users.FirstOrDefaultAsync
                (x => x.UserName == request.EmailOrUserName || 
                x.Email == request.EmailOrUserName, 
                cancellationToken); ;

            if (user==null) 
            {

                return Result<LoginCommandResponse>.Failure("Böyle bir kullanıcı bulunamadı");
            
            }

            SignInResult signInResult = await singInManager.CheckPasswordSignInAsync(user, request.Password, true);

            if (signInResult.IsLockedOut)
            {
                TimeSpan? timeSpan= user.LockoutEnd - DateTime.UtcNow;
                if(timeSpan is not null)
                {
                    return (500, $"şifrenizi 3 defa yanlış girdiğiniz için {Math.Ceiling(timeSpan.Value.TotalMinutes)}" +
                        $"Süreyle bloke edilmiştir");
                }

                if (signInResult.IsNotAllowed)
                {
                    return (500, "mail adresiniz onaylı değil");
                }
                if (!signInResult.Succeeded)
                {
                    return (500, "şifreniz yanlış");
                }

             
            }
            var login = await jwtProvider.CreateToken(user);

            return Result<LoginCommandResponse>.Succeed(login);
        }
    }
}
