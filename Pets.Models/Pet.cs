using System;

namespace Pets.Models
{
    public class Pet
    {
        public Int32 PetId { get; set; }
        public PetOwner Owner { get; set; }
        public String Name { get; set; }
        public DateTime BirthDate { get; set; }
        public String KindOfAnimal { get; set; }
    }
}
