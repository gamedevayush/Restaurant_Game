using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject : MonoBehaviour
{
    [Range(0f, 5.0f)]
    public float rotationSpeed;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direction.x*rotationSpeed, direction.y * rotationSpeed, direction.z * rotationSpeed);
    }
}
