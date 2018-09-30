using System;
using System.Collections.Generic;
using System.Text;

namespace DrPet.Model
{
    public class Pets
    {
        public int Pet_ID { get; set; }
        public string Nome { get; set; }
        public string What_Pet { get; set; }
        public string Raca { get; set; }
        public string Peso { get; set; }
        public string Tamanho { get; set; }
        public string Descricao { get; set; }
        public string Genero { get; set; }
        public Nullable<int> Idade { get; set; }
        public int Cliente_pessoa_id { get; set; }
        public string Cliente_pessoa_cpf { get; set; }

        public virtual Cliente_pessoa Cliente_pessoa { get; set; }
        public virtual List<Consulta> Consulta { get; set; }
        public virtual List<Pet_fotos> Pet_fotos { get; set; }
    }
}
