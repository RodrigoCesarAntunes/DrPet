using System;
using System.Collections.Generic;
using System.Text;

namespace DrPet.Model
{
    public class Cliente_pessoa
    {

        public int ID { get; set; }
        public int Usuario_ID { get; set; }
        public string Usuario_Email { get; set; }

        public  Usuario Usuario { get; set; }
        public virtual List<Pets> pets { get; set; }
    }
}
