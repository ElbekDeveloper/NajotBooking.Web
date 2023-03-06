using NajotBooking.Web.Models.Foundations.Users;

namespace NajotBooking.Web.Services.UserServices
{
    public interface IUserService
    {
        Task PostUser(User user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(Guid userId);
        Task<User> UpdateUser(User user);
        Task DeleteUserById(Guid userId);
    }
}
