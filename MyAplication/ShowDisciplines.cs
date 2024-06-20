namespace ProyectoUT5
{
    public static class ShowDisciplies
    {


        public static void showDisciplies()
        {
            var repository = DisciplineRepository.Instance;
            List<Discipline> disciplines = repository.GetDisciplines() ?? new List<Discipline>();

            foreach (var discipline in disciplines)
            {

                Console.WriteLine($"Nombre: {discipline.Nombre}");

                if (discipline.Modalidades != null)
                {
                    foreach (var modality in discipline.Modalidades)
                    {
                        Console.WriteLine($"  Modalidad: {modality.Nombre}");

                        if (modality.Categorias != null)
                        {
                            foreach (var category in modality.Categorias)
                            {
                                Console.WriteLine($"    Categoría: {category.Nombre}");

                                if (category.Modalidades != null)
                                {
                                    Console.WriteLine($"    Modalidades: {string.Join(", ", category.Modalidades)}");
                                }

                                if (category.Opciones != null)
                                {
                                    Console.WriteLine($"    Opciones: {string.Join(", ", category.Opciones)}");
                                }
                            }
                        }
                    }
                }

                if (discipline.Categorias != null)
                {
                    foreach (var category in discipline.Categorias)
                    {
                        Console.WriteLine($"  Categoría: {category.Nombre}");

                        if (category.Opciones != null)
                        {
                            Console.WriteLine($"  Opciones: {string.Join(", ", category.Opciones)}");
                        }
                    }
                }

                Console.WriteLine();
            }
        }
    }
}