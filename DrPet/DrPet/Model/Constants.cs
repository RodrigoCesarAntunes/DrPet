using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Forms;
namespace DrPet.Model
{
    public class Constants
    {
        bool isDev = true;
        public static string URIPessoaFisica = "http://191.252.92.130:8888/api/Usuarios";
        public static string URIPet = "http://191.252.92.130:8888/api/Pets";
        //private static CancellationTokenSource cts = new CancellationTokenSource();

        public static Color BackGroundColor = Color.DarkGray;
        public static Color MainTextColor = Color.FromRgb(0,0,0);

        public static int loginIconHeight = 120;

    }
}
