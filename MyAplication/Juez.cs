using System;
using ProyectoUT5.Repository;

namespace ProyectoUT5
{
    public class Juez : Person
    {
        public int Experience { get; set; }

        public Juez(int ci, string password, string firstName, string lastName, int age, string genre, string country, int experience, string discipline)
            : base(ci, password, firstName, lastName, age, genre, country, discipline)
        {
            Experience = experience;
        }
    }
}
