using GatherDinner.Domain.Entities;

namespace GatherDinner.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
         string GenerateToken(User user);
    }
}