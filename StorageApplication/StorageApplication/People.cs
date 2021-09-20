using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageApplication
{
    public static class People
    {


        public static List<Person> DefaultList { get; set; } = new List<Person>();
        public static string AddPerson(Person person)
        {
            DefaultList.Add(person);
            return "Person Successfuly added";
        }
        public static Person GetPersonByName(string name)
        {
            return GetPeople().Where(x => x.Name == name).FirstOrDefault();
        }
        public static List<Person> AllPeople()
        {

            List<Person> list = new List<Person>();
            list.AddRange(GetPeople());
            list.AddRange(DefaultList);
            return list;
        }

        public static List<Person> GetPeople()
        {
            List<Person> list = new List<Person>();
            list.Add(new Person("Adis", "Sertovic", DateTime.Parse("1985-10-09"), "backend"));
            list.Add(new Person("Emir", "Pajic", DateTime.Parse("1996-10-13"), "full stack"));
            list.Add(new Person("Mirza", "Krzic", DateTime.Parse("1985-09-10"), "fontend"));
            list.Add(new Person("Armin", "Comic", DateTime.Parse("1985-09-10"), "full stack system master"));
            list.Add(new Person("Miralem", "Avdic", DateTime.Parse("1985-09-10"), "fontend"));
            return list;
        }
    }
}
