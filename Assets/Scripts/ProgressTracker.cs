using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    private float m_TotalDistance = 0;
    void Start()
    {
        List<GameObject> gates = GetAllChildrenGameobjects();
        m_TotalDistance = GetTotalTrackDistanceFromListOfGameobjects(gates);
    }

    private float GetTotalTrackDistanceFromListOfGameobjects(List<GameObject> gameObjectList)
    {
        float totalDistance = 0f;

        for(int i=0; i<gameObjectList.Count; i++)
        {
            int nextIndex = GetNextIndexForGate(i, gameObjectList);

            float tempDistance = Vector3.Distance(  gameObjectList[i].transform.position, 
                                                gameObjectList[nextIndex].transform.position);
            totalDistance += tempDistance;

        }

        return totalDistance;
    }

    private int GetNextIndexForGate(int currentIndex, List<GameObject> list)
    {
        int nextIndex = currentIndex+1;
        if(nextIndex >= list.Count)
            nextIndex = 0;
        return nextIndex;
    }

    List<GameObject> GetAllChildrenGameobjects()
    {
        List<GameObject> list = new List<GameObject>();
        foreach (Transform child in transform)
        {
            list.Add(child.gameObject);
        }
        return list;
    }

    public float CalculateProgress(List<GameObject> gatesTriggered, Vector3 position)
    {
        float progress = 0f;

        GameObject lastGateTriggered = gatesTriggered[gatesTriggered.Count - 1];
        float partialDistance = GetDistanceFromListOfGameobjects(gatesTriggered);
        partialDistance += Vector3.Distance(lastGateTriggered.transform.position, position);

        progress = partialDistance / m_TotalDistance;

        return progress;
    }

    private float GetDistanceFromListOfGameobjects(List<GameObject> gameObjectList)
    {
        float totalDistance = 0f;

        for(int i=0; i<gameObjectList.Count; i++)
        {
            int nextIndex = GetNextIndexForGate(i, gameObjectList);

            if (nextIndex == 0) break;

            float tempDistance = Vector3.Distance(gameObjectList[i].transform.position,
                                                gameObjectList[nextIndex].transform.position);
            totalDistance += tempDistance;
        }

        return totalDistance;
    }
}
