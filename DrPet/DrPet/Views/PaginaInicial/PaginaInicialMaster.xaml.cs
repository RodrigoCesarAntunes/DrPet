using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using DrPet.Controller.Login;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DrPet.Views.PaginaInicial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaInicialMaster : ContentPage
    {
        public ListView ListView;

        public PaginaInicialMaster()
        {
            InitializeComponent();

            BindingContext = new PaginaInicialMasterViewModel();
            ListView = MenuItemsListView;
            lblUsuario.Text = Login.UsuarioAtivo.Usuario.Nome;
            IconeUsuario.HeightRequest = DrPet.Model.Constants.loginIconHeight;
        }

        class PaginaInicialMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<PaginaInicialMenuItem> MenuItems { get; set; }
            
            public PaginaInicialMasterViewModel()
            {
                
                MenuItems = new ObservableCollection<PaginaInicialMenuItem>(new[]
                {
                    new PaginaInicialMenuItem { Id = 0, Title = "Pagina Inicial" },
                    new PaginaInicialMenuItem { Id = 1, Title = "Meus Pets" },
                    new PaginaInicialMenuItem { Id = 2, Title = "Consultas" },
                    new PaginaInicialMenuItem { Id = 3, Title = "Configurações" },
                    new PaginaInicialMenuItem { Id = 4, Title = "Sobre" },
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