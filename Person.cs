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
            ValidateName(FirstName, "First Name", 2, 30);
            ValidateName(LastName, "Last Name", 2, 30);
            ValidateName(FatherInitials, "Father Initials", 1, 2);
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
            return char.ToUpper(name[0]) + name.Substring(1).ToLower();
        }


        public void ValidateName(string name, string fieldName, int minLength = 1, int maxLength = 50)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{fieldName} cannot be empty");

            if (name.Length < minLength || name.Length > maxLength)
                throw new ArgumentException($"{fieldName} must be between {minLength} and {maxLength} characters");

            if (!char.IsUpper(name[0]))
                throw new ArgumentException($"{fieldName} must start with a capital letter");

            if (name.Any(char.IsDigit))
                throw new ArgumentException($"{fieldName} must not contain numbers");
        }

    }
}
