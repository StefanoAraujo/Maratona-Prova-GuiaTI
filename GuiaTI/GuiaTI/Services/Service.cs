using System.Threading.Tasks;
using GuiaTI.Services;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;
using GuiaTI.Helpers;

[assembly: Dependency(typeof(Service))]
namespace GuiaTI.Services
{

    public class Service
    {
        public static readonly string AppUrl = "http://jeanjnx-blogs-ti.azurewebsites.net";

        public MobileServiceClient Client { get; set; } = null;
        public static bool UseAuth { get; set; } = false;

        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);

            if (string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }
        }

        public async Task<bool> LoginAsync()
        {
            Initialize();

            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.LoginAsync(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Falha na autenticação", "Tente novamente", "OK");
                });

                return false;
            }

            Settings.AuthToken = user.MobileServiceAuthenticationToken;
            Settings.UserId = user.UserId;

            return true;
        }
    }
}
