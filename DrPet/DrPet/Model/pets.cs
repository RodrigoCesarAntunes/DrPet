using System;
using System.Collections.Generic;
using System.Text;

namespace DrPet.Model
{
    public class Pets
    {

        public Pets()
        {
            PetFotos = new HashSet<Pet_fotos>();
        }

        public int PetId { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public string Peso { get; set; }
        public string Tamanho { get; set; }
        public string Descricao { get; set; }
        public string Genero { get; set; }
        public string Idade { get; set; }
        public string ClientePessoaEmail { get; set; }

        public Cliente_pessoa ClientePessoa { get; set; }
        public ICollection<Pet_fotos> PetFotos { get; set; }
    }
}
