namespace GatherDinner.Contracts.Authentication;

public interface IAuthService
{
    AuthenticationResponse Register(string firstName, string lastName, string email, string password);
    AuthenticationResponse Login(string email, string password);
}