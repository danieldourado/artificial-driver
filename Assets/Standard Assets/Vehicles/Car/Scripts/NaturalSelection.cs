using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalSelection : MonoBehaviour
{
    private List<DNA> deadDNAList = new List<DNA>();
    private List<DNA> aliveDNAList = new List<DNA>();

    void Start()
    {
        aliveDNAList = GetComponent<CarSpawner>().DNAList;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void ReportDeath(DNA dna)
    {
        deadDNAList.Add(dna);
        if(deadDNAList.Count == aliveDNAList.Count)
        {
            Breed(deadDNAList);
        }
    }

    private void Breed(List<DNA> deadDNAList)
    {
        throw new NotImplementedException();
    }
}
