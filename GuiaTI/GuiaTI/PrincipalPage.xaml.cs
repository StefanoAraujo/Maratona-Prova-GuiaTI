using GuiaTI.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuiaTI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrincipalPage : ContentPage
    {
        public PrincipalPage()
        {
            InitializeComponent();
            BindingContext = new PrincipalPageViewModel(Navigation);
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var model = e.SelectedItem as Models.Content;
            Navigation.PushAsync(new WebPage(model));
        }
    }
}