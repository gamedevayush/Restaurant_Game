using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCleaner : MonoBehaviour
{
    public UnityEngine.Playables.PlayableDirector garbageWala;
    bool isRecentlyUsed;
    public GameObject GarbageObj;
    public GameObject Player;
    void Start()
    {
        GarbageObj.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Player")
        {
            if (!isRecentlyUsed)
            {
                Player = other.gameObject;
                other.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled=false;
                other.gameObject.GetComponent<PlayerFoodHandling>().broomIk = true;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            
                other.gameObject.GetComponent<PlayerController>().joystick.gameObject.SetActive(false);
                StartCoroutine(StartGarbage());
            }
            else
            {
                TextManager.Instance.ShowToast("You Recently Use Garbage Cleaner, Come back Later!", 5);
            }
        }

    }

    IEnumerator StartGarbage()
    {
        yield return new WaitForSeconds(0.2f);
        GarbageObj.SetActive(true);
        garbageWala.Play();
        isRecentlyUsed = true;
        yield return new WaitForSeconds(30f);
        isRecentlyUsed = false;

    }

    public void EndTimeline()
    {

        Player.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        GameManager.Instance.CleanEverything();
        GameManager.Instance.garbageStatus = 0;
        Player.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        Player.gameObject.GetComponent<PlayerFoodHandling>().broomIk = false;
     
        Player.gameObject.GetComponent<PlayerController>().joystick.gameObject.SetActive(true);

        garbageWala.Stop();
        GarbageObj.SetActive(false);
        

    }
}
