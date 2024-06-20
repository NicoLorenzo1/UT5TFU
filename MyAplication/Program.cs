using System;
using ProyectoUT5.Repository;

namespace ProyectoUT5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola, Mundo!");
            Menu menu = new Menu();
            //menu.ShowMenu();
            ShowTablePointsRepository repository = new ShowTablePointsRepository();
            ShowTablePoints showPoints = new ShowTablePoints(repository);
            showPoints.DisplayPointsTable();

        }
    }

}
