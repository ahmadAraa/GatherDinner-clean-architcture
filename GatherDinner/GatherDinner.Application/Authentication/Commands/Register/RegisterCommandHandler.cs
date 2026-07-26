using GatherDinner.Application.Authentication.Common;
using GatherDinner.Application.Common.Errors;
using GatherDinner.Application.Common.Interfaces.Authentication;
using GatherDinner.Application.Common.Interfaces.Presistence;
using GatherDinner.Domain.Entities;
using MediatR;

namespace GatherDinner.Application.Authentication.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        //1-Validate the user exists in the database
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            throw new DuplicateEmailExeption();
        }
        //create user (Generate Unique ID) and Presist the user to the database

        var user = new User()
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };
        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }

}
