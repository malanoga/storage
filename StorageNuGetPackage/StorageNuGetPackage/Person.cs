using System;
using System.ComponentModel.DataAnnotations;

namespace StorageNuGetPackage
{
    public class Person
    {
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }

        [Range(13, 19)]
        public int Teenager { get; set; }
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