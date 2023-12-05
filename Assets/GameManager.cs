using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public int currentTVUpgrade;
    public int currentHeartUpgrade;
    public int currentSpeakerUpgrade;
    public int currentVaseUpgrade;
    public int currentWallArtUpgrade;
    public int currentVehicleUpgrade;
    public int currentMachineUpgrade;
	public int gamePlayCount;
	
	
	
    public int globalCoins;
    public int lastUnlockedLevel;
	public TMP_Text coinText;
    public int garbageStatus = 0;


    public GameObject GarbageLayersParent;
    public GameObject ExtShopManager;
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
        LoadUpgrades();
        SaveGamePlay();
    }
    public void SaveLevel(int level)
    {
       if(level < PlayerPrefs.GetInt("Level"))
        {
            return;
        }
        if (level > 29)
        {
            return;
        }
        PlayerPrefs.SetInt("Level", level+1);
        Debug.Log("Saved level"+level);

    }
	public void SaveGamePlay()
	{
		int temp=PlayerPrefs.GetInt("GamePlayCount",0);
		PlayerPrefs.SetInt("GamePlayCount", temp+1);
	}

    public void SaveTVUpgrade(int level)
    {
        PlayerPrefs.SetInt("TVUpgrade", level);
		LoadUpgrades();
    }
    public void SaveHeartUpgrade(int level)
    {
        PlayerPrefs.SetInt("HeartUpgrade", level);
		LoadUpgrades();
    }
    public void SaveSpeakerUpgrade(int level)
    {
        PlayerPrefs.SetInt("SpeakerUpgrade", level);
		LoadUpgrades();
    }
    public void SaveVaseUpgrade(int level)
    {
        PlayerPrefs.SetInt("VaseUpgrade", level);
		LoadUpgrades();
    }
    public void SaveWallArtUpgrade(int level)
    {
        PlayerPrefs.SetInt("WallArtUpgrade", level);
		LoadUpgrades();
    }
    public void SaveVehicleUpgrade(int level)
    {
        PlayerPrefs.SetInt("VehicleUpgrade", level);
		LoadUpgrades();
    }
    public void SaveMachineUpgrade(int level)
    {
        PlayerPrefs.SetInt("MachineUpgrade", level);
		LoadUpgrades();
    }
    public void SaveGlobalCoins(int amount)
    {
        PlayerPrefs.SetInt("globalCoins", amount);
		LoadUpgrades();

    }
	public void SaveLearnt()
	{
		PlayerPrefs.SetInt("isLearnt",1);
	}
    public bool CheckLevel(int levelNo)
    {
        if (levelNo <= lastUnlockedLevel)
        {
            return true;
        }
        else
            return false;
    }
	
	public bool isLearnt()
    {
        if (PlayerPrefs.GetInt("isLearnt",0)==0)
        {
            return false;
        }
        else
            return true;
    }
	
	
    public void LoadUpgrades()
    {
      
        currentHeartUpgrade = PlayerPrefs.GetInt("HeartUpgrade",0);
        currentTVUpgrade = PlayerPrefs.GetInt("TVUpgrade", 0);
        currentMachineUpgrade = PlayerPrefs.GetInt("MachineUpgrade", 1);
        currentSpeakerUpgrade = PlayerPrefs.GetInt("SpeakerUpgrade", 0);
        currentVaseUpgrade = PlayerPrefs.GetInt("VaseUpgrade", 0);
        currentVehicleUpgrade = PlayerPrefs.GetInt("VehicleUpgrade", 1);
        currentWallArtUpgrade = PlayerPrefs.GetInt("WallArtUpgrade", 0);
        globalCoins = PlayerPrefs.GetInt("globalCoins", 100);
      
        ShowCoins(globalCoins);
        lastUnlockedLevel = PlayerPrefs.GetInt("Level",1);
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
	
	
	public void AddCoins(int increaseBy)
	{
		ChangeCoinsTo(globalCoins+increaseBy);
	}

    public void ShowCoins(int newCoins)
    {
        coinText.text = newCoins.ToString();
    }
    public void ChangeCoinsTo(int newCoins)
    {
        coinText.text = newCoins.ToString();
        SaveGlobalCoins(newCoins);
	}

    /*IEnumerator changeValueOverTime(float fromVal, float toVal, float duration)
{
    float counter = 0f;

    while (counter < duration)
    {
        if (Time.timeScale == 0)
            counter += Time.unscaledDeltaTime;
        else
            counter += Time.deltaTime;

        float val = Mathf.Lerp(fromVal, toVal, counter / duration);
        Debug.Log("Val: " + val);
		coinText.text=((int)val).ToString();
        yield return null;
    }
	
}*/


    public void CleanEverything()
    {
        for (int i =1; i <= GarbageLayersParent.transform.childCount; i++)
        {
            GarbageLayersParent.transform.GetChild(i-1).GetComponent<DirtMaker>().Cleaner();
        }


    
    }
}


