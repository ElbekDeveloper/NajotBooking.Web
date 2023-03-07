using Microsoft.AspNetCore.Components;
using NajotBooking.Web.Models.Foundations.Users;
using NajotBooking.Web.Services.UserServices;

namespace NajotBooking.Web.Pages.Users
{
    public partial class DetailUser
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }

        [Inject]
        public IUserService UserService { get; set; }

        public User user;
        protected override async Task OnInitializedAsync()
        {
            user = (await UserService.GetUserById(Guid.Parse(Id)));
        }

        public async Task UpdateUser()
        {
            await UserService.UpdateUser(user);
            NavManager.NavigateTo("/AllUsers");
        }
    }
}
