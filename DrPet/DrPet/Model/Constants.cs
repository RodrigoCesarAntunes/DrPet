﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace DrPet.Model
{
    public class Constants
    {
        bool isDev = true;
        public static string URI = "http://192.168.15.11:45455/api/PessoaFisica";

        public static Color BackGroundColor = Color.FromRgb(20,100,100);
        public static Color MainTextColor = Color.FromRgb(0,0,0);

        public static int loginIconHeight = 120;
    }
}