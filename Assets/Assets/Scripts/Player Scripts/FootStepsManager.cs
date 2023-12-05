using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepsManager : MonoBehaviour
{
    [Header("This FootStep is Being Controller by Animations")]
    [Space(2)]
    public AudioSource source;    //The AudioSource Used to play AudioClip
    public AudioClip audioClip;    //The FootStep AudioClip
    [Range(0.01f,1.0f)]
    public float volume = 0.25f;   //Adjusts the volume of FootSteps Sound
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayFootStepSound()
    {
      
        source.volume = volume;
        source.PlayOneShot(audioClip);
    }


}
