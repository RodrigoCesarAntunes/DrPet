using System;
using System.Collections.Generic;
using System.Text;

namespace DrPet.Model
{
    public class Consulta
    {
        public int Consulta_ID { get; set; }
        public Nullable<System.DateTime> Data_Hora { get; set; }
        public Nullable<bool> Is_Valida { get; set; }
        public int Cliente_Comercio_id { get; set; }
        public string Cliente_Comercio_cnpj { get; set; }
        public Nullable<decimal> Preco { get; set; }
        public int Pets_pet_ID { get; set; }
        public Nullable<bool> IsCancelada { get; set; }
        public string QuemCancelou { get; set; }
        public string Motivo { get; set; }

        public virtual Cliente_comercio Cliente_Comercio { get; set; }
        public virtual Pets Pets { get; set; }
        public virtual List<Services> Services { get; set; }
    }
}
