using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using GuiaTI.Services;
using GuiaTI.Droid.Authentication;
using System.Threading.Tasks;
using GuiaTI.Helpers;

[assembly: Dependency(typeof(Auth))]
namespace GuiaTI.Droid.Authentication
{
    public class Auth : IAuthentication
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            try
            {
                var user = await client.LoginAsync(Forms.Context, provider);

                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}