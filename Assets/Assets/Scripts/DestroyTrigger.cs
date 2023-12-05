using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CustomerAI>())
        {
           // other.GetComponent<CustomerAI>().SendReachSignal();
        Destroy(other.gameObject);
        }
        if (other.GetComponent<Vehicle>())
        {
            // other.GetComponent<CustomerAI>().SendReachSignal();
            Destroy(other.gameObject);
        }

    }
}
