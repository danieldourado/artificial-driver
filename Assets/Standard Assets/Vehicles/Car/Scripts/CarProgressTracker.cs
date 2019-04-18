using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarProgressTracker : MonoBehaviour
{

    private List<GameObject> gatesTriggered = new List<GameObject>();
    private ProgressTracker m_ProgressTracker;
    // Start is called before the first frame update
    void Start()
    {
        m_ProgressTracker = GameObject.FindObjectOfType<ProgressTracker>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private float GetProgressOnTrack()
    {
        return 0f;
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

    private float CalculateFitness()
    {
        return m_ProgressTracker.CalculateProgress(gatesTriggered, transform.position);
    }
}
