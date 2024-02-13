using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    public GameObject Ayush;
    public GameObject Car;
    public GameObject Toshi;
    public GameObject Camera;
    public GameObject SkipBtn;
    public UnityEngine.Playables.PlayableDirector Director;
    int incrementor; 
    public void ChangeAyushParent()
    {
        Ayush.transform.parent = null;
    }

    private void Start()
    {
        SkipBtn.SetActive(false);
        Director.Play();
    }
    public void ShowText()
    
    {
        incrementor++;
        if (incrementor == 1)
        {
            //TextSpeech.TextToSpeech.Instance.Setting("en-US", 0.9f, 1);
            //TextSpeech.TextToSpeech.Instance.StartSpeak( "Yes, Mom! I Have Reached!");
            TextManager.Instance.CaptionTextHandler("Nitin","Yes, Mom! I Have Reached!", Color.red,false);
            SkipBtn.SetActive(true);

        }
        if (incrementor == 2)
        {
            //TextSpeech.TextToSpeech.Instance.StartSpeak("What is supposed to happen? I already told you that no one will stay here");
            TextManager.Instance.CaptionTextHandler("Nitin", "What is supposed to happen? I already told you that no one will stay here", Color.red,false);
        }
        if (incrementor == 3)
        {
            TextManager.Instance.CaptionTextHandler("Nitin", "It's Almost One Year, No One Wants to work here", Color.red, false);
        }
        if (incrementor == 4)
        {
            TextManager.Instance.CaptionTextHandler("Nitin", "The Guy who told yesterday that he will come, was also not here!", Color.red, false);
        }
        if (incrementor == 5)
        {
            TextManager.Instance.CaptionTextHandler("Nitin", "His Phone is Switched Off", Color.red, false);
        }
        if (incrementor == 6)
        {
            TextManager.Instance.CaptionTextHandler("Nitin", "The Problem is not salary", Color.red, false);
        }
        if (incrementor == 7)
        {
            TextManager.Instance.CaptionTextHandler("Nitin", "The Problem is that everyone wants to start thier own business and so they don't want to stay here for long!", Color.red, false);
        }
        if (incrementor == 8)
        {
            TextManager.Instance.CaptionTextHandler("Nitin", "Only the person who knows the value of work and money can stay here!", Color.red, false);
        }
        if (incrementor == 9)
        {
            TextManager.Instance.CaptionTextHandler("Nitin", "and the one who can take care of thier responsibilities", Color.red, false);
        }
        if (incrementor == 10)
        {
            TextManager.Instance.CaptionTextHandler("Nitin", "Well, I will come home and then discuss further!", Color.red, false);
        }
        if (incrementor == 11)
        {
            TextManager.Instance.CaptionTextHandler("Toshi", "Listen Brother, What is the Opening time of this Restaurant?", Color.blue, false);
        }
        if (incrementor == 12)
        {
            TextManager.Instance.CaptionTextHandler("Nitin", "Yes, It's Open! Tell me What you want", Color.red, false);
        }
        if (incrementor == 13)
        {
            TextManager.Instance.CaptionTextHandler("Toshi", "I have seen a banner near Road. Do you need worker?", Color.blue, false);
        }
        if (incrementor == 14)
        {
            TextManager.Instance.CaptionTextHandler("Nitin", "Yes, We need! But i don't think a girl can handle this work", Color.red, false);
        }
        if (incrementor == 15)
        {
            TextManager.Instance.CaptionTextHandler("Toshi", "No Sir! Please tell the work. I can do anything", Color.blue, false);
        }
        if (incrementor == 16)
        {
            TextManager.Instance.CaptionTextHandler("Nitin", "See the thing is, Our Restaurant remains open in morning but we need someone who can handle it at night. So, Can you manage our restaurant at night?  ", Color.red, false);
        }
        if (incrementor == 17)
        {
            TextManager.Instance.CaptionTextHandler("Toshi", "Yes Sir, I can manage. Actually, the School fees of my brother is still pending. Family members are starving for food. I am Working as a cook in the morning and will work here at night.", Color.blue, false);
        }
        if (incrementor == 18)
        {
            TextManager.Instance.CaptionTextHandler("Toshi", "Please Brother, Give me a chance", Color.blue, false);
        }
        if (incrementor == 19)
        {
            TextManager.Instance.CaptionTextHandler("Nitin", "Alright! As you need money for your family, i can select you for this golden opportunity", Color.red, false);
        }
        if (incrementor == 20)
        {
            TextManager.Instance.CaptionTextHandler("Nitin", "But you have to do all the work. From Cooking till Serve! Make sure not to get bad reviews for our restaurant!", Color.red, false);
        }
        if (incrementor == 21)
        {
            TextManager.Instance.CaptionTextHandler("Toshi", "Alright Brother ! I will do my best!", Color.blue, false);
        }
        if (incrementor == 22)
        {
            TextManager.Instance.CaptionTextHandler("Nitin", "OK, Join From Tommorow!", Color.red, false);
        }
        if (incrementor == 23)
        {
            TextManager.Instance.CaptionTextHandler("Toshi", "Thank You Brother, Thank You So Much!", Color.blue, false);
        }
        if (incrementor == 24)
        {
            GetComponent<LoadASCENE>().OnStart(2);
        }
    }

    public void SkipScene()
    {
        Director.Stop();
        GetComponent<LoadASCENE>().OnStart(2);
    }
}
