using System;
using System.Collections.Generic;

namespace Pets.Models
{
    public class PetOwner
    {
        public Int32 PetOwnerId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}