using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFitness : MonoBehaviour
{

    private List<GameObject> gatesTriggered = new List<GameObject>();
    private ProgressTracker m_ProgressTracker;

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

    public float CalculateFitness()
    {
        return m_ProgressTracker.CalculateProgress(gatesTriggered, transform.position);
    }
}
