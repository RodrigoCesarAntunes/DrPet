using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DrPet.Utils
{
    public static class PilhaDeNavegacao
    {
        public static INavigation Navegacao { get; set; }

        public async static void PushPagina(Page pagina)
        {
            await Navegacao.PushAsync(pagina);
        }

        public async static void PushModalPagina(Page pagina)
        {
            await Navegacao.PushModalAsync(pagina);
        }

        public async static void PopPagina()
        {

        }

    }
}
