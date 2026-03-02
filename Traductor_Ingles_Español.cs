using System;
using System.Collections.Generic;
using System.Linq;

class Traductor
{
    static void Main(string[] args)
    {
        // Diccionario Español -> Inglés
        Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"tiempo", "time"},
            {"persona", "person"},
            {"año", "year"},
            {"día", "day"},
            {"cosa", "thing"},
            {"hombre", "man"},
            {"mundo", "world"},
            {"vida", "life"},
            {"mano", "hand"},
            {"parte", "part"},
            {"niño", "child"},
            {"ojos", "eye"},
            {"mujer", "woman"},
            {"lugar", "place"},
            {"trabajo", "work"},
            {"semana", "week"},
            {"caso", "case"},
            {"punto", "point"},
            {"gobierno", "government"},
            {"empresa", "company"}
        };

        int opcion;

        do
        {
            Console.WriteLine("==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            opcion = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (opcion)
            {
                case 1:
                    TraducirFrase(diccionario);
                    break;

                case 2:
                    AgregarPalabra(diccionario);
                    break;

                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            Console.WriteLine();

        } while (opcion != 0);
    }

    static void TraducirFrase(Dictionary<string, string> diccionario)
    {
        Console.Write("Ingrese la frase: ");
        string frase = Console.ReadLine();

        string[] palabras = frase.Split(' ');
        List<string> resultado = new List<string>();

        foreach (string palabra in palabras)
        {
            string limpia = palabra.Trim(',', '.', ';', ':', '¡', '!', '¿', '?');

            if (diccionario.ContainsKey(limpia.ToLower()))
            {
                resultado.Add(diccionario[limpia.ToLower()]);
            }
            else
            {
                resultado.Add(palabra);
            }
        }

        Console.WriteLine("Traducción: " + string.Join(" ", resultado));
    }

    static void AgregarPalabra(Dictionary<string, string> diccionario)
    {
        Console.Write("Ingrese la palabra en Español: ");
        string espanol = Console.ReadLine().ToLower();

        Console.Write("Ingrese la traducción en Inglés: ");
        string ingles = Console.ReadLine().ToLower();

        if (!diccionario.ContainsKey(espanol))
        {
            diccionario.Add(espanol, ingles);
            Console.WriteLine("Palabra agregada correctamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }
}