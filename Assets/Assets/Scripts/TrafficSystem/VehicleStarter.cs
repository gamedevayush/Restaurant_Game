using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VehicleStarter : MonoBehaviour
{
    // Start is called before the first frame update
    public VehiclesPrefabs prefabs;
    public GameObject destination;

    // Update is called once per frame

    public void Awake()
    {
       // GenerateNextVehicle();
    }
    void Update()
    {
        
    }

   public void GenerateNextVehicle()
    {
      
        int RandomVehicle = Random.Range(0, prefabs.vehicleArray.Length);
        GameObject vehicles = FindInActiveObjectByName("Vehicles");
        GameObject newVehicle = GameObject.Instantiate(prefabs.vehicleArray[RandomVehicle], this.transform.position,Quaternion.identity);
        newVehicle.GetComponent<Vehicle>().starter = this.gameObject;
        newVehicle.GetComponent<NavMeshAgent>().SetDestination(destination.transform.position);
        newVehicle.transform.parent = vehicles.transform;
       
    }

    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}
