using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour
{
    public void SwitchScene(string name)
    {
        if (name == "main")
        {
            SceneManager.LoadScene(0);
        }
        if (name == "game")
        {
            if (PlayerPrefs.GetInt("isLearnt", 0) == 0)
            {
                GetComponent<LoadASCENE>().OnStart(1);
            }
            else
            {
                GetComponent<LoadASCENE>().OnStart(2);
            }
        }
    }
	
	public void QuitButton()
	{
		Debug.LogWarning("Application Quit");
		Application.Quit();
	}

    public void AyusharmaButton()
    {
        Application.OpenURL("https://www.instagram.com/ayusharma0507/");
        
    }

    public void AyushBahiyaButton()
    {
        Application.OpenURL("https://www.instagram.com/ayush_singh_8x/");
        
    }



}
