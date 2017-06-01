using System;
using System.Data.Entity;
using Pets.Models;

namespace Pets.Database
{
    public class PetsDbContext : DbContext
    {
        public PetsDbContext(String nameOrConnectionString) : base(nameOrConnectionString)
        {
            System.Data.Entity.Database.SetInitializer(new PetDbInit());
        }

        public PetsDbContext(): this("Data Source=DESKTOP-K21PL9C\\MSSQLSERVER2016;Initial Catalog=Pets;Integrated Security=True")
        {
            
        }

        public DbSet<PetOwner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        class PetDbInit : DropCreateDatabaseIfModelChanges<PetsDbContext>
        //class PetDbInit : DropCreateDatabaseAlways<PetsDbContext>
        {
            protected override void Seed(PetsDbContext context)
            {
                var pet1 = new Pet()
                {
                    BirthDate = DateTime.Now,
                    KindOfAnimal = "Cat",
                    Name = "Mircella",
                };

                var owner1 = new PetOwner()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                };

                var pet2 = new Pet()
                {
                    BirthDate = DateTime.Now,
                    KindOfAnimal = "Dog",
                    Name = "Mircella",
                };

                var owner2 = new PetOwner()
                {
                    FirstName = "Alice",
                    LastName = "Vens",
                    Email = "alice.vens@example.com",
                    Pets = new Pet[] {pet2}
                };
                pet2.Owner = owner2;


                context.Pets.Add(pet1);
                context.Owners.Add(owner1);
                context.Owners.Add(owner2);
                context.SaveChanges();

                base.Seed(context);
            }
        }
    }
}
