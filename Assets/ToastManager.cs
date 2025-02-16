using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToastManager : MonoBehaviour
{
    public TMP_Text mainText; // Start is called before the first frame

    public static ToastManager Instance { get; private set; }

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
    public void ShowToast(string incomingText, int time)
    {
        PlayFadeIn(incomingText);
        Invoke(nameof(FadeOut), time);
    }

    public void Show2SecondNotification(string incomingText)
    {
        ShowToast(incomingText, 2);
    }

    private void FadeOut()
    {
        ClearText();
        PlayFadeOut();
    }

    private void PlayFadeIn(string text)
    {
        mainText.text = text;
        GetComponent<Image>().enabled = true;
    }

    private void PlayFadeOut()
    {
        mainText.text = string.Empty;
        GetComponent<Image>().enabled = false;
    }
    private void ClearText()
    {
        mainText.text = "";
    }
}
