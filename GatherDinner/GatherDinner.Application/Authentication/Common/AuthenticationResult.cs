using GatherDinner.Domain.Entities;

namespace GatherDinner.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
    );