using System.Collections.Generic;
using System.Linq;
using ProyectoUT5;

namespace ProyectoUT5
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
            var participant = participantsList.FirstOrDefault(u => u.FirstName == firstName);
            if (participant == null)
            {
                throw new KeyNotFoundException($"No participant found with first name {firstName}");
            }
            return participant;
        }

    }
}