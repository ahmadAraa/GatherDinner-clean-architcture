using GatherDinner.Domain.Entities;

public record AuthenticationResult(
    User User,
    string Token
    );