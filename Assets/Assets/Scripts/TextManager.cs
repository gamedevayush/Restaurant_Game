using System.Collections;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public string tempText = string.Empty;
    public int tempTime = 0;
    public RectTransform rt;
    public TMP_Text txt;
    public int OffSet;
    public TMP_Text Heading;
    public GameObject TextHolder;
    public float CaptiontextTime = 5f;
    public GameObject CloseBtn;
    private string tempHeading;
    private string tempIncomingText;
    private Color tempColorShad;
    private bool tempPopup;
    public bool isIntro;

    private bool isCaptionBusy;

    public static TextManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
       // TextHolder.SetActive(false);
        CloseBtn.SetActive(false);
        ClearText();
    }
    public void ShowToast(string incomingText, int time)
    {
        if (string.IsNullOrEmpty(txt.text))
        {
            PlayFadeIn(incomingText);
            Invoke(nameof(FadeOut), time);
        }
        else
        {
            QueueText(incomingText, time);
        }
    }

    public void Show2SecondNotification(string incomingText)
    {
        ShowToast(incomingText, 2);
    }

    private void QueueText(string incomingText, int time)
    {
        tempText = incomingText;
        tempTime = time;
        Invoke(nameof(ChangePriority), 1f);
    }

    private void ChangePriority()
    {
        ShowToast(tempText, tempTime);
    }

    private void FadeOut()
    {
        ClearText();
        PlayFadeOut();
    }

    private void PlayFadeIn(string text)
    {
        txt.text = text;
        GetComponent<Animator>().Play("FadeIn");
    }

    private void PlayFadeOut()
    {
        txt.text = string.Empty;
        GetComponent<Animator>().Play("FadeOut");
    }

    public void CaptionTextHandler(string headingText, string incomingText, Color colorShade, bool popup)
    {
        if (isCaptionBusy)
        {
            QueueCaption(headingText, incomingText, colorShade, popup);
            return;
        }

        StartCoroutine(RevealText(headingText, incomingText, colorShade, popup));
    }

    private void QueueCaption(string headingText, string incomingText, Color colorShade, bool popup)
    {
        tempHeading = headingText;
        tempIncomingText = incomingText;
        tempColorShad = colorShade;
        tempPopup = popup;
        Invoke(nameof(StartCaption), 5f);
    }

    private void StartCaption()
    {
        CaptionTextHandler(tempHeading, tempIncomingText, tempColorShad, tempPopup);
    }

    private IEnumerator RevealText(string headingText, string textContent, Color colorShade, bool popup)
    {
        isCaptionBusy = true;
        TextHolder.SetActive(true);
        Heading.text = headingText;
        Heading.color = colorShade;

        var originalString = textContent;
        txt.text = "";
        var numCharsRevealed = 0;

        while (numCharsRevealed < originalString.Length)
        {
            txt.text = originalString.Substring(0, ++numCharsRevealed) + GetRandomChar() + "|";
            UpdateTextHolderSize();
            yield return new WaitForSeconds(0.015f);
        }

        txt.text = originalString;
        if (popup)
        {
            CloseBtn.SetActive(true);
            yield return new WaitForSeconds(CaptiontextTime);
            CloseCaptions();
        }
        else
        {
            CloseBtn.SetActive(false);
        }
        isCaptionBusy = false;
    }

    private string GetRandomChar()
    {
        var randomChars = new[] { "@", "#", "$", "%", "^", "&" };
        return randomChars[Random.Range(0, randomChars.Length)];
    }

    private void UpdateTextHolderSize()
    {
        rt.sizeDelta = new Vector2(rt.rect.width, txt.preferredHeight + Heading.preferredHeight + OffSet);
    }

    public void CloseCaptions()
    {
        ClearText();
        TextHolder.SetActive(false);
        isCaptionBusy = false;
    }

    private void ClearText()
    {
        txt.text = "";
        Heading.text = "";
    }
}
