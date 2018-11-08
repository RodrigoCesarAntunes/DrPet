using System;
using System.Collections.Generic;
using System.Text;

namespace DrPet.Model
{
    public class Cliente_pessoa
    {
        public Cliente_pessoa()
        {
            Consulta = new HashSet<Consulta>();
            Pets = new HashSet<Pets>();
        }

        public int Id { get; set; }
        public string UsuarioEmail { get; set; }

        public Usuario Usuario { get; set; }
        public ICollection<Consulta> Consulta { get; set; }
        public ICollection<Pets> Pets { get; set; }
    }
}
