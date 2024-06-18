using System;

namespace ProyectoUT5
{
    public class Person 
    {
        public int Ci { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        
        public Person(int ci, string firstName, string lastName, int age, string genre, string country, string email)
        {
            Ci = ci;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Genre = genre;
            Country = country;
            Email = email;
        }
    }
}
