using MediatR;
using TS.Result;

namespace ERP.Server.Application.Features.Auth.Login
{
    public sealed record LoginCommand
        (string EmailOrUserName,
        string Password
        ) :IRequest<Result<LoginCommandResponse>>;
}
