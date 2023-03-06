using Microsoft.AspNetCore.Components;
using NajotBooking.Web.Models.Foundations.Users;

namespace NajotBooking.Web.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;

        }

        public async Task PostUser(User user)
        {
            try
            {
                await httpClient.SendJsonAsync(
                    HttpMethod.Post, "api/Users", user);
            }
            catch (Exception exception)
            { }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                return await httpClient
                    .GetJsonAsync<User[]>("api/Users");
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public async Task<User> GetUserById(Guid userId)
        {
            try
            {
                return await httpClient
                    .GetJsonAsync<User>($"api/Users/{@userId}");
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            try
            {
                return await httpClient.SendJsonAsync<User>(
                    HttpMethod.Put, "api/Users", user);
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public async Task DeleteUserById(Guid userId)
        {
            try
            {
                await httpClient.DeleteAsync(
                    $"api/Users/{@userId}");
            }
            catch (Exception exception)
            { }
        }
    }
}
