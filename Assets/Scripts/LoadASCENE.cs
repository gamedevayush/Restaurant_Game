using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadASCENE : MonoBehaviour
{


    public GameObject loadingScreenObj;
    public Slider slider;
    //public Text google;
   // public AudioSource audiopl;
    AsyncOperation async;

    public void OnStart(int k)
    {
       // audiopl = GetComponent<AudioSource>();
        StartCoroutine(LoadingScreen());
      //  audiopl.Play();
       // google.enabled = false;
    }

    IEnumerator LoadingScreen()
    {
        loadingScreenObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            slider.value = async.progress;

            if (async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
               // google.enabled = false;
            }
            yield return null;

        }

    }

}
