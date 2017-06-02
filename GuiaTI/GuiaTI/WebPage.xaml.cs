using GuiaTI.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuiaTI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebPage : ContentPage
    {
        public WebPage(Models.Content model)
        {
            InitializeComponent();
            BindingContext = new WebPageViewModel(model);
        }
    }
}