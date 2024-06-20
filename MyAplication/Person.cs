using System;

namespace ProyectoUT5
{
    public class Person 
    {
        public int Ci { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }
        public string Discipline { get; set; }
        
        public Person(int ci, string password, string firstName, string lastName, int age, string genre, string country, string discipline)
        {
            Ci = ci;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Genre = genre;
            Country = country;
            Discipline = discipline;
        }
    }
}
