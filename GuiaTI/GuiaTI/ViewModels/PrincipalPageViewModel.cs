using GuiaTI.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace GuiaTI.ViewModels
{
    public class PrincipalPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private INavigation _navigation;

        public PrincipalPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }

        public string Banner => "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f2/Xamarin-logo.svg/1200px-Xamarin-logo.svg.png";

        public string Title => "Guia TI - Xamarin";

        private static ICollection<Content> _contents =
        new[] {
                new Content {Id = 1, Name = "Xamarin", Url = "https://blog.xamarin.com/", Description = "Fique ligado a todas novidades no mundo Xamari" },
                new Content {Id = 2, Name = ".Net Coders", Url = "http://netcoders.com.br", Description = "Da comunidade para a comunidade, tudo na prática para você que odeia teoria" },
                new Content {Id = 3, Name = "MSDN", Url = "https://msdn.microsoft.com/", Description = "Tudo que anda acontecendo e todas as novidades do mundo Microsoft estão aqui" },
                new Content {Id = 4, Name = "Macoratti", Url = "http://www.macoratti.net/Default.aspx", Description = "Tutoriais? Aqui tem tudo, Macoratti!" }
            };

        public ICollection<Content> Contents
        {
            get
            {
                return _contents;
            }
            private set
            {
                _contents = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand => new Command(() =>
        {
            var page = new NewBlogPage(_contents);
            _navigation.PushModalAsync(page, true);
        });
    }
}
