using NajotBooking.Web.Brokers.Apis;
using NajotBooking.Web.Services.OrderServices;
using NajotBooking.Web.Services.UserServices;

namespace NajotBooking.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddHttpClient();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddLogging();
            builder.Services.AddTransient<IApiBroker, ApiBroker>();
            AddHttpClients(builder);

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
            app.Run();
        }

        private static void AddHttpClients(WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient();

            var uri = new Uri("https://najot-booking.azurewebsites.net/");

            builder.Services.AddHttpClient<IUserService, UserService>(client =>
            {
                client.BaseAddress = uri;
            });

            builder.Services.AddHttpClient<IOrderService, OrderService>(client =>
            {
                client.BaseAddress = uri;
            });
        }

    }
}