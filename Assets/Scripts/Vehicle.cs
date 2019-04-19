using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public DNA dna;
    public float fitness;
    public bool dead = false;

    public virtual void Die()
    {
        dead = true;
    }
}
