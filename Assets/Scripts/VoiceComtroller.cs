using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceComtroller : MonoBehaviour
{
    const string LANG_CODE = "en-US";
    public void Setup(string code)
    {
        TextSpeech.TextToSpeech.Instance.Setting(code, 1, 1);
    }
    public void StartSpeaking(string message)
    {
        TextSpeech.TextToSpeech.Instance.StartSpeak(message);
    }

    public void StopSpeaking()
    {
        TextSpeech.TextToSpeech.Instance.StopSpeak();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
