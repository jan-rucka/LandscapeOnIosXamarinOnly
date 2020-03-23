using System;
using System.Reflection;
using Xam.Model;
using Xam.ViewModels;
using Xamarin.Forms;

namespace Xam.Views
{
    public partial class MainPage : MasterDetailPage
    {
        private MainPageViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MainPageViewModel();

        }
        protected override void OnSizeAllocated(double width, double height)
        {
            if (Device.RuntimePlatform == Device.iOS && Device.Idiom == TargetIdiom.Tablet)
            {
                MasterPage.Title = width > height ? " " : "☰";
            }
        }

        private  void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (BindingContext is MainPageViewModel context && e.SelectedItem is MainMenuItem item)
            {
                var page = (ContentPage)Activator.CreateInstance(item.DestinationPage);
                page.BindingContext = Activator.CreateInstance(item.ViewModel);
                Detail = new NavigationPage(page);
                listView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}