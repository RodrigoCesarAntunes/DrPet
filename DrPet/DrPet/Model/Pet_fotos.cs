using System;
using System.Collections.Generic;
using System.Text;

namespace DrPet.Model
{
    public class Pet_fotos
    {
        public int Id { get; set; }
        public string FotoCaminho { get; set; }
        public int PetId { get; set; }

        public Pets Pet { get; set; }
    }
}
