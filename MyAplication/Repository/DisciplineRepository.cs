using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ProyectoUT5
{
    public class DisciplineRepository
    {
        private List<Discipline>? disciplines;
        private readonly string? filePath;

        private static DisciplineRepository instance;

        //Singleton instancia unica
        public static DisciplineRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DisciplineRepository();
                }

                return instance;
            }
        }

        public DisciplineRepository()
        {
            filePath = "Data/Disciplines.json";
            LoadFromJson(filePath);
        }

        private void LoadFromJson(string jsonFilePath)
        {
            try
            {
                if (File.Exists(jsonFilePath))
                {
                    var jsonData = File.ReadAllText(jsonFilePath);
                    var disciplineJson = JsonConvert.DeserializeObject<DisciplineJson>(jsonData);
                    disciplines = disciplineJson?.Disciplinas ?? new List<Discipline>();
                }
                else
                {
                    Console.WriteLine($"File not found: {jsonFilePath}");
                    disciplines = new List<Discipline>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                disciplines = new List<Discipline>();
            }
        }

        public List<Discipline>? GetDisciplines()
        {
            return disciplines;
        }
    }

    public class DisciplineJson
    {
        public List<Discipline>? Disciplinas { get; set; }
    }
}
