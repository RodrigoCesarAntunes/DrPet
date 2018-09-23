using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrPet.Views.PaginaInicial
{

    public class PaginaInicialMenuItem
    {
        public PaginaInicialMenuItem()
        {
            TargetType = typeof(PaginaInicialDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}