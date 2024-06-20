namespace ProyectoUT5
{
    public static class ScoreHandler
    {
        public static void UpdateScore()
        {
            // Solicita el CI del participante
            Console.WriteLine("Ingrese el CI del participante:");
            if (int.TryParse(Console.ReadLine(), out int ci))
            {
                // Solicita el nuevo puntaje del participante
                Console.WriteLine("Ingrese el nuevo puntaje:");
                if (int.TryParse(Console.ReadLine(), out int newScore))
                {
                    // Actualiza el puntaje del participante utilizando la instancia de TablePoints
                    TablePoints.Instance.UpdateScore(ci, newScore);
                }
                else
                {
                    // Mensaje de error si el puntaje ingresado no es válido
                    Console.WriteLine("Puntaje inválido.");
                }
            }
            else
            {
                // Mensaje de error si el CI ingresado no es válido
                Console.WriteLine("CI inválido.");
            }
        }
    }
}