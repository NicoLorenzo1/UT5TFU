using System.Collections.Generic;
using System.Linq;

namespace ProyectoUT5.Repository
{
    public class UserRepository 
    {
        private readonly List<Participant> participantsList = new List<Participant>();

         public UserRepository()
        {
            // Carga la lista desde el archivo JSON al inicializar UserRepository
            LoadParticipantsList();
        }

        private void LoadParticipantsList()
        {
            participantsList.AddRange(JsonFileHandler.ReadFromJsonFile<Participant>("Data/participants.json"));
        }

        public void AddParticipant(Participant participant)
        {
            participantsList.Add(participant);
            JsonFileHandler.WriteToJsonFile("Data/participants.json", participantsList);
        }

        public Participant GetUserByUsername(string firstName)
        {
            return participantsList.FirstOrDefault(u => u.FirstName == firstName);
        }
    }
}