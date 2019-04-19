using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarSpawner : MonoBehaviour
{
    public GameObject CarPrefab;
    public int numberOfInstances = 5;
    void Start()
    {
        for (int i=0;i< numberOfInstances; i++)
        {
            GameObject tempCar = GameObject.Instantiate(CarPrefab);
            tempCar.transform.SetParent(transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
