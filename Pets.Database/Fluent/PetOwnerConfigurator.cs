using System.Data.Entity.ModelConfiguration;
using Pets.Models;

namespace Pets.Database.Fluent
{
    public sealed class PetOwnerConfigurator : EntityTypeConfiguration<PetOwner>
    {
        public PetOwnerConfigurator()
        {
            var petOwnerConfig = this;
            petOwnerConfig.HasKey(owner => owner.PetOwnerId);
            petOwnerConfig.Property(owner => owner.FirstName).IsRequired();
            petOwnerConfig.Property(owner => owner.LastName).IsRequired();
            petOwnerConfig.Property(owner => owner.Email).IsRequired();

            //petOwnerConfig.HasMany(owner => owner.Pets).WithOptional(pet => pet.Owner);
        }
    }
}
