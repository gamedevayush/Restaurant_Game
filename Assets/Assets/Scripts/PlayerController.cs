using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{

    public float minRotationAngle = -90f; // Minimum allowed rotation angle (in degrees)
    public float maxRotationAngle = 90f;
    public Transform playerCamera;
    public Transform startPos;
    public FixedJoystick joystick;
    public NavMeshAgent theAgent;
    [HideInInspector()]
    public Animator anim;
    public bool trackPath = false;
    public bool agentActive = false;
    int currentDestination = 0;
    public bool isMoving;
    [Header("Array Of Destinations")]
    public Transform[] Destinations;

    [Header("Movement Settings")]
    public float runSpeed = 2.0f;
    public float smoothRotationTime = 0.25f;
    void Start()
    {
        playerCamera = Camera.main.transform;
        theAgent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        SetDestination(Destinations[7]);
        transform.rotation = new Quaternion(0, 180, 0, 1);
        theAgent.updateRotation = true;
        SetIntialPos();
    }

    public void SetIntialPos()
    {
        transform.position = startPos.transform.position;
        GetComponent<PlayMakerFSM>().SendEvent("Initial");
        SetDestination(Destinations[7]);
    }

    void Update()
    {
        if (isMoving && agentActive)
        {
            if (Vector3.Distance(Destinations[currentDestination].transform.position, transform.position) > 0.1f)
            {
                transform.LookAt(Destinations[currentDestination].transform.position);
            }
        }

        if (theAgent.velocity != Vector3.zero)
        {
            anim.SetBool("Move", true);
            isMoving = true;
        }
        else
        {
            anim.SetBool("Move", false);
            isMoving = false;
        }
    }


    public void MoveTo(string placeName)
    {
        if (GetComponent<PlayerFoodHandling>().broomIk == true)
        {
            return;
        }
        agentActive = true;
        theAgent.enabled = true;
        if (placeName == "Hut1")
        {
            if (Destinations.Length > 0 && Destinations[0] != null)
            {
                SetDestination(Destinations[0]);
                currentDestination = 0;
                Debug.Log("Destination Set To :" + Destinations[0].gameObject.name);
            }
        }

        if (placeName == "Hut2")
        {
            if (Destinations.Length > 1 && Destinations[1] != null)
            {
                currentDestination = 1;
                SetDestination(Destinations[1]);
            }
        }

        if (placeName == "Hut3")
        {
            if (Destinations.Length > 2 && Destinations[2] != null)
            {
                currentDestination = 2;
                SetDestination(Destinations[2]);
            }
        }

        if (placeName == "Hut4")
        {
            if (Destinations.Length > 2 && Destinations[2] != null)
            {
                currentDestination = 3;
                SetDestination(Destinations[3]);
            }
        }

        if (placeName == "Hut5")
        {
            if (Destinations.Length > 2 && Destinations[2] != null)
            {
                currentDestination = 4;
                SetDestination(Destinations[4]);
            }
        }

        if (placeName == "Toilet")
        {
            if (Destinations.Length > 2 && Destinations[2] != null)
            {
                currentDestination = 5;
                SetDestination(Destinations[5]);
            }
        }

        if (placeName == "Kitchen")
        {
            if (Destinations.Length > 2 && Destinations[2] != null)
            {
                currentDestination = 6;
                SetDestination(Destinations[6]);
            }
        }
        if (placeName == "Garbage")
        {
            if (Destinations.Length > 2 && Destinations[2] != null)
            {
                currentDestination = 8;
                SetDestination(Destinations[8]);
            }
        }


    }
    public void GoToGarbage(Transform destination)
    {
        MoveTo("Garbage");
    }
    public void SetDestination(Transform destination)
    {

        trackPath = true;
        theAgent.SetDestination(destination.position);

    }
}