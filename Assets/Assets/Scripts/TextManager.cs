using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    public bool isIntro;

    private bool isCaptionBusy;
    Coroutine closeMethod;
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
        CloseBtn.SetActive(false);
        ClearText();
    }

    public void CaptionTextHandler(string headingText, string incomingText, Color colorShade, bool popup)
    {
        if (closeMethod != null)
        {
            StopCoroutine(closeMethod);
        }
        closeMethod = StartCoroutine(RevealText(headingText, incomingText, colorShade, popup));
    }
    private IEnumerator RevealText(string headingText, string textContent, Color colorShade, bool popup)
    {
        isCaptionBusy = true;
        GetComponent<Image>().enabled = true;
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
            yield return new WaitForSeconds(0.005f);
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
        if (GameManager.Instance.isLearnt() == true)
        {
            ClearText();
            TextHolder.SetActive(false);
            GetComponent<Image>().enabled = false;
            isCaptionBusy = false;
        }
    }

    private void ClearText()
    {
        txt.text = "";
        Heading.text = "";
    }
}
