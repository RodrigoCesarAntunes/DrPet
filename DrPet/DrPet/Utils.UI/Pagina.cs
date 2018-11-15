using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DrPet.Utils.UI
{
    public class Pagina
    {

        public NavigationPage GerarPaginaNavegacao(object pagina, Color corBarra, Color corTextoBarra)
        {
            return new NavigationPage(new ContentPage
            {
                Content = (ContentView)pagina
            })
            {
                BarBackgroundColor = corBarra,
                BarTextColor = corTextoBarra,
            };
        }
    }
}
