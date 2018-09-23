using System;
using System.Collections.Generic;
using System.Text;

namespace DrPet.Model
{
    public class Pagamento
    {
        public int id_payment { get; set; }
        public string card_number { get; set; }
        public string card_owner { get; set; }
        public Nullable<System.DateTime> expire_date { get; set; }
        public string four_digits { get; set; }
        public int usuario_id { get; set; }
        public string usuario_cpf_cnpj { get; set; }

        public virtual Usuario usuario { get; set; }
    }
}
