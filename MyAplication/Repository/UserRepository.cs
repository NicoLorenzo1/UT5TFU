using System.Collections.Generic;
using System.Linq;
using ProyectoUT5;

namespace ProyectoUT5.Repository
{
    public class UserRepository 
    {
        private readonly List<Participant> participantsList = new List<Participant>();

         public UserRepository()
        {
            // Carga la lista desde el archivo JSON al inicializar UserRepository
            LoadParticipantsList();
            Console.WriteLine(participantsList[1] + "prueba");
        }

        private void LoadParticipantsList()
        {
            participantsList.AddRange(JsonFileHandler.ReadFromJsonFile<Participant>("UT5TFU/Data/participants.json"));
        }

        public void AddParticipant(Participant participant)
        {
            participantsList.Add(participant);
            JsonFileHandler.WriteToJsonFile("Data/participants.json", participantsList);
        }

        public Participant GetUserByUsername(string firstName)
        {
             Console.WriteLine("Buscando usuario con nombre: " + firstName);
            return participantsList.FirstOrDefault(u => u.FirstName == firstName);
        }
    }
}