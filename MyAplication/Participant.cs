using System;

namespace ProyectoUT5
{
    public class Participant : Person
    {
        
        public Participant(int ci, string password, string firstName, string lastName, int age, string genre, string country)
            : base(ci, password, firstName, lastName, age, genre, country)
        {

        }

        public void insertPoints(int participantCi, int points){
            //logica ingresar puntos del participante 
        }
    }
}