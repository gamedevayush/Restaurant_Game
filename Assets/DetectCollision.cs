using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectCollision : MonoBehaviour
{
    public UnityEvent ToDo;
    public string checkForTag;
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == checkForTag)
        {
            ToDo.Invoke();
        }
    }
}
