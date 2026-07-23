using GatherDinner.Application.Common.Interfaces.Authentication;
using GatherDinner.Application.Common.Interfaces.Presistence;
using GatherDinner.Domain.Entities;

namespace GatherDinner.Contracts.Authentication;

public class AuthService : IAuthService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResponse Login(string email, string password)
    {
        //1-Validate the user exists in the database
        if(_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email does not exist");
        }
        //2-Validate the password is correct
        if(user.Password != password)
        {
            throw new Exception("Invalid password");
        }
        //3-Create JWT token
        
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResponse(
            user,
            token
        );
    }

    public AuthenticationResponse Register(string firstName, string lastName, string email, string password)
    {
         //1-Validate the user exists in the database
        if(_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already Exists");
        }
        //create user (Generate Unique ID) and Presist the user to the database
        var user = new User()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        _userRepository.Add(user);

                var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResponse(
           user,
            token
        );
    }
}
