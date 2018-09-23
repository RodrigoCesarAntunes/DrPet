using System;
using System.Collections.Generic;
using System.Text;

namespace DrPet.Model
{
    public class Usuario
    {


        public int id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string Celular { get; set; }
        public Nullable<int> Idade { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string Foto { get; set; }


        public Autenticacao Autenticacao { get; set; }
        public List<Cliente_comercio> Cliente_comercio { get; set; }
        public List<Cliente_pessoa> Cliente_pessoa { get; set; }
        public List<Pagamento> Pagamento { get; set; }
    }
}
