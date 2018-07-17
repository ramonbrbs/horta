using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Horta.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}

	    private async void Entrar_Clicked(object sender, EventArgs e)
	    {
	        Grd.Opacity = .5;
	        await Task.Delay(150);
	        Grd.Opacity = 1;
	        Application.Current.MainPage = new Principal();
	    }
	}
}