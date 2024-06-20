using Newtonsoft.Json;

namespace ProyectoUT5
{
    public class ShowTablePointsRepository
    {
        private readonly string _filePath;

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
                Console.WriteLine("Data saved successfully.");
            }
            catch (IOException)
            {
                Console.WriteLine($"Error writing data to file {_filePath}.");
            }
        }
    }
}