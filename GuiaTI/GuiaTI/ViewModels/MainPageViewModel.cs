using GuiaTI.Helpers;
using GuiaTI.Services;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GuiaTI.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        Service service;
        INavigation navigation;

        ICommand loginCommand;

        public ICommand LoginCommand =>
            loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommandAsync()));

        public MainPageViewModel(INavigation nav)
        {
            service = DependencyService.Get<Service>();
            navigation = nav;
            TermoAceito = false;
        }

        private async Task ExecuteLoginCommandAsync()
        {
            if (!(await LoginAsync())) return;

            await navigation.PushAsync(new PrincipalPage());
            RemovePageFromStack();
        }

        private void RemovePageFromStack()
        {
            var existingPages = navigation.NavigationStack.ToList();
            foreach (var page in existingPages)
            {
                if (page.GetType() == typeof(MainPage))
                {
                    navigation.RemovePage(page);
                }
            }
        }

        public Task<bool> LoginAsync()
        {
            if (Settings.IsLoggedIn) return Task.FromResult(true);

            return service.LoginAsync();
        }

        private bool _termoAceito;

        public bool TermoAceito
        {
            get { return _termoAceito; }
            set
            {
                _termoAceito = value;
                OnPropertyChanged();
            }
        }

    }
}
