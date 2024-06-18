using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ProyectoUT5
{
    public static class JsonFileHandler
    {
        public static void WriteToJsonFile<T>(string filePath, List<T> objectToWrite, bool append = false)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(objectToWrite, options);
            File.WriteAllText(filePath, jsonString);
        }

        public static List<T> ReadFromJsonFile<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }

            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(jsonString);
        }
    }
}
