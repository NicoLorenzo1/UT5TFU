using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using ProyectoUT5.Repository;

namespace ProyectoUT5.Handler
{
    public static class JsonFileService
    {
        public static void WriteToJsonFile<T>(string filePath, List<T> objectToWrite, bool append = false)
        {
            var options = new JsonSerializerSettings { Formatting = Formatting.Indented };
            string jsonString = JsonConvert.SerializeObject(objectToWrite, options);
            File.WriteAllText(filePath, jsonString);
        }

        public static T ReadFromJsonFile<T>(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                throw;
            }
        }
    }
}
