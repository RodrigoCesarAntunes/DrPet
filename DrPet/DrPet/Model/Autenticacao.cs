using System;
using System.Collections.Generic;
using System.Text;

namespace DrPet.Model
{
    public class Autenticacao
    {
        public int ID { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }

        
        public Usuario Usuario { get; set; }
    }
}
