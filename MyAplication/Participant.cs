using System;

namespace ProyectoUT5
{
    public class Participant : Person
    {
        public int Score { get; set; }

        public Participant(int ci, string password, string firstName, string lastName, int age, string genre, string country, string discipline)
            : base(ci, password, firstName, lastName, age, genre, country, discipline)
        {
            Score = 0;
        }

    }
}