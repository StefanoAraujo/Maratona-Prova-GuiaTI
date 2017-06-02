using GuiaTI.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GuiaTI.ViewModels
{
    public class PrincipalPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Banner => "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f2/Xamarin-logo.svg/1200px-Xamarin-logo.svg.png";

        public string Title => "Guia TI - Xamarin";

        public IEnumerable<Content> Contents => new[] {
                new Content {Id = 1, Name = "Xamarin", Url = "https://blog.xamarin.com/", Description = "Fique ligado a todas novidades no mundo Xamari" },
                new Content {Id = 2, Name = ".Net Coders", Url = "http://netcoders.com.br", Description = "Da comunidade para a comunidade, tudo na prática para você que odeia teoria" },
                new Content {Id = 3, Name = "MSDN", Url = "https://msdn.microsoft.com/", Description = "Tudo que anda acontecendo e todas as novidades do mundo Microsoft estão aqui" },
                new Content {Id = 4, Name = "Macoratti", Url = "http://www.macoratti.net/Default.aspx", Description = "Tutoriais? Aqui tem tudo, Macoratti!" }
            };
    }
}
