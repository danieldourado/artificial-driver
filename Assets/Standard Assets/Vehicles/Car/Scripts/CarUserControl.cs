using System;
using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections.Generic;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        private DNA m_CarDNA;
        private Gene m_CurrentGene;
        public int geneFrameExpectancy = 60;
        private int geneFrameAge = 0;
        private bool dead = false;

        private void Start()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            m_CarDNA = GetComponent<DNA>();
            m_CurrentGene = m_CarDNA.GetNextGene();
        }

        internal void Die()
        {
            m_Car.Move(0, 0, 0, 0);
            dead = true;
        }

        private void FixedUpdate()
        {
            if (dead) return;
            geneFrameAge++;
            if (geneFrameAge > geneFrameExpectancy)
            {
                geneFrameAge = 0;
                m_CurrentGene = m_CarDNA.GetNextGene();            
            }
            float acceleration = 0f;
            float footbrake = 0f;
            if (m_CurrentGene.v > 0)
                acceleration = m_CurrentGene.v;
            else
                footbrake = m_CurrentGene.v;
            
            m_Car.Move(m_CurrentGene.h, acceleration, 0, 0);
        }
    }
}
