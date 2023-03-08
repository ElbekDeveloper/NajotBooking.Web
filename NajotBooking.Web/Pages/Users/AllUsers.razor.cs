using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NajotBooking.Web.Models.Foundations.Users;
using NajotBooking.Web.Services.UserServices;

namespace NajotBooking.Web.Pages.Users
{
    public partial class AllUsers
    {
        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        public IEnumerable<User> Users { get; set; }

        private int order = 1;

        protected override async Task OnInitializedAsync()
        {
            Users = (await UserService.GetAllUsers()).ToList();
        }

        public async Task DeleteUserById(Guid userId)
        {
            await UserService.DeleteUserById(userId);

            Users = (await UserService.GetAllUsers()).ToList();
            StateHasChanged();
        }

        public async void ConfirmDelelte(Guid userId, string name)
        {
            bool IsConfirmed = await JsRuntime.InvokeAsync<bool>("confirm", $"Do you want do Delelte {name}");
            order = 1;
            if (IsConfirmed)
            {
                DeleteUserById(userId);
            }
            else
            {
                StateHasChanged();
            }
        }
    }
}
