using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page3 : ContentPage
    {
		public Page3()
		{
			InitializeComponent();
		}


        public void Destroy()
        {
            //homeListView.Behaviors.Clear();
        }

    }
}