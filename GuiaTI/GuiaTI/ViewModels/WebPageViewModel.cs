using GuiaTI.Models;

namespace GuiaTI.ViewModels
{
    public class WebPageViewModel
    {
        private Content _model;

        public WebPageViewModel(Content model)
        {
            _model = model;
        }

        public string Url => _model.Url;
        public string Title => _model.Name;
    }
}
