using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Vehicle : MonoBehaviour
{
    public float speed = 1.5f;
    public GameObject starter;
    private void Awake()
    {
        this.tag = "TrafficVehicle";
        this.GetComponent<NavMeshAgent>().speed = speed;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
