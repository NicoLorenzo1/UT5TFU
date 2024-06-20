using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ProyectoUT5;

namespace ProyectoUT5.Repository
{
    public class TeamRepository
    {
        private List<Participant> participantsList = new List<Participant>();
        private List<Team> TeamList = new List<Team>();
        private string filePath;
        private static TeamRepository instance;

        //Singleton instancia unica
        public static TeamRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TeamRepository();
                }

                return instance;
            }
        }

        public TeamRepository()
        {
            this.participantsList = UserRepository.Instance.LoadParticipantsList();
            LoadTeamList();
        }

        private void LoadTeamList()
        {
            try
            {
            filePath = "Data/team.json";
                string jsonContent = File.ReadAllText(filePath);
                TeamList = JsonConvert.DeserializeObject<List<Team>>(jsonContent); //deserializa el json en una lista de Team
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo JSON: {ex.Message}");
            }
        }

        public void AddParticipant(int ci, string equipo){
            //busco participante por ci
            Participant participant = participantsList.Find(p => p.Ci == ci);
        
            // Busco el equipo por nombre
            Team team = TeamList.Find(t => t.TeamName.Equals(equipo, StringComparison.OrdinalIgnoreCase));
            if (team == null)
            {
                Console.WriteLine("Equipo no encontrado.");
                return;
            }
            team.Participants.Add(participant);

            JsonFileHandler.WriteToJsonFile("Data/team.json", TeamList);
            Console.WriteLine("Participante agregado al equipo con éxito.");
        }

    }
}