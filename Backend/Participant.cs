using System;

namespace ProyectoUT5
{
    public class participant : Person
    {

        public Juez(int ci, string firstName, string lastName, int age, string genre, string country, string email)
            : base(ci, firstName, lastName, age, genre, country, email)
        {
            
        }

        public void insertPoints(int participantCi, int points){
            //logica ingresar puntos del participante 
        }
    }
}