using System;
using ProyectoUT5.Repository;
using ProyectoUT5.Handler;


namespace ProyectoUT5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola, Mundo!");
            MenuHandler menu = new MenuHandler();
            menu.ShowMenu();


        }
    }

}
