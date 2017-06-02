using GuiaTI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuiaTI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();

            }
            catch (System.Exception e)
            {
                throw;
            }
        }
    }
}
