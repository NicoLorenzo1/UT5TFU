using Newtonsoft.Json;
using ProyectoUT5.Handler;

namespace ProyectoUT5.Repository
{
    public class TablePointsRepository
    {
        private readonly string _filePath;


        private static TablePointsRepository instance;

        //Singleton instancia unica
        public static TablePointsRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TablePointsRepository();
                }

                return instance;
            }
        }
        public TablePointsRepository()
        {
            _filePath = "Data/showTablePoints.json";
        }



           public void SaveData(List<Participant> data)
        {
            try
            {
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(_filePath, json);
            }
            catch (IOException)
            {
                Console.WriteLine($"Error writing data to file {_filePath}.");
            }
        }

         public Dictionary<string, List<Participant>> GetPointsByDiscipline()
        {
            List<Participant> data = UserRepository.Instance.LoadParticipantsList();
            Dictionary<string, List<Participant>> disciplinePoints = new Dictionary<string, List<Participant>>();

            foreach (var participant in data)
            {
                if (!disciplinePoints.ContainsKey(participant.Discipline))
                {
                    disciplinePoints[participant.Discipline] = new List<Participant>();
                }
                disciplinePoints[participant.Discipline].Add(participant);
            }

            return disciplinePoints;
        }

        public Dictionary<string, List<Team>> GetTeamPointsByDiscipline()
        {
            List<Team> data = TeamRepository.Instance.GetData();
            Dictionary<string, List<Team>> disciplinePoints = new Dictionary<string, List<Team>>();

            foreach (var team in data)
            {
                if (!disciplinePoints.ContainsKey(team.Discipline))
                {
                    disciplinePoints[team.Discipline] = new List<Team>();
                }
                disciplinePoints[team.Discipline].Add(team);
            }
            return disciplinePoints;
        }

        public void UpdateScore(int ci, int score)
        {
            // Buscar al participante por CI
            List<Participant> data = UserRepository.Instance.LoadParticipantsList();
            Participant participant = data.FirstOrDefault(p => p.Ci == ci);

            if (participant != null)
            {
                participant.Score = score;
                SaveData(data);
                Console.WriteLine($"Puntaje actualizado para {participant.FirstName} {participant.LastName}. Nuevo puntaje: {score}");
            }
            else
            {
                Console.WriteLine($"No se encontró al participante con CI {ci}.");
            }
        }
    }
}
