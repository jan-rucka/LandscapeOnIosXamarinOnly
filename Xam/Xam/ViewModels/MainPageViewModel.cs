using System.Collections.Generic;
using System.Threading.Tasks;
using Xam.Base;
using Xam.Extensions;
using Xam.Model;
using Xam.Views;

namespace Xam.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Fields


        #endregion

        private ObservableCollectionExt<MainMenuItem> _menuItems = new ObservableCollectionExt<MainMenuItem>();
        public ObservableCollectionExt<MainMenuItem> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }

        public MainPageViewModel()
            : base()
        {
            Title = "Main Page";
            MenuItems.Reset(new List<MainMenuItem>
            {
                new MainMenuItem
                {
                    DestinationPageName = nameof(Page1),
                    DestinationPage = typeof(Page1),
                    ViewModel = typeof(Page1ViewModel),
                    Title = nameof(Page1)
                },
                new MainMenuItem
                {
                    DestinationPageName = nameof(Page2),
                    ViewModel = typeof(Page2ViewModel),
                    DestinationPage = typeof(Page2),
                    Title = nameof(Page2)
                },
                new MainMenuItem
                {
                    DestinationPageName = nameof(Page3),
                    ViewModel = typeof(Page3ViewModel),
                    DestinationPage = typeof(Page3),
                    Title = nameof(Page3)
                },
                new MainMenuItem
                {
                    DestinationPageName = nameof(Page4),
                    DestinationPage = typeof(Page4),
                    ViewModel = typeof(Page4ViewModel),
                    Title = nameof(Page4)
                }
            });

        }


        #region Commands

        private DelegateCommand<MainMenuItem> _menuItemTappedCommand;

        public DelegateCommand<MainMenuItem> MenuItemTappedCommand => _menuItemTappedCommand ??
            (_menuItemTappedCommand = new DelegateCommand<MainMenuItem>(async i => await _MenuItemTappedExecute(i)));

        #endregion


        #region Command methods

        private async Task _MenuItemTappedExecute(MainMenuItem mainMenuItem)
        {
                //await NavigationService.NavigateAsync($"{nameof(BaseNavigationPage)}/{mainMenuItem.DestinationPageName}");
        }

        #endregion


    }
}
