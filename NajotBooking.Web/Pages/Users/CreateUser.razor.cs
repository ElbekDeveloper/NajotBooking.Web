using Microsoft.AspNetCore.Components;
using NajotBooking.Web.Models.Foundations.Users;
using NajotBooking.Web.Services.UserServices;

namespace NajotBooking.Web.Pages.Users
{
    public partial class CreateUser
    {
        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }

        public User user = new User();
        public async void PostUser()
        {
            try
            {
                await UserService.PostUser(user);
                NavManager.NavigateTo("/AllUsers");
            }
            catch (Exception exception)
            { }
        }
    }
}
