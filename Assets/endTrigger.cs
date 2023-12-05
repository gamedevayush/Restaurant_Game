using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endTrigger : MonoBehaviour
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
        if (other.tag == "Customer")
        {
            Destroy(other.gameObject);
        }

        GameObject generator = GameObject.Find("CUSTOMER GENERATOR");
        generator.GetComponent<CustomerGenerator>().GenerateCustomer();
    }
}
