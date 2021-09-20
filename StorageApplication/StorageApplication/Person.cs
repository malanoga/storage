using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageApplication
{
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Agre { get; set; }
        public string ProgrammingOrientation { get; set; }

        public Person()
        {
        }

        public Person(string name, string lastName, DateTime agre, string programmingOrientation)
        {
            Name = name;
            LastName = lastName;
            Agre = agre;
            ProgrammingOrientation = programmingOrientation;
        }
    }
}
