using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Horta2.Model;
using Syncfusion.XForms.PopupLayout;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Horta.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Lista : ContentPage
	{
	    private SfPopupLayout popupLayout;
        ObservableCollection<Planta> plantas = new ObservableCollection<Planta>();
	    List<Planta> plantas_ = new List<Planta>();
        DataTemplate footerTemplateView;
	    Label footerContent;

        public Lista ()
		{
			InitializeComponent ();
		    plantas.Add(new Planta { Nome = "Hortelã da Borda Branca", Imagem = "hortela.jpg", TempoRega = 6, UltimaRega = DateTime.Now.AddHours(-8) });
		    plantas.Add(new Planta { Nome = "Moringa", Imagem = "hortela.jpg", TempoRega = 12, UltimaRega = DateTime.Now.AddHours(-10) });
		    plantas.Add(new Planta { Nome = "Pimenta-Preta", Imagem = "hortela.jpg", TempoRega = 9, UltimaRega = DateTime.Now.AddHours(-8) });
		    plantas.Add(new Planta { Nome = "Erva-doce", Imagem = "hortela.jpg", TempoRega = 12, UltimaRega = DateTime.Now.AddHours(-15) });
		    plantas.Add(new Planta { Nome = "Boldo-do-chile", Imagem = "hortela.jpg", TempoRega = 12, UltimaRega = DateTime.Now.AddHours(-20) });
		    plantas.Add(new Planta { Nome = "Moringa", Imagem = "hortela.jpg", TempoRega = 12, UltimaRega = DateTime.Now.AddHours(-20) });
            plantas_ = plantas.ToList();
            ListaPlanta.ItemsSource = plantas;
            popupLayout = new SfPopupLayout();

		    footerTemplateView = new DataTemplate(() =>
		    {
		        footerContent = new Label();
		        footerContent.Text = "Confirmar";
		        footerContent.FontAttributes = FontAttributes.Bold;
		        footerContent.BackgroundColor = Color.FromHex("#38eab3");
		        footerContent.FontSize = 16;
		        footerContent.HorizontalTextAlignment = TextAlignment.Center;
		        footerContent.VerticalTextAlignment = TextAlignment.Center;
		        return footerContent;
		    });
		    popupLayout.PopupView.FooterTemplate = footerTemplateView;
		}

	    protected override void OnDisappearing()
	    {
	        base.OnDisappearing();
            
	    }

	    private Task task;

	    protected override async void OnAppearing()
	    {
	        base.OnAppearing();
	        Device.StartTimer(TimeSpan.FromSeconds(1), () => {

                
                    
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        
                        ListaPlanta.ItemsSource = null;
                        ListaPlanta.ItemsSource = plantas_;
                    });

	            return true;



	        });
        }

        

	    private void Button_OnClicked(object sender, EventArgs e)
	    {
	        popupLayout.Show();
	    }

	    private async void Regar_Clicked(object sender, EventArgs e)
	    {
            
	        var b = sender as Button;
	        var planta= b.CommandParameter as Planta;
	        if (await DisplayAlert("Confirmar", $"Confirmar a rega da {planta.Nome}?", "Confirmar", "Cancelar"))
	        {
	            planta.UltimaRega = DateTime.Now;
	            ListaPlanta.ItemsSource = null;
	            ListaPlanta.ItemsSource = plantas;
            }
            
	        
	    }

	    private void Entry_OnTextChanged(object sender, TextChangedEventArgs e)
	    {
	        ListaPlanta.ItemsSource = null;
	        plantas_ = plantas.Where(p => p.Nome.ToUpper().Contains(TxtBusca.Text.ToUpper())).ToList();
	        ListaPlanta.ItemsSource = plantas_;
	    }
	}
}