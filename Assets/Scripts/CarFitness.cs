using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFitness : MonoBehaviour
{

    private List<GameObject> gatesTriggered = new List<GameObject>();
    private ProgressTracker m_ProgressTracker;
    private int finishTime = 0;

    void Start()
    {
        m_ProgressTracker = GameObject.FindObjectOfType<ProgressTracker>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        StrategicGate tempGate = collider.gameObject.GetComponent<StrategicGate>();
        if (tempGate)
        {
            if (!gatesTriggered.Contains(tempGate.gameObject))
                gatesTriggered.Add(tempGate.gameObject);
        }
    }

    private void Update()
    {
        finishTime++;
    }

    public float GetFitness()
    {
        float recordDistance = m_ProgressTracker.CalculateProgress(gatesTriggered, transform.position);
        return CalculateFitness(finishTime, recordDistance, gatesTriggered.Count);
    }

    private float CalculateFitness(float finishTime, float recordDistance, int checkpoints)
    {
        //float fitness = (1 / finishTime * recordDistance);
        float fitness = recordDistance * recordDistance * checkpoints;
        fitness *= fitness;
        //Debug.Log(fitness.ToString());
        return fitness;
    }
}
