using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Vehicles.Car;


[RequireComponent(typeof (CarController))]
public class Car : Vehicle
{
    public int geneFrameExpectancy;
    public int geneFrameAge;
    public Gene m_CurrentGene;
    private CarController m_Car; // the car controller we want to use

    private void Start()
    {
        this.geneFrameExpectancy = 2;
        // get the car controller
        m_Car = GetComponent<CarController>();
        m_CurrentGene = dna.GetNextGene();
    }
    void OnCollisionEnter(Collision collision)
    {
        Die();
    }
    public override void Die()
    {
        fitness = GetComponent<CarFitness>().GetFitness();
        base.Die();
        gameObject.SetActive(false);
        GameObject.FindObjectOfType<Population>().ReportDeath();
    }
    private void FixedUpdate()
    {
        if (dead) return;
        geneFrameAge++;
        if (geneFrameAge > geneFrameExpectancy)
        {
            geneFrameAge = 0;
            m_CurrentGene = dna.GetNextGene();
        }
        
        float acceleration = 0f;
        float footbrake = 0f;
        if (m_CurrentGene.v > 0)
            acceleration = 1;
        else
            footbrake = m_CurrentGene.v;
            
        m_Car.Move(m_CurrentGene.h, 1f, 0, 0);
    }
    internal void SetDNA(DNA dna)
    {
        this.dna = dna; 
    }
}