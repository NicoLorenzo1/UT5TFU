using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ProyectoUT5;

namespace ProyectoUT5.Repository
{
    public class UserRepository
    {
        private List<Participant> participantsList = new List<Participant>();
        private List<Juez> juezList = new List<Juez>();
        private string filePath;
        private string juezFilePath;
        private static UserRepository instance;

        public static UserRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserRepository();
                }

                return instance;
            }
        }

        public UserRepository()
        {
            LoadJuezList();
            LoadParticipantsList();
            Console.WriteLine("datos cargados ##### " + participantsList.Count);
        }

        private void LoadParticipantsList()
        {
            try
            {
            filePath = "Data/participants.json";
                string jsonContent = File.ReadAllText(filePath);
                participantsList = JsonConvert.DeserializeObject<List<Participant>>(jsonContent); //deserializa el json en una lista de participantes
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo JSON: {ex.Message}");
            }
        }

        private void LoadJuezList()
        {
            try
            {
                juezFilePath = "Data/juezList.json";
                string jsonContent = File.ReadAllText(juezFilePath);
                juezList = JsonConvert.DeserializeObject<List<Juez>>(jsonContent); //deserializa el json en una lista de Jueces
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo JSON: {ex.Message}");
            }
        }

        public void AddParticipant(int ci, string password, string firstName, string lastName, int age, string genre, string country, string discipline)
        {
            // Verificar si el participante ya existe
            if (participantsList.Any(p => p.Ci == ci))
            {
                Console.WriteLine($"El participante con CI {ci} ya está registrado.");
                return;
            }

            Participant participant = new Participant(ci, password, firstName, lastName, age, genre, country, discipline);
            this.participantsList.Add(participant);
            string updatedJson = JsonConvert.SerializeObject(participantsList, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
            Console.WriteLine("Participante registrado exitosamente.");
        }

        public bool verifyCredentials(int ci, string password)
        {
            Participant participant = participantsList.FirstOrDefault(p => p.Ci == ci);
            if (participant != null && participant.Password == password)
            {
                Console.WriteLine("Inicio de sesión exitoso.");
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool LoginJuez(int ci, string password)
        {
            Juez juez = juezList.FirstOrDefault(j => j.Ci == ci);

            if (juez != null && juez.Password == password)
            {
                Console.WriteLine("Inicio de sesión exitoso.");
                return true;
            }
            else
            {
                return false;
            }
        }
            public bool IsJudge(int ci)
        {
            return juezList.Any(j => j.Ci == ci);
        }

        public Participant GetUserByCi(int ci)
        {
            return participantsList.FirstOrDefault(u => u.Ci == ci);
        }

        public List<Participant> GetParticipantsByDiscipline(string discipline)
        {
            var matchingParticipants = participantsList
                .Where(p => p.Discipline.Equals(discipline, StringComparison.OrdinalIgnoreCase))
                .ToList();
            
            return matchingParticipants;
        }
    }
}