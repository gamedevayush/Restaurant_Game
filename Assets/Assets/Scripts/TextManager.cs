using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public string tempText = string.Empty;
    public int tempTime = 0;
    public RectTransform rt;
    public TMPro.TMP_Text txt;
    public int OffSet;
    public TMPro.TMP_Text Heading;
    public GameObject TextHolder;
    public float CaptiontextTime = 5f;
    public GameObject CloseBtn;
    string tempHeading;
    string tempIncomingText;
    Color tempColorShad;
    bool tempPopup;
    public Transform[] pos;
    public bool isIntro;


    bool isCaptionBusy;
    public static TextManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    void Start()
    {
        TextHolder.SetActive(false);
        if (!isIntro)
        { 
        CloseBtn.SetActive(false);
        }
        txt.text = "";
        Heading.text = "";
    }

    void ChangeCaptionPos(string posi)
    {
        if (posi == "left")
        {
            TextHolder.transform.position = pos[0].position;
        }
        if (posi == "right")
        {
            TextHolder.transform.position = pos[1].position;
        }
    }
    public void ShowToast(string incomingText, int time)
    {
        if (transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text == string.Empty)
        {
            transform.GetComponent<Animator>().Play("FadeIn");
            transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text = incomingText;
            //Debug.Log(incomingText);
            Invoke("FadeOut", time);
        }
        else
        {
            //Debug.Log(incomingText);
            tempText = incomingText;
            tempTime = time;
            Invoke("ChangePriority", 1f);
        }
    }

    public void Show2SecondNotification(string incomingText)
    {
        if (transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text == string.Empty)
        {
            transform.GetComponent<Animator>().Play("FadeIn");
            transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text = incomingText;
            //Debug.Log(incomingText);
            Invoke("FadeOut", 2);
        }
        else
        {
            //Debug.Log(incomingText);
            tempText = incomingText;
            tempTime = 2;
            Invoke("ChangePriority", 1f);
        }
    }


    void ChangePriority()
    {
        ShowToast(tempText, tempTime);
    }

    void FadeOut()
    {
        transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text = string.Empty;
        transform.GetComponent<Animator>().Play("FadeOut");
            Invoke("RemoveTextInstance", 2f);
    }
    void RemoveTextInstance()
    { 
        tempText = string.Empty;
        tempTime = 0;
    
    }
    void StartCaption()
    {

        CaptionTextHandler(tempHeading, tempIncomingText, tempColorShad, tempPopup);
    }
    public void CaptionTextHandler(string headingText,string incomingText,Color shadee, bool popup)
    {
        
        if (!popup)
        {
            StartCoroutine(RevealText(headingText, incomingText, shadee, popup));
            return;
        }
        else
        {
            CloseBtn.SetActive(false);

            Debug.Log("RIGHTT");
            ChangeCaptionPos("right");
        }
        if (!isCaptionBusy)
        {
            StartCoroutine(RevealText(headingText, incomingText, shadee, popup));
        }
        else
        {
            tempHeading = headingText;
            tempIncomingText = incomingText;
            tempColorShad = shadee;
            tempPopup = popup;
            Invoke("StartCaption", 5f);
        }
    }

    IEnumerator RevealText(string headeen,string texty,Color shade, bool popup)
    {
        yield return new WaitForSeconds(0.1f);
        isCaptionBusy = true;
        TextHolder.SetActive(true);
        Heading.text = headeen;
        Heading.color = shade;
        var originalString = texty.ToString();
        txt.text = "";
        string rand;
        var numCharsRevealed = 0;
        while (numCharsRevealed < originalString.Length)
        {
            int j = Random.Range(0, 6);
            switch (j)
            {
                case 5:
                    rand = "@";
                    break;
                case 4:
                    rand = "#";
                    break;
                case 3:
                    rand = "$";
                    break;
                case 2:
                    rand = "%";
                    break;
                case 1:
                    rand = "^";
                    break;
                default:
                    rand = "&";
                    break;
            }
            ++numCharsRevealed;
            txt.text = originalString.Substring(0, numCharsRevealed)+rand+"|";
            CaptionsCheck();
            yield return new WaitForSeconds(0.015f);
        }
        txt.text= texty.ToString();
        if (popup)
        {
            CloseBtn.SetActive(true);
            yield return new WaitForSeconds(CaptiontextTime);
            txt.text = "";
            Heading.text = "";
            TextHolder.SetActive(false);
            isCaptionBusy = false;
        }
        CaptiontextTime = 5;
    }
    void CaptionsCheck()
    {
        rt.sizeDelta = new Vector2(rt.rect.width, txt.preferredHeight + Heading.preferredHeight+OffSet);
    }

    public void CloseCaptions()
    {
        txt.text = "";
        Heading.text = "";
        TextHolder.SetActive(false);
        isCaptionBusy = false;
        ChangeCaptionPos("left");
        CaptiontextTime = 5f;
    }

    
}
