using GuiaTI.Models;
using GuiaTI.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuiaTI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewBlogPage : ContentPage
    {
        public NewBlogPage(ICollection<Content> contents)
        {
            InitializeComponent();
            BindingContext = new NewBlogPageViewModel(Navigation, contents);
        }
    }
}