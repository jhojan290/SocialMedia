using SocialMedia.Core.Entities;

namespace SocialMedia.Infraestructure.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
    }
}