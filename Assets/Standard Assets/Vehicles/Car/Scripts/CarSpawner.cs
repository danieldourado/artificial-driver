using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarSpawner : MonoBehaviour
{
    public GameObject CarPrefab;
    public int numberOfInstances = 5;
    public List<DNA> DNAList = new List<DNA>();

    void Start()
    {
        for (int i=0;i< numberOfInstances; i++)
        {
            GameObject tempCar = GameObject.Instantiate(CarPrefab);
            tempCar.transform.SetParent(transform);
            DNAList.Add(tempCar.GetComponent<DNA>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
