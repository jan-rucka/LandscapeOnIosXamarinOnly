using Xam.Base;

namespace Xam.Model
{
    public class BaseEntity : BindableBase
    {
        string _id;       
        public string Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
    }
}
