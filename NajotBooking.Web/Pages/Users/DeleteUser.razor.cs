using Microsoft.AspNetCore.Components;
using NajotBooking.Web.Services.UserServices;

namespace NajotBooking.Web.Pages.Users
{
    public partial class DeleteUser
    {
        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public NavigationManager navManager { get; set; }

        [Parameter]
        public string userId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await UserService.DeleteUserById(Guid.Parse(userId));
            navManager.NavigateTo("/AllUsers");
        }
    }
}
