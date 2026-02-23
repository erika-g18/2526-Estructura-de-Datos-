using System;
using System.Collections.Generic;
using System.Linq;

class ProgramaVacunacion
{
    static void Main()
    {
        // 1. Generar 500 ciudadanos ficticios
        var ciudadanos = new List<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add($"Ciudadano {i}");
        }

        // 2. Crear conjuntos de vacunados con Pfizer y AstraZeneca (aleatorios)
        var rnd = new Random();
        var vacunadosPfizer = new HashSet<string>();
        var vacunadosAstraZeneca = new HashSet<string>();

        // Selección aleatoria de 75 ciudadanos para Pfizer
        while (vacunadosPfizer.Count < 75)
        {
            int index = rnd.Next(ciudadanos.Count);
            vacunadosPfizer.Add(ciudadanos[index]);
        }

        // Selección aleatoria de 75 ciudadanos para AstraZeneca
        while (vacunadosAstraZeneca.Count < 75)
        {
            int index = rnd.Next(ciudadanos.Count);
            vacunadosAstraZeneca.Add(ciudadanos[index]);
        }

        // 3. Operaciones de teoría de conjuntos
        var noVacunados = ciudadanos.Except(vacunadosPfizer.Union(vacunadosAstraZeneca)).ToList();
        var ambasDosis = vacunadosPfizer.Intersect(vacunadosAstraZeneca).ToList();
        var soloPfizer = vacunadosPfizer.Except(vacunadosAstraZeneca).ToList();
        var soloAstraZeneca = vacunadosAstraZeneca.Except(vacunadosPfizer).ToList();

        // 4. Mostrar resultados con salto de línea por ciudadano
        Console.WriteLine("=== Ciudadanos NO vacunados ===");
        foreach (var c in noVacunados) Console.WriteLine(c);

        Console.WriteLine("\n=== Ciudadanos con ambas dosis ===");
        foreach (var c in ambasDosis) Console.WriteLine(c);

        Console.WriteLine("\n=== Ciudadanos SOLO Pfizer ===");
        foreach (var c in soloPfizer) Console.WriteLine(c);

        Console.WriteLine("\n=== Ciudadanos SOLO AstraZeneca ===");
        foreach (var c in soloAstraZeneca) Console.WriteLine(c);
    }
}