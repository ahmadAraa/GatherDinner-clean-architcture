using GatherDinner.Application.Authentication.Common;
using GatherDinner.Application.Common;
using MediatR;

namespace GatherDinner.Application.Authentication.Queries.Login;

public record LoginQuery(
  string Email,
  string Password
) : IRequest<AuthenticationResult>;