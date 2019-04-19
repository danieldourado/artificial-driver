using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA : MonoBehaviour
{
    public int ammountOfGenes = 1000;
    public List<Gene> genes = new List<Gene>();

    private int m_GeneCounter = 0;
    void Awake()
    {
        for(int i=0; i<ammountOfGenes; i++)
        {
            genes.Add(GetNewGeneBasedOnAnotherOne(new Gene()));
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

    public Gene GetNewGeneBasedOnAnotherOne(Gene geneToBeBased)
    {
        Gene newGene = new Gene();

        newGene.h += geneToBeBased.h;
        newGene.v += geneToBeBased.v;
        newGene.handbrake += geneToBeBased.handbrake;
        newGene.ClampValues();
        return newGene;
    }
}
