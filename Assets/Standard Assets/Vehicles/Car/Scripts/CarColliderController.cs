using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
public class CarColliderController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject.FindObjectOfType<NaturalSelection>().ReportDeath(GetComponent<DNA>());
        CarUserControl cuc = GetComponent<CarUserControl>();
        cuc.Die();
        cuc.enabled = false;
    }
}
