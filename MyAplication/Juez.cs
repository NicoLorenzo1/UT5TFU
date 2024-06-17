using System;

namespace ProyectoUT5
{
    public class Juez : Person
    {
        public int Experience { get; set; }
        public string Discipline { get; set; }

        public Juez(int ci, string firstName, string lastName, int age, string genre, string country, string email, int experience, string discipline)
            : base(ci, firstName, lastName, age, genre, country, email)
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
