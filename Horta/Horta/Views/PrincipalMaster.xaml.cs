using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Horta.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrincipalMaster : ContentPage
    {
        public ListView ListView;

        public PrincipalMaster()
        {
            InitializeComponent();

            BindingContext = new PrincipalMasterViewModel();
            ListView = MenuItemsListView;
        }

        class PrincipalMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<PrincipalMenuItem> MenuItems { get; set; }
            
            public PrincipalMasterViewModel()
            {
                MenuItems = new ObservableCollection<PrincipalMenuItem>(new[]
                {
                    new PrincipalMenuItem { Id = 0, Title = "Perfil" },
                    new PrincipalMenuItem { Id = 1, Title = "Regar" },
                    new PrincipalMenuItem { Id = 2, Title = "Ranking" },
                    new PrincipalMenuItem { Id = 3, Title = "Sair" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}