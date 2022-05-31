using Person.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.ConsoleApp
{
    public class PersonHelper
    {
        public void GetPerson()
        {
            var PersonDb = new PersonDBContext();
            var PersonList=PersonDb.People.ToList();
            foreach (var person in PersonList)
            {
                Console.WriteLine($"{person.Id}\t {person.Name}\t {person.Phone}\t  {person.Address}\t {person.Date}");
            }
        }
    }
}
