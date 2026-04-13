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

        public void FixNames()
        {
            FirstName = FixName(FirstName);
            LastName = FixName(LastName);
            FatherInitials = FixName(FatherInitials);
        }

        public void Validate()
        {
            ValidateName(FirstName);
            ValidateName(LastName);
            ValidateName(FatherInitials);
        }

        public string FullName()
        {
            return $"{FirstName} {FatherInitials} {LastName}";
        }


        public string FixName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return string.Empty;

            // remove digits
            name = new string(name.Where(c => !char.IsDigit(c)).ToArray());

            // trim spaces
            name = name.Trim();

            if (string.IsNullOrEmpty(name))
                return string.Empty;

            // capitalize first letter
            return char.ToUpper(name[0]) + name.Substring(1);
        }


        public void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty");

            if (!char.IsUpper(name[0]))
                throw new ArgumentException("Name must start with a capital letter");

            if (name.Any(char.IsDigit))
                throw new ArgumentException("Name must not contain numbers");
        }

    }
}
