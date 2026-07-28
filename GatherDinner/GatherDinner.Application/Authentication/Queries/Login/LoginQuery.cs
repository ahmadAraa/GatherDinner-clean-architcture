using ErrorOr;
using GatherDinner.Application.Authentication.Common;
using MediatR;

namespace GatherDinner.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;