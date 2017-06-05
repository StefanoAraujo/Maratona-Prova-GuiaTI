using GuiaTI.Helpers;
using GuiaTI.Models;
using GuiaTI.Services;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GuiaTI.ViewModels
{
    public class NewBlogPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ICollection<Content> _contents;

        private INavigation _navigation;

        public NewBlogPageViewModel(INavigation navigation, ICollection<Content> contents)
        {
            _navigation = navigation;
            _contents = contents;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _url;
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                OnPropertyChanged();
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private string _warning;

        public string Warning
        {
            get { return _warning; }
            set
            {
                _warning = value;
                OnPropertyChanged();
            }
        }



        public ICommand CadastrarCommand => new Command(() =>
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Warning = "Título é obrigatório";
                return;
            }

            if (string.IsNullOrWhiteSpace(Url))
            {
                Warning = "Url é obrigatório";
                return;
            }

            if (string.IsNullOrWhiteSpace(Description))
            {
                Warning = "Descrição é obrigatório";
                return;
            }

            _contents.Add(new Content { Name = Name, Description = Description, Url = Url });
            _navigation.PopModalAsync();
        });
    }
}
