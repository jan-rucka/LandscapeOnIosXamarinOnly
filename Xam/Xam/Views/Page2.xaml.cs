using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page2 : ContentPage
    {
		public Page2()
		{
			InitializeComponent();
		}


        public void Destroy()
        {
            //homeListView.Behaviors.Clear();
        }

    }
}