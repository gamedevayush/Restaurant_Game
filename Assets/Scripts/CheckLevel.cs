using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckLevel : MonoBehaviour
{
    public int levelNo;// Start is called before the first frame update
    public Sprite Locked;
    public Image Frame;
	public bool Unlocked;// Start is called before the first frame update
    void OnEnable()
    {
        GetComponent<Button>().interactable = false;
		Frame=transform.GetChild(1).GetComponent<Image>();
        StartCoroutine(CheckMe());

    }

    // Update is called once per frame
    IEnumerator CheckMe()
    {
        yield return new WaitForSeconds(1);
		
       Unlocked=GameManager.Instance.CheckLevel(levelNo);
        if (!Unlocked)
        {
            Frame.enabled = true;
           GetComponent<Button>().interactable = false;
        }
        else
        {
            Frame.enabled = false;
            GetComponent<Button>().interactable = true;
        }
        
       
    }
}
