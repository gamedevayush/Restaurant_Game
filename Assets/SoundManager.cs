using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource player;
    public AudioClip TapSound;
    public AudioClip SuccessSound;
    public AudioClip FailSound;
    public AudioClip TingSound;
    public AudioClip ErrorSound;
    public AudioClip HornSound;
	[Header("Male Sound Collections")]
	public SoundCollection maleYoungCollection,maleKidCollection;
	[Space(5)]
	[Header("Female Sound Collection")]
	public SoundCollection femaleYoungCollection,femaleKidCollection;
    public static SoundManager Instance { get; set; }
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
        player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlaySound(string name)
    {
        if (name == "tap")
        {
            player.clip = TapSound;
        }
        if (name == "success")
        {
            player.clip = SuccessSound;
        }
        if (name == "fail")
        {
            player.clip = FailSound;
        }
        if (name == "ting")
        {
            player.clip = TingSound;
        }
        if (name == "error")
        {
            player.clip = ErrorSound;
        }
        if (name == "horn")
        {
            player.clip = HornSound;
        }
        player.Play();
    }

    public void PlayAISound(string Gender, bool isKid, string order)
    {
        if (Gender == "Male")
        {
            if (isKid == true)
            {
                if (order == "Samosa")
                {
                    player.PlayOneShot(maleKidCollection.askingForSamosa[0]);
                }
                if (order == "PaneerTikka")
                {
                    player.PlayOneShot(maleKidCollection.askingForPaneerTikka[0]);
                }
                if (order == "Pakora")
                {
                    player.PlayOneShot(maleKidCollection.askingForPakori[0]);
                }
                if (order == "Tea")
                {
                    player.PlayOneShot(maleKidCollection.askingForTea[0]);
                }

            }
            else
            {
                if (order == "Samosa")
                {
                    player.PlayOneShot(maleYoungCollection.askingForSamosa[0]);
                }
                if (order == "PaneerTikka")
                {
                    player.PlayOneShot(maleYoungCollection.askingForPaneerTikka[0]);
                }
                if (order == "Pakora")
                {
                    player.PlayOneShot(maleYoungCollection.askingForPakori[0]);
                }
                if (order == "Tea")
                {
                    player.PlayOneShot(maleYoungCollection.askingForTea[0]);
                }
            }
        }
        if(Gender == "Female")
        {
            if (isKid == true)
            {
                if (order == "Samosa")
                {
                    player.PlayOneShot(femaleKidCollection.askingForSamosa[0]);
                }
                if (order == "PaneerTikka")
                {
                    player.PlayOneShot(femaleKidCollection.askingForPaneerTikka[0]);
                }
                if (order == "Pakora")
                {
                    player.PlayOneShot(femaleKidCollection.askingForPakori[0]);
                }
                if (order == "Tea")
                {
                    player.PlayOneShot(femaleKidCollection.askingForTea[0]);
                }

            }
            else
            {
                if (order == "Samosa")
                {
                    player.PlayOneShot(femaleYoungCollection.askingForSamosa[0]);
                }
                if (order == "PaneerTikka")
                {
                    player.PlayOneShot(femaleYoungCollection.askingForPaneerTikka[0]);
                }
                if (order == "Pakora")
                {
                    player.PlayOneShot(femaleYoungCollection.askingForPakori[0]);
                }
                if (order == "Tea")
                {
                    player.PlayOneShot(femaleYoungCollection.askingForTea[0]);
                }
            }
        }
    }

    public void PlayAIFeedback(string Gender, bool isKid, int rating)
    {
        if (Gender == "Male")
        {
            if (isKid == true)
            {
                if (rating==1)
                {
                    player.clip = maleKidCollection.rating1[0];
                }
                if (rating == 2)
                {
                    player.clip = maleKidCollection.rating2[0];
                }
                if (rating == 3)
                {
                    player.clip = maleKidCollection.rating3[0];
                }
                if (rating == 4)
                {
                    player.clip = maleKidCollection.rating4[0];
                }
                if (rating == 5)
                {
                    player.clip = maleKidCollection.rating5[0];
                }
                
            }
            else
            {
                if (rating == 1)
                {
                    player.clip = maleYoungCollection.rating1[0];
                }
                if (rating == 2)
                {
                    player.clip = maleYoungCollection.rating2[0];
                }
                if (rating == 3)
                {
                    player.clip = maleYoungCollection.rating3[0];
                }
                if (rating == 4)
                {
                    player.clip = maleYoungCollection.rating4[0];
                }
                if (rating == 5)
                {
                    player.clip = maleYoungCollection.rating5[0];
                }
            }
        }
        if (Gender == "Female")
        {
            if (isKid == true)
            {
                if (rating == 1)
                {
                    player.clip = femaleKidCollection.rating1[0];
                }
                if (rating == 2)
                {
                    player.clip = femaleKidCollection.rating2[0];
                }
                if (rating == 3)
                {
                    player.clip = femaleKidCollection.rating3[0];
                }
                if (rating == 4)
                {
                    player.clip = femaleKidCollection.rating4[0];
                }
                if (rating == 5)
                {
                    player.clip = femaleKidCollection.rating5[0];
                }

            }
            else
            {
                if (rating == 1)
                {
                    player.clip = femaleYoungCollection.rating1[0];
                }
                if (rating == 2)
                {
                    player.clip = femaleYoungCollection.rating2[0];
                }
                if (rating == 3)
                {
                    player.clip = femaleYoungCollection.rating3[0];
                }
                if (rating == 4)
                {
                    player.clip = femaleYoungCollection.rating4[0];
                }
                if (rating == 5)
                {
                    player.clip = femaleYoungCollection.rating5[0];
                }
            }
        }
        player.Play();
    }
}
