using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public VehicleStarter starterObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "TrafficVehicle")
        {
          
            GameObject starter = other.gameObject.GetComponent<Vehicle>().starter;
            starter.GetComponent<VehicleStarter>().GenerateNextVehicle();
        }    
    }

}
