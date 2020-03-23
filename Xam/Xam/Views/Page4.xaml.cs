using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page4 : ContentPage
    {
		public Page4()
		{
			InitializeComponent();
		}


        public void Destroy()
        {
            //homeListView.Behaviors.Clear();
        }

    }
}