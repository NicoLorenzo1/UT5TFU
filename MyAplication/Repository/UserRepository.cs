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


        public UserRepository()
        {
            
            LoadParticipantsList();
            LoadJuezList();
        }

        private void LoadParticipantsList()
        {
            try
            {
            filePath = "Data/participants.json";
                string jsonContent = File.ReadAllText(filePath);
                var participantsList = JsonConvert.DeserializeObject<List<Participant>>(jsonContent); //deserializa el json en una lista de participantes
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

        public void RegisterParticipant(int ci, string password, string firstName, string lastName, int age, string genre, string country)
        {
            // Verificar si el participante ya existe
            if (participantsList.Any(p => p.Ci == ci))
            {
                Console.WriteLine($"El participante con CI {ci} ya está registrado.");
                return;
            }

            Participant participant = new Participant(ci, password, firstName, lastName, age, genre, country);
            AddParticipant(participant);
            Console.WriteLine("Participante registrado exitosamente.");
        }

        public bool LoginParticipant(int ci, string password)
        {
            Participant participant = participantsList.FirstOrDefault(p => p.Ci == ci);
            if (participant != null && participant.Password == password)
            {
                Console.WriteLine("Inicio de sesión exitoso.");
                return true;
            }
            else
            {
                Console.WriteLine("CI o contraseña incorrecta.");
                return false;
            }
        }

        public bool LoginJuez(int ci, string password)
        {
            Juez juez = juezList.FirstOrDefault(j => j.Ci == ci);

            Console.WriteLine(juezList.Count);

            if (juez != null && juez.Password == password)
            {
                Console.WriteLine("Inicio de sesión exitoso.");
                return true;
            }
            else
            {
                Console.WriteLine("CI o contraseña incorrecta.");
                return false;
            }
        }
        public void AddParticipant(Participant participant)
        {
            filePath = "Data/participants.json";
            
            // Cargar la lista de participantes desde el archivo JSON si existe
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                participantsList = JsonConvert.DeserializeObject<List<Participant>>(json);
            }

            participantsList.Add(participant);

            string updatedJson = JsonConvert.SerializeObject(participantsList, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }

        public void AddJuez(Juez juez)
        {
            juezFilePath = "Data/juezList.json";
            juezList.Add(juez);
            JsonFileHandler.WriteToJsonFile(filePath, juezList);
        }

            public bool IsJudge(int ci)
        {
            return juezList.Any(j => j.Ci == ci);
        }

        public Participant GetUserByUsername(string firstName)
        {
             Console.WriteLine("Buscando usuario con nombre: " + firstName);
            return participantsList.FirstOrDefault(u => u.FirstName == firstName);
        }

    }
}