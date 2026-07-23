using GatherDinner.Domain.Entities;

namespace GatherDinner.Application.Common.Interfaces.Presistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
         void Add(User user);
    }
}