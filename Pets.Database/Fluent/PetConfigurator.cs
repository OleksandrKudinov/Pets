using System.Data.Entity.ModelConfiguration;
using Pets.Models;

namespace Pets.Database.Fluent
{
    public sealed class PetConfigurator : EntityTypeConfiguration<Pet>
    {
        public PetConfigurator()
        {
            var petConfig = this;
            petConfig.HasKey(pet => pet.PetId);
            petConfig.Property(pet => pet.Name).IsRequired();
            petConfig.Property(pet => pet.BirthDate).IsRequired().HasColumnType("datetime2");
            petConfig.Property(pet => pet.KindOfAnimal).IsRequired();

            petConfig.HasOptional(pet => pet.Owner).WithMany(petOwner => petOwner.Pets);
        }
    }
}