using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DNA
{
    public int ammountOfGenes = 30*60;
    public List<Gene> genes = new List<Gene>();

    private int m_GeneCounter = 0;
    public DNA()
    {
        for(int i=0; i<ammountOfGenes; i++)
        {
            genes.Add(new Gene());
        }
    }

    public Gene GetNextGene()
    {
        Gene gene = genes[m_GeneCounter];

        if (m_GeneCounter < genes.Count-1)
            m_GeneCounter++;

        /*
        Debug.Log(
            "Gene Counter: " + m_GeneCounter.ToString()
            +" H:"+ gene.h.ToString()
            + " V:" + gene.v.ToString()
            );
        */
        return gene;
    }

    internal DNA Crossover(DNA partner)
    {
        List<Gene> child = new List<Gene>();

        int crossover = Random.Range(0, genes.Count-1);

        for(int i=0; i<genes.Count-1; i++)
        {
            if (i > crossover)
                child.Add(genes[i]);
            else
                child.Add(partner.genes[i]);
        }

        DNA newDNA = new DNA();
        newDNA.genes = child;
        return newDNA;
    }

    internal void Mutate(float m)
    {
        for (int i =0; i<genes.Count-1; i++)
        {
            if (Random.Range(0f,1f) < m)
            {
                genes[i] = new Gene();
            }
        }
    }
}
