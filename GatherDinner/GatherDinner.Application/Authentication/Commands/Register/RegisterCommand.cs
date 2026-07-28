using ErrorOr;
using GatherDinner.Application.Authentication.Common;
using MediatR;

namespace GatherDinner.Application.Authentication.Commands;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;