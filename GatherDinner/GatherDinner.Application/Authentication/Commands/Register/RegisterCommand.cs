using GatherDinner.Application.Authentication.Common;
using GatherDinner.Application.Common;
using MediatR;

namespace GatherDinner.Application.Authentication.Commands;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest<AuthenticationResult>;