using GatherDinner.Domain.Entities;

public record AuthenticationResponse(
    User User,
    string Token
    );