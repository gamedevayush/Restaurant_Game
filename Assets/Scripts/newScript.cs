using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newScript : MonoBehaviour
{
    public static newScript _instance { get; set; }
    private void Awake()
    {
       
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }


    }
    void Start()
    {
        StartCoroutine(go());
    }
    IEnumerator go()
    {
        for (int i = 0; i < 16; i++)
        {
            Debug.Log("HII");
            yield return new WaitForSeconds(10f);
        }
        StartCoroutine(go());
    }
  
}
