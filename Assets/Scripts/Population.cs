using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population : MonoBehaviour
{
    public float mutationRate;
    public Car[] population;
    public List<Car> matingPool;
    public int generations;
    public GameObject vehiclePrefab;
    public int populationSize = 10;


    private void Start()
    {
        population = new Car[populationSize];
        matingPool = new List<Car>();
        generations = 0;

        for (int i = 0; i < populationSize; i++)
        {
            population[i] = InstantiateNewVehicle(vehiclePrefab);
        }
    }

    internal void ReportDeath()
    {
        foreach(Car tempCar in population)
        {
            if (tempCar.dead == false)
                return;
        }
        Selection();
        Reproduction();

    }
    // Generate a mating pool
    void Selection()
    {
        matingPool.Clear();

        // Calculate total fitness of whole population
        float maxFitness = GetMaxFitness();

        // Calculate fitness for each member of the population (scaled to value between 0 and 1)
        // Based on fitness, each member will get added to the mating pool a certain number of times
        // A higher fitness = more entries to mating pool = more likely to be picked as a parent
        // A lower fitness = fewer entries to mating pool = less likely to be picked as a parent
        for (int i = 0; i < population.Length; i++)
        {
            float fitnessNormal = population[i].fitness.Map(0, maxFitness, 0, 1);
            int n = (int)(fitnessNormal * 100);
            for (int j = 0; j < n; j++)
            {
                matingPool.Add(population[i]);
            }
        }
    }


    void Reproduction()
    {
        for (int i = 0; i < population.Length; i++)
        {
            int m = Random.Range(0, matingPool.Count - 1);
            int d = Random.Range(0, matingPool.Count - 1);

            DNA mom = matingPool[m].dna;
            DNA dad = matingPool[d].dna;

            DNA child = mom.Crossover(dad);
            child.Mutate(mutationRate);

            Destroy(population[i].gameObject);

            population[i] = InstantiateNewVehicle(vehiclePrefab, child);
        }
    }

    public Car InstantiateNewVehicle(GameObject prefab)
    {
        GameObject vehicle = GameObject.Instantiate(prefab);
        vehicle.transform.SetParent(transform);
        return vehicle.GetComponent<Car>();
    }
    public Car InstantiateNewVehicle(GameObject prefab, DNA dna)
    {
        Car vehicle = InstantiateNewVehicle(prefab);
        vehicle.SetDNA(dna);
        return vehicle;
    }

    private float GetMaxFitness()
    {
        float record = 0;
        for (int i = 0; i < population.Length; i++)
        {
            if (population[i].fitness > record)
            {
                record = population[i].fitness;
            }
        }
        return record;
    }
}
