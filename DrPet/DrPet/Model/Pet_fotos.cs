using System;
using System.Collections.Generic;
using System.Text;

namespace DrPet.Model
{
    public class Pet_fotos
    {
        public int id { get; set; }
        public string fotoCaminho { get; set; }
        public int pet_id { get; set; }

        public Pets pets { get; set; }
    }
}
