using System;
using System.Collections.Generic;
using System.Text;

namespace DrPet.Model
{
    public class Services
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Nullable<decimal> Preco { get; set; }
        public int Cliente_Comercio_ID { get; set; }
        public string Cliente_Comercio_CNPJ { get; set; }
        public int Consulta_Consulta_ID { get; set; }

        public Cliente_comercio cliente_comercio { get; set; }
        public Consulta consulta { get; set; }
    }
}
