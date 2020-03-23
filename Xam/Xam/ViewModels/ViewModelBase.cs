using Xam.Base;

namespace Xam.ViewModels
{
    public class ViewModelBase : BindableBase
    { 
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

    }
}
