using System;
using System.Collections.Generic;
using System.Text;

namespace DrPet.Model
{
    public class Cliente_comercio
    {

        public int ID { get; set; }
        public string CNPJ { get; set; }
        public int Usuario_ID { get; set; }
        public string Usuario_cpf_cnpj { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual List<Consulta> Consulta { get; set; }
        public virtual List<Services> Services { get; set; }
    }
}
