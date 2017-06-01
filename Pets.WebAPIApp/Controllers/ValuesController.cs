using System;
using System.Data.Entity;
using System.Linq;
using Pets.Models;

namespace Pets.WebAPIApp.Controllers
{
    using Database;
    using System.Web.Http;

    public class OwnersController : ApiController
    {
        public IHttpActionResult GetValues()
        {
            using (var context = new PetsDbContext())
            {
                PetOwner[] owners = context.Owners
                    .Include(owner=>owner.Pets)
                    .ToArray();

                return Ok(owners);
            }
        }
    }

    public class PetsController : ApiController
    {
        public IHttpActionResult GetValues()
        {
            using (var context = new PetsDbContext())
            {
                Pet[] pets = context.Pets.Include(x=>x.Owner).ToArray();
                return Ok(pets);
            }
        }
    }
}
