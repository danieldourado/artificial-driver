using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Vehicles.Car;


[RequireComponent(typeof (CarController))]
public class Car : Vehicle
{
    private CarController m_Car; // the car controller we want to use
    private Gene m_CurrentGene;
    public int geneFrameExpectancy = 60;
    private int geneFrameAge = 0;

    private void Start()
    {
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
        m_Car.Move(0, 0, 0, 0);
        fitness = GetComponent<CarFitness>().CalculateFitness();
        base.Die();
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
            acceleration = m_CurrentGene.v;
        else
            footbrake = m_CurrentGene.v;
            
        m_Car.Move(m_CurrentGene.h, acceleration, 0, 0);
    }
    internal void SetDNA(DNA dna)
    {
        this.dna = dna; 
    }
}