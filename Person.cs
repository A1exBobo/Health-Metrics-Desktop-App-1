using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassIndex_calculator
{
    internal class Person
    {
        public int Id { get; set; }   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherInitials { get; set; }

        public int Age { get; set; }

        public Person(string firstname,string lastname,string fatherinitials,int age) 
        {
           FirstName = firstname;
            LastName = lastname;
            FatherInitials = fatherinitials;
            Age = age;
        }

        public string FullName()
        {
            return $"{FirstName} {FatherInitials} {LastName}";
        }





    }
}
