using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BenchLocation : MonoBehaviour
{
     Animator anim;
    NavMeshAgent theAgent;
    public Transform lookAtPoint;
    bool lookAt;
    GameObject other;
    public GameObject curtain;
    public bool temp = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lookAt)
        {
            other.transform.LookAt(lookAtPoint.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Customer")
        {
            if (other.GetComponent<CustomerAI>().AI_Information.isServed == false && other.GetComponent<CustomerAI>().haveOrdered == false && !temp)
            {
                Debug.Log("This", gameObject);
                temp = true;
                theAgent = other.GetComponent<NavMeshAgent>();
                anim = other.GetComponent<Animator>();
                theAgent.enabled = false;
                lookAt = true;
                this.other = other.gameObject;
                anim.SetBool("Sit", true);
                curtain.GetComponent<Animator>().enabled = true;
                curtain.GetComponent<Animator>().SetBool("true", true);
                StartCoroutine(ThinkAndOrder(other));
            }
         
        }
    }

    IEnumerator ThinkAndOrder(Collider other)
    {
        int RandomThinkingTime = Random.Range(2, 5);
        
        other.GetComponent<CustomerAI>().SetEmotion("Thinking");
        yield return new WaitForSeconds(RandomThinkingTime);
        other.GetComponent<CustomerAI>().OrderFood();
        other.GetComponent<CustomerAI>().SetEmotion("Happy");
    }


    public void curtainOff()
    {
        lookAt = false;
        curtain.GetComponent<Animator>().SetBool("true", false);
    }

}
