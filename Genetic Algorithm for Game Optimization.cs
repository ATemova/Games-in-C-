using System;
using System.Collections.Generic;
using System.Linq;

public class GeneticAlgorithm
{
    private static readonly Random Random = new Random();

    public static List<int> GeneratePopulation(int size, int length)
    {
        return Enumerable.Range(0, size).Select(_ => Random.Next(0, length)).ToList();
    }

    public static List<int> Crossover(List<int> parent1, List<int> parent2)
    {
        int point = Random.Next(1, parent1.Count - 1);
        var child = new List<int>();
        child.AddRange(parent1.Take(point));
        child.AddRange(parent2.Skip(point));
        return child;
    }

    public static void Mutate(List<int> individual)
    {
        int index = Random.Next(individual.Count);
        individual[index] = Random.Next(0, 100);
    }
}
