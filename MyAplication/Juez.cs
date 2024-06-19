using System;

namespace ProyectoUT5
{
    public class Juez : Person
    {
        public int Experience { get; set; }
        public string Discipline { get; set; }

        public Juez(int ci, string password, string firstName, string lastName, int age, string genre, string country, int experience, string discipline)
            : base(ci, password, firstName, lastName, age, genre, country)
        {
            Experience = experience;
            Discipline = discipline;
        }

        public void insertPoints(int participantCi, int points)
        {
            // Logica para ingresar puntos del participante 
        }
    }
}
