
namespace ProyectoUT5
{
    public class ShowDisciplies
    {
        public ShowDisciplies()
        {

        }

        public void showDisciplies()
        {
            var repository = new DisciplineRepository();
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

/*
var repository = new DisciplineRepository();

            List<Discipline> disciplines = repository.GetDisciplines();

            if (disciplines.Count == 0)
            {
                Console.WriteLine("No disciplines found.");
            }

            foreach (var discipline in disciplines)
            {
                Console.WriteLine($"ID: {discipline.Id}");
                Console.WriteLine($"Nombre: {discipline.Nombre}");
                Console.WriteLine($"Descripción: {discipline.Descripcion}");

                if (discipline.Modalidades != null)
                {
                    foreach (var modality in discipline.Modalidades)
                    {
                        Console.WriteLine($"  Modalidad: {modality.Nombre}");
                        Console.WriteLine($"  Descripción: {modality.Descripcion}");

                        if (modality.Distancias != null)
                        {
                            Console.WriteLine($"  Distancias: {string.Join(", ", modality.Distancias)}");
                        }

                        if (modality.Categorias != null)
                        {
                            foreach (var category in modality.Categorias)
                            {
                                Console.WriteLine($"    Categoría: {category.Nombre}");
                                Console.WriteLine($"    Descripción: {category.Descripcion}");

                                if (category.Distancias != null)
                                {
                                    Console.WriteLine($"    Distancias: {string.Join(", ", category.Distancias)}");
                                }

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

            */