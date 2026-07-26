using GatherDinner.Application.Authentication.Common;
using GatherDinner.Application.Common.Errors;
using GatherDinner.Application.Common.Interfaces.Authentication;
using GatherDinner.Application.Common.Interfaces.Presistence;
using GatherDinner.Domain.Entities;
using MediatR;

namespace GatherDinner.Application.Authentication.Queries.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginQuery, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public LoginCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                throw new ArgumentException("email not found");
            }
            if (user.Password != query.Password)
            {
                throw new ArgumentException("Password not correct");
            }
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
             user,
             token
         );
        }

    }
}