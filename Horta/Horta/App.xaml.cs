using System;
using Horta.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Horta
{
	public partial class App : Application
	{
		public App ()
		{
		    Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTMxOEAzMTM2MmUzMjJlMzBFQmpkSXFwQWpuMzhFQnl5VHpzNmlTZGsxMGhSVkROaFNCSTQ5ZklsQ3FNPQ==");
            InitializeComponent();
		    

            MainPage = new Login();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
