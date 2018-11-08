using System;
using System.Collections.Generic;
using System.Text;

namespace DrPet.Model
{
    public class Cliente_comercio
    {

        public Cliente_comercio()
        {
            Consulta = new HashSet<Consulta>();
            Services = new HashSet<Services>();
        }

        public int Id { get; set; }
        public decimal? SaldoEmConta { get; set; }
        public string UsuarioEmail { get; set; }

        public Usuario Usuario { get; set; }
        public ICollection<Consulta> Consulta { get; set; }
        public ICollection<Services> Services { get; set; }
    }
}
