using System;

namespace Xam.Model
{
    /// <summary>
    /// The Main menu´s Item
    /// </summary>
    public class MainMenuItem : BaseEntity
    {        
        private string _title;
        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _iconSource;
        /// <summary>
        /// Icon source
        /// </summary>
        public string IconSource
        {
            get { return _iconSource; }
            set { SetProperty(ref _iconSource, value); }
        }

        private string _iconFont;
        /// <summary>
        /// Icon font code
        /// </summary>
        public string IconFont
        {
            get { return _iconFont; }
            set { SetProperty(ref _iconFont, value); }
        }

        private string _destinationPageName;
        /// Name of destination page
        /// </summary>
        public string DestinationPageName
        {
            get { return _destinationPageName; }
            set { SetProperty(ref _destinationPageName, value); }
        }

        private string _group;
        public string Group
        {
            get { return _group; }
            set { SetProperty(ref _group, value); }
        }

        private string _subGroup;

        public string SubGroup
        {
            get { return _subGroup; }
            set { SetProperty(ref _subGroup, value); }
        }

        public bool IsGroupHeaderVisible => string.IsNullOrEmpty(Group) || string.IsNullOrEmpty(SubGroup);

        private bool _isHomePageShortcut;

        public bool IsHomePageShortcut
        {
            get => _isHomePageShortcut;
            set => SetProperty(ref _isHomePageShortcut, value);
        }

        private int _homePageShortcutOrder;

        public int HomePageShortcutOrder
        {
            get => _homePageShortcutOrder;
            set => SetProperty(ref _homePageShortcutOrder, value);
        }

        private Type _destinationPage;

        public Type DestinationPage
        {
            get => _destinationPage;
            set => SetProperty(ref _destinationPage, value);
        }

        private Type _viewModel;
        public Type ViewModel
        {
            get => _viewModel;
            set => SetProperty(ref _viewModel, value);
        }
    }

}
