using System;
using System.Collections.Generic;
using System.Text;

namespace DrPet.Model.Token
{
    public class Token
    {
        public int ID { get; set; }
        public string TokenAcesso{ get; set; }
        public string DescricaoErro { get; set; }
        public DateTime DataValidade { get; set; }

    }
}
