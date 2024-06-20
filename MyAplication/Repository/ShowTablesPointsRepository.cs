using Newtonsoft.Json;

namespace ProyectoUT5
{
    public class ShowTablePointsRepository
    {
        private readonly string _filePath;


        private static ShowTablePointsRepository instance;

        //Singleton instancia unica
        public static ShowTablePointsRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShowTablePointsRepository();
                }

                return instance;
            }
        }
        public ShowTablePointsRepository()
        {
            _filePath = "Data/showTablePoints.json";
        }

        public List<Participant> GetData()
        {
            try
            {
                string json = File.ReadAllText(_filePath);
                List<Participant> participants = JsonConvert.DeserializeObject<List<Participant>>(json);
                return participants;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File {_filePath} not found.");
                return new List<Participant>();
            }
            catch (JsonException)
            {
                Console.WriteLine($"Error decoding JSON from file {_filePath}.");
                return new List<Participant>();
            }
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
    }
}