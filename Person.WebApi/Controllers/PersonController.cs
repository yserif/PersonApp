using Microsoft.AspNetCore.Mvc;
using Person.DB;
using Microsoft.EntityFrameworkCore.ChangeTracking;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Person.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<Person.DB.Person>> Get()
        {
            var PersonDb = new PersonDBContext();
            var PersonList = PersonDb.People.ToList();
            return Ok(PersonList);

            //return new string[] { "value1", "value2" };

        }


        [HttpGet("{id}")]
        public ActionResult<Person.DB.Person> Get(int id)
        {
            var PersonDb = new PersonDBContext();
            var person = PersonDb.People.Where(p => p.Id == id).FirstOrDefault();
            //var person = PersonDb.People.Where(p => p.Id == id || p.Name.Contains("A")).FirstOrDefault();
            if (person == null) return NotFound();

            return Ok(person);
        }


        [HttpPost()]
        public ActionResult<Person.DB.Person> Post(Person.DB.Person person)
        {
            var personDb = new PersonDBContext();
            var addedPerson = personDb.Add(person);
            personDb.SaveChanges();

            return Ok(addedPerson.Entity);
        }




        //--------------------------------------------
        ////// DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) // <-- Here it is
        {
            var PersonDb = new PersonDBContext();
            if (id == null)
            {
                return NotFound();
            }

            var person = PersonDb.People.FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            var removedPerson = PersonDb.Remove(person);
            //removed.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            PersonDb.SaveChanges();


            return Ok(person);
        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id) // <-- Here it is
        //{
        //    var user = await db.Users.FindAsync(id);
        //    db.Users.Remove(user);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}



        //// DELETE api/<PersonController>/5
        //[HttpDelete("{id}")]
        //public ActionResult<Person.DB.Person> DeletedPerson(int id)
        //{
        //    var PersonDb = new PersonDBContext();
        //    var deletedPerson = PersonDb.People.Remove(Where(p => p.Id == id));
        //    PersonDb.SaveChanges();
        //    return Ok(deletedPerson);
        //}


        //   ///GET api/<PersonController>/5
        //   [HttpGet("{id}")]
        //public string Get(int id)
        //   {
        //      return "value";
        //   }


        //// POST api/<PersonController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PersonController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PersonController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
