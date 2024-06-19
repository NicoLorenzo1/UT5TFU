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
            Console.WriteLine("Cantidad de participantes cargados: " + participantsList.Count);
            if (participantsList.Count > 0)
            {
                Console.WriteLine("Primer participante: " + participantsList[0].FirstName + " " + participantsList[0].LastName);
            }
        }

private void LoadParticipantsList()
{
    try
    {
        Console.WriteLine("Intentando leer el archivo JSON...");
        var participants = JsonFileHandler.ReadFromJsonFile<Participant>("UT5TFU/Data/participants.json");
        
        if (participants != null && participants.Any())
        {
            participantsList.AddRange(participants);
            Console.WriteLine("Participantes cargados exitosamente:");
            foreach (var participant in participantsList)
            {
                //Console.WriteLine($"CI: {participant.CI}, Nombre: {participant.FirstName}, Apellido: {participant.LastName}");
            }
        }
        else
        {
            Console.WriteLine("No se encontraron participantes en el archivo JSON.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al leer el archivo JSON: {ex.Message}");
    }
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