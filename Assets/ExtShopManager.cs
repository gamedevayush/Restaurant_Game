using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExtShopManager : MonoBehaviour
{
    [System.Serializable]
    public class TVUpgrade
    {
        public GameObject[] prefabs;
        public int[] levelsReq;
        public int currentUpgradeNo = 0;
        public int totalUpdates;
        public int[] coinsRequired;
        public Image upgradeImageField;
        public Sprite[] upgradeSprites;
        public Image allUpdatesDone;
        public GameObject priceShowingObject;
        public TMP_Text priceText;
        public Image[] updateDots;
        public GameObject bellIcon;
        public Sprite updateCompleteDot, updateNotCompletedDot;
    }
    [SerializeField]


    [System.Serializable]
    public class decorationUpgrade
    {
        public GameObject[] prefabs;
        public int[] levelsReq;
        public int currentUpgradeNo = 0;
        public int totalUpdates;
        public int[] coinsRequired;
        public Image upgradeImageField;
        public Sprite[] upgradeSprites;
        public Image allUpdatesDone;
        public GameObject priceShowingObject;
        public TMP_Text priceText;
        public Image[] updateDots;
        public GameObject bellIcon;
        public Sprite updateCompleteDot, updateNotCompletedDot;
    }
    [SerializeField]


    


    [System.Serializable]
    public class SoundSystemUpdate
    {
        public GameObject[] prefab;
        public int[] levelsReq;
        public int currentUpgradeNo = 0;
        public int totalUpdates;
        public int[] coinsRequired;
        public Image upgradeImageField;
        public Sprite[] upgradeSprites;
        public Image allUpdatesDone;
        public GameObject priceShowingObject;
        public TMP_Text priceText;
        public Image[] updateDots;
        public GameObject bellIcon;
        public Sprite updateCompleteDot, updateNotCompletedDot;
    }
    [SerializeField]

    [System.Serializable]
    public class VegetationUpdate
    {
        public GameObject[] prefab;
        public int[] levelsReq;
        public int currentUpgradeNo = 0;
        public int totalUpdates;
        public int[] coinsRequired;
        public Image upgradeImageField;
        public Sprite[] upgradeSprites;
        public Image allUpdatesDone;
        public GameObject priceShowingObject;
        public TMP_Text priceText;
        public Image[] updateDots;
        public GameObject bellIcon;
        public Sprite updateCompleteDot, updateNotCompletedDot;

    }
    [SerializeField]

    [System.Serializable]
    public class WallArtUpdate
    {
        public Material[] prefab;
        public int[] levelsReq;
        public int currentUpgradeNo = 0;
        public int totalUpdates;
        public int[] coinsRequired;
        public Image upgradeImageField;
        public Sprite[] upgradeSprites;
        public Image allUpdatesDone;
        public GameObject priceShowingObject;
        public TMP_Text priceText;
        public Image[] updateDots;
        public GameObject bellIcon;
        public Sprite updateCompleteDot, updateNotCompletedDot;
    }
    [SerializeField]

    [System.Serializable]
    public class VehicleUpdate
    {
        public Image[] prefabs;
        public Image imageObjectToUpdate;
        public int[] levelsReq;
        public int[] speeds;
        public int currentUpgradeNo = 0;
        public int currentSpeed;
        public int totalUpdates;
        public int[] coinsRequired;
        public Image upgradeImageField;
        public Sprite[] upgradeSprites;
        public Image allUpdatesDone;
        public GameObject priceShowingObject;
        public TMP_Text priceText;
        public Image[] updateDots;
        public GameObject bellIcon;
        public Sprite updateCompleteDot, updateNotCompletedDot;
    }
    [SerializeField]

    [System.Serializable]
    public class FoodMachineUpdate
    {
        public int[] speed;
        public int[] levelsReq;
        public int currentUpgradeNo = 0;
        public int totalUpdates;
        public int[] coinsRequired;
        public Image upgradeImageField;
        public Sprite[] upgradeSprites;
        public Image allUpdatesDone;
        public GameObject priceShowingObject;
        public TMP_Text priceText;
        public Image[] updateDots;
        public GameObject bellIcon;
        public Sprite updateCompleteDot, updateNotCompletedDot;
    }
    [SerializeField]

    [Header("TV UPDATE SETTINGS")]
    public TVUpgrade tv;
    [Space(5)]
    [Header("DECORATIOn UPDATE SETTINGS")]
    public decorationUpgrade decoration;
    [Space(5)]
    [Header("Sound System Update")]
    public SoundSystemUpdate soundSystem;
    [Space(5)]
    [Header("Vegetation Update")]
    public SoundSystemUpdate vegetation;
    [Space(5)]
    [Header("WallArt Update")]
    public WallArtUpdate wallArt;
    [Space(5)]
    [Header("Vehicle Update")]
    public VehicleUpdate vehicle;
    [Space(5)]
    [Header("Food Machine Update")]
    public FoodMachineUpdate foodMachine;
    [Space(5)]
    [Header("Storage Update")]
    

    public GameObject updateAvailbleImage;





    public void Awake()
    {
        StartCoroutine(loadUpgrades());
    }
    IEnumerator loadUpgrades()
    {
		;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
        yield return new WaitForSeconds(1);
        tv.currentUpgradeNo = GameManager.Instance.currentTVUpgrade;
        decoration.currentUpgradeNo = GameManager.Instance.currentHeartUpgrade;
        soundSystem.currentUpgradeNo = GameManager.Instance.currentSpeakerUpgrade;
        vegetation.currentUpgradeNo = GameManager.Instance.currentVaseUpgrade;
        wallArt.currentUpgradeNo = GameManager.Instance.currentWallArtUpgrade;
        vehicle.currentUpgradeNo = GameManager.Instance.currentVehicleUpgrade;
        foodMachine.currentUpgradeNo = GameManager.Instance.currentMachineUpgrade;
       
		;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
        WriteTVVisuals(tv.currentUpgradeNo);
        WriteDecorationVisuals(decoration.currentUpgradeNo);
        WriteSoundSystemVisuals(soundSystem.currentUpgradeNo);
        WriteVegetationVisuals(vegetation.currentUpgradeNo);
        WriteWallArtVisuals(wallArt.currentUpgradeNo);
        WriteVehicleVisuals(vehicle.currentUpgradeNo);
        WriteFoodMachineVisuals(foodMachine.currentUpgradeNo);
       ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

        CheckInAnyUpgradeAvailable();
    }


    #region TVUpdate
    public void UpdateTV()
    {

        if (tv.currentUpgradeNo >= tv.totalUpdates)
        {
            TextManager.Instance.CaptiontextTime = 3;
            TextManager.Instance.CaptionTextHandler("Alert", "You already have Latest Upgrades!", Color.blue, true);
            CheckInAnyUpgradeAvailable();
            return;
        }

        int totalCoins = GetTotalCoins();

        if (GetCurrentLevel() >= tv.levelsReq[tv.currentUpgradeNo])
        {

            if (totalCoins >= tv.coinsRequired[tv.currentUpgradeNo])
            {

                UpdateTVVisuals(tv.currentUpgradeNo);
                GameManager.Instance.AddCoins(-tv.coinsRequired[tv.currentUpgradeNo]);
                tv.currentUpgradeNo++;
                GameManager.Instance.SaveTVUpgrade(tv.currentUpgradeNo);
                CheckInAnyUpgradeAvailable();
                AdmobController.Instance.ShowInterstitialAd();
            }
            else
            {
                //Debug.Log("Coins not sufficinet");
                TextManager.Instance.CaptiontextTime = 3;
                TextManager.Instance.CaptionTextHandler("Alert", "No Enough Coins to Purchase!", Color.blue, true);

            }
        }
        else
        {
            TextManager.Instance.CaptiontextTime = 3;
            TextManager.Instance.CaptionTextHandler("Alert", "You Need Level "+tv.levelsReq[tv.currentUpgradeNo], Color.blue, true);
        }
    }

    void UpdateTVVisuals(int upgradeNo)
    {
        //Changing Model Of TV
        for (int i = 0; i < tv.prefabs.Length; i++)
        {
            if (i == upgradeNo) tv.prefabs[i].SetActive(true);
            else tv.prefabs[i].SetActive(false);
        }

        if (upgradeNo + 1 < tv.totalUpdates)
        {
            tv.upgradeImageField.sprite = tv.upgradeSprites[upgradeNo + 1];

            tv.priceText.text = tv.coinsRequired[tv.currentUpgradeNo + 1].ToString();
        }
        for (int i = 0; i < tv.updateDots.Length; i++)
        {
            if (i <= upgradeNo)
            {
                tv.updateDots[i].sprite = tv.updateCompleteDot;
            }
        }

        if (tv.currentUpgradeNo + 1 == tv.totalUpdates)
        {
            tv.priceShowingObject.SetActive(false);
            tv.allUpdatesDone.gameObject.SetActive(true);

        }


    }

    void WriteTVVisuals(int upgradeNo)
    {
      //  Debug.Log(tv.totalUpdates);
        //Changing Model Of TV
        for (int i = 1; i <= tv.prefabs.Length; i++)
        {

            if (i == upgradeNo) tv.prefabs[i - 1].SetActive(true);
            else tv.prefabs[i - 1].SetActive(false);
        }

        if (upgradeNo < tv.totalUpdates)
        {
            tv.priceText.text = tv.coinsRequired[tv.currentUpgradeNo].ToString();
            tv.upgradeImageField.sprite = tv.upgradeSprites[upgradeNo];
        }
        else if (upgradeNo == tv.totalUpdates)
        {
            tv.upgradeImageField.sprite = tv.upgradeSprites[upgradeNo - 1];
        }
        for (int i = 0; i < tv.updateDots.Length; i++)
        {
            if (i < upgradeNo)
            {
                tv.updateDots[i].sprite = tv.updateCompleteDot;
            }
        }

        if (tv.currentUpgradeNo == tv.totalUpdates)
        {
            tv.priceShowingObject.SetActive(false);
            tv.allUpdatesDone.gameObject.SetActive(true);

        }


    }
    #endregion

    #region DecorationUpdate
    public void Updatedecoration()
    {
        if (decoration.currentUpgradeNo >= decoration.totalUpdates)
        {
            TextManager.Instance.CaptiontextTime = 3;
            TextManager.Instance.CaptionTextHandler("Alert", "You already have Latest Upgrades!", Color.blue, true);
            return;
        }

        int totalCoins = GetTotalCoins();

        if (GetCurrentLevel() >= decoration.levelsReq[decoration.currentUpgradeNo])
        {
            if (totalCoins >= decoration.coinsRequired[decoration.currentUpgradeNo])
            {

                UpdatedecorationVisuals(decoration.currentUpgradeNo);
                GameManager.Instance.AddCoins(-decoration.coinsRequired[decoration.currentUpgradeNo]);
                decoration.currentUpgradeNo++;
                GameManager.Instance.SaveHeartUpgrade(decoration.currentUpgradeNo);
                CheckInAnyUpgradeAvailable();
                AdmobController.Instance.ShowInterstitialAd();
            }
            else
            {
                TextManager.Instance.CaptiontextTime = 3;
                TextManager.Instance.CaptionTextHandler("Alert", "No Enough Coins to Purchase!", Color.blue, true);
            }
        }
        else
        {
            TextManager.Instance.CaptiontextTime = 3;
            TextManager.Instance.CaptionTextHandler("Alert", "You Need Level " + decoration.levelsReq[decoration.currentUpgradeNo], Color.blue, true);
        }
    }

    void UpdatedecorationVisuals(int upgradeNo)
    {
        //Changing Model Of TV
        for (int i = 0; i < decoration.prefabs.Length; i++)
        {
            if (i == upgradeNo) decoration.prefabs[i].SetActive(true);

        }

        if (upgradeNo + 1 < decoration.totalUpdates)
        {
            decoration.upgradeImageField.sprite = decoration.upgradeSprites[upgradeNo];

            decoration.priceText.text = decoration.coinsRequired[decoration.currentUpgradeNo + 1].ToString();
        }
        for (int i = 0; i < decoration.updateDots.Length; i++)
        {
            if (i <= upgradeNo)
            {
                decoration.updateDots[i].sprite = decoration.updateCompleteDot;
            }
        }
        if (decoration.currentUpgradeNo + 1 == decoration.totalUpdates)
        {
            decoration.priceShowingObject.SetActive(false);
            decoration.allUpdatesDone.gameObject.SetActive(true);

        }

    }

    void WriteDecorationVisuals(int upgradeNo)
    {
      //  Debug.Log(decoration.totalUpdates);
        //Changing Model Of TV
        for (int i = 1; i <= decoration.prefabs.Length; i++)
        {

            if (i == upgradeNo || i<upgradeNo) decoration.prefabs[i - 1].SetActive(true);
          
        }

        if (upgradeNo < decoration.totalUpdates)
        {
            decoration.priceText.text = decoration.coinsRequired[decoration.currentUpgradeNo].ToString();
            decoration.upgradeImageField.sprite = decoration.upgradeSprites[upgradeNo];
        }
        else if (upgradeNo == decoration.totalUpdates)
        {
            decoration.upgradeImageField.sprite = decoration.upgradeSprites[upgradeNo - 1];
        }
        for (int i = 0; i < decoration.updateDots.Length; i++)
        {
            if (i < upgradeNo)
            {
                decoration.updateDots[i].sprite = decoration.updateCompleteDot;
            }
        }

        if (decoration.currentUpgradeNo == decoration.totalUpdates)
        {
            decoration.priceShowingObject.SetActive(false);
            decoration.allUpdatesDone.gameObject.SetActive(true);

        }


    }



    #endregion

    #region SoundSystemUpdate
    public void UpdateSoundSystem()
    {
        if (soundSystem.currentUpgradeNo >= soundSystem.totalUpdates)
        {
            TextManager.Instance.CaptiontextTime = 3;
            TextManager.Instance.CaptionTextHandler("Alert", "You already have Latest Upgrades!", Color.blue, true);
            return;
        }

        int totalCoins = GetTotalCoins();

        if (GetCurrentLevel() >= soundSystem.levelsReq[soundSystem.currentUpgradeNo])
        {
            if (totalCoins >= soundSystem.coinsRequired[soundSystem.currentUpgradeNo])
            {

                UpdateSoundSystemVisuals(soundSystem.currentUpgradeNo);
                GameManager.Instance.AddCoins(-soundSystem.coinsRequired[soundSystem.currentUpgradeNo]);
                soundSystem.currentUpgradeNo++;
                GameManager.Instance.SaveSpeakerUpgrade(soundSystem.currentUpgradeNo);
                CheckInAnyUpgradeAvailable();
                AdmobController.Instance.ShowInterstitialAd();
            }
            else
            {
                TextManager.Instance.CaptiontextTime = 3;
                TextManager.Instance.CaptionTextHandler("Alert", "No Enough Coins to Purchase!", Color.blue, true);
            }
        }
        else
        {
            TextManager.Instance.CaptiontextTime = 3;
            TextManager.Instance.CaptionTextHandler("Alert", "You Need Level " + soundSystem.levelsReq[soundSystem.currentUpgradeNo], Color.blue, true);
        }
    }

    void UpdateSoundSystemVisuals(int upgradeNo)
    {
        //Changing Model Of TV
        for (int i = 0; i < soundSystem.prefab.Length; i++)
        {
            if (i == upgradeNo) soundSystem.prefab[i].SetActive(true);
            else soundSystem.prefab[i].SetActive(false);
        }

        if (upgradeNo + 1 < soundSystem.totalUpdates)
        {
            soundSystem.upgradeImageField.sprite = soundSystem.upgradeSprites[upgradeNo];
            soundSystem.priceText.text = (soundSystem.coinsRequired[soundSystem.currentUpgradeNo + 1]).ToString();
        }
        for (int i = 0; i < soundSystem.updateDots.Length; i++)
        {
            if (i <= upgradeNo)
            {
                soundSystem.updateDots[i].sprite = soundSystem.updateCompleteDot;
            }
        }

        if (soundSystem.currentUpgradeNo + 1 == soundSystem.totalUpdates)
        {
            soundSystem.priceShowingObject.SetActive(false);
            soundSystem.allUpdatesDone.gameObject.SetActive(true);

        }

    }

    void WriteSoundSystemVisuals(int upgradeNo)
    {
     //   Debug.Log(soundSystem.totalUpdates);
        //Changing Model Of TV
        for (int i = 1; i <= soundSystem.prefab.Length; i++)
        {

            if (i == upgradeNo) soundSystem.prefab[i - 1].SetActive(true);
            else soundSystem.prefab[i - 1].SetActive(false);
        }

        if (upgradeNo < soundSystem.totalUpdates)
        {
            soundSystem.priceText.text = soundSystem.coinsRequired[soundSystem.currentUpgradeNo].ToString();
            soundSystem.upgradeImageField.sprite = soundSystem.upgradeSprites[upgradeNo];
        }
        else if (upgradeNo == soundSystem.totalUpdates)
        {
            soundSystem.upgradeImageField.sprite = soundSystem.upgradeSprites[upgradeNo - 1];
        }
        for (int i = 0; i < soundSystem.updateDots.Length; i++)
        {
            if (i < upgradeNo)
            {
                soundSystem.updateDots[i].sprite = soundSystem.updateCompleteDot;
            }
        }

        if (soundSystem.currentUpgradeNo == soundSystem.totalUpdates)
        {
            soundSystem.priceShowingObject.SetActive(false);
            soundSystem.allUpdatesDone.gameObject.SetActive(true);

        }


    }
    #endregion

    #region VegetationUpdate
    public void UpdateVegetation()
    {
        if (vegetation.currentUpgradeNo >= vegetation.totalUpdates)
        {
            TextManager.Instance.CaptiontextTime = 3;
            TextManager.Instance.CaptionTextHandler("Alert", "You already have Latest Upgrades!", Color.blue, true);
            return;
        }

        int totalCoins = GetTotalCoins();

        if (GetCurrentLevel() >= vegetation.levelsReq[vegetation.currentUpgradeNo])
        {
            if (totalCoins >= vegetation.coinsRequired[vegetation.currentUpgradeNo])
            {

                UpdateVegetationVisuals(vegetation.currentUpgradeNo);
                GameManager.Instance.AddCoins(-vegetation.coinsRequired[vegetation.currentUpgradeNo]);
                vegetation.currentUpgradeNo++;
                GameManager.Instance.SaveVaseUpgrade(vegetation.currentUpgradeNo);
                CheckInAnyUpgradeAvailable();
                AdmobController.Instance.ShowInterstitialAd();
            }
            else
            {
                TextManager.Instance.CaptiontextTime = 3;
                TextManager.Instance.CaptionTextHandler("Alert", "No Enough Coins to Purchase!", Color.blue, true);
            }
        }
        else
        {
            TextManager.Instance.CaptiontextTime = 3;
            TextManager.Instance.CaptionTextHandler("Alert", "You Need Level " + vegetation.levelsReq[vegetation.currentUpgradeNo], Color.blue, true);

        }
    }

    void UpdateVegetationVisuals(int upgradeNo)
    {
        //Changing Model Of TV
        for (int i = 0; i < vegetation.prefab.Length; i++)
        {
            if (i == upgradeNo) vegetation.prefab[i].SetActive(true);
            //else vegetation.prefab[i].SetActive(false);
        }

        if (upgradeNo + 1 < vegetation.totalUpdates)
        {
            vegetation.upgradeImageField.sprite = vegetation.upgradeSprites[upgradeNo + 1];
            vegetation.priceText.text = (vegetation.coinsRequired[vegetation.currentUpgradeNo + 1]).ToString();
        }
        for (int i = 0; i < vegetation.updateDots.Length; i++)
        {
            if (i <= upgradeNo)
            {
                vegetation.updateDots[i].sprite = vegetation.updateCompleteDot;
            }
        }

        if (vegetation.currentUpgradeNo + 1 == vegetation.totalUpdates)
        {
            vegetation.priceShowingObject.SetActive(false);
            vegetation.allUpdatesDone.gameObject.SetActive(true);

        }

    }
    void WriteVegetationVisuals(int upgradeNo)
    {
       // Debug.Log(vegetation.totalUpdates);
        //Changing Model Of TV
        for (int i = 1; i <= vegetation.prefab.Length; i++)
        {

            if (i == upgradeNo ||i<upgradeNo) vegetation.prefab[i - 1].SetActive(true);
            
        }

        if (upgradeNo < vegetation.totalUpdates)
        {
            vegetation.priceText.text = vegetation.coinsRequired[vegetation.currentUpgradeNo].ToString();
            vegetation.upgradeImageField.sprite = vegetation.upgradeSprites[upgradeNo];
        }
        else if (upgradeNo == vegetation.totalUpdates)
        {
            vegetation.upgradeImageField.sprite = vegetation.upgradeSprites[upgradeNo - 1];
        }
        for (int i = 0; i < vegetation.updateDots.Length; i++)
        {
            if (i < upgradeNo)
            {
                vegetation.updateDots[i].sprite = vegetation.updateCompleteDot;
            }
        }

        if (vegetation.currentUpgradeNo == vegetation.totalUpdates)
        {
            vegetation.priceShowingObject.SetActive(false);
            vegetation.allUpdatesDone.gameObject.SetActive(true);

        }


    }
    #endregion

    #region WallArtUpdate
    public void UpdateWallArt()
    {
        if (wallArt.currentUpgradeNo >= wallArt.totalUpdates)
        {
            TextManager.Instance.CaptiontextTime = 3;
            TextManager.Instance.CaptionTextHandler("Alert", "You already have Latest Upgrades!", Color.blue, true);
            return;
        }

        int totalCoins = GetTotalCoins();

        if (GetCurrentLevel() >= wallArt.levelsReq[wallArt.currentUpgradeNo])
        {
            if (totalCoins >= wallArt.coinsRequired[wallArt.currentUpgradeNo])
            {

                UpdateWallArtVisuals(wallArt.currentUpgradeNo);
                GameManager.Instance.AddCoins(-wallArt.coinsRequired[wallArt.currentUpgradeNo]);
                wallArt.currentUpgradeNo++;
                GameManager.Instance.SaveWallArtUpgrade(wallArt.currentUpgradeNo);
                CheckInAnyUpgradeAvailable();
                AdmobController.Instance.ShowInterstitialAd();
            }
            else
			{
                TextManager.Instance.CaptiontextTime = 3;
                TextManager.Instance.CaptionTextHandler("Alert", "No Enough Coins to Purchase!", Color.blue, true);
            }
        }
        else
        {
            TextManager.Instance.CaptiontextTime = 3;
            TextManager.Instance.CaptionTextHandler("Alert", "You Need Level " + wallArt.levelsReq[wallArt.currentUpgradeNo], Color.blue, true);

        }
    }

    void UpdateWallArtVisuals(int upgradeNo)
    {
        //Changing Model Of TV
        for (int i = 0; i < wallArt.prefab.Length; i++)
        {
            if (i <= upgradeNo)
            {
                Color temp = wallArt.prefab[i].color;
                temp.a = 1;
                wallArt.prefab[i].color = temp;
            }
        }
        if (upgradeNo + 1 < wallArt.totalUpdates)
        {
            wallArt.upgradeImageField.sprite = wallArt.upgradeSprites[upgradeNo + 1];

            wallArt.priceText.text = (wallArt.coinsRequired[wallArt.currentUpgradeNo + 1]).ToString();
        }
        for (int i = 0; i < wallArt.updateDots.Length; i++)
        {
            if (i <= upgradeNo)
            {
                wallArt.updateDots[i].sprite = wallArt.updateCompleteDot;
            }
        }

        if (wallArt.currentUpgradeNo + 1 == wallArt.totalUpdates)
        {
            wallArt.priceShowingObject.SetActive(false);
            wallArt.allUpdatesDone.gameObject.SetActive(true);

        }

    }

    void WriteWallArtVisuals(int upgradeNo)
    {
     //   Debug.Log(wallArt.totalUpdates);
        //Changing Model Of TV
        //for (int i = 0; i < wallArt.prefab.Length; i++)
        //{
        // if (i < upgradeNo)
        // {
        //     Color temp = wallArt.prefab[i].color;
        //    temp.a = 1;
        //   wallArt.prefab[i].color = temp;
        //  }
        // }
        for (int i = 0; i < wallArt.prefab.Length; i++)
        {
            if (i < upgradeNo)
            {
                Color temp = wallArt.prefab[i].color;
                temp.a = 1;
                wallArt.prefab[i].color = temp;
            }
			else
			{
				 Color temp = wallArt.prefab[i].color;
                temp.a = 0;
                wallArt.prefab[i].color = temp;
			}

            //if (i == upgradeNo) wallArt.prefab[i - 1].SetActive(true);
            // else wallArt.prefab[i - 1].SetActive(false);
        }

        if (upgradeNo < wallArt.totalUpdates)
        {
            wallArt.priceText.text = wallArt.coinsRequired[wallArt.currentUpgradeNo].ToString();
            wallArt.upgradeImageField.sprite = wallArt.upgradeSprites[upgradeNo];
        }
        else if (upgradeNo == wallArt.totalUpdates)
        {
            wallArt.upgradeImageField.sprite = wallArt.upgradeSprites[upgradeNo - 1];
        }
        for (int i = 0; i < wallArt.updateDots.Length; i++)
        {
            if (i < upgradeNo)
            {
                wallArt.updateDots[i].sprite = wallArt.updateCompleteDot;
            }
        }

        if (wallArt.currentUpgradeNo == wallArt.totalUpdates)
        {
            wallArt.priceShowingObject.SetActive(false);
            wallArt.allUpdatesDone.gameObject.SetActive(true);

        }


    }
    #endregion

    #region VehicleUpdate
    public void UpdateVehicle()
    {
        if (vehicle.currentUpgradeNo >= vehicle.totalUpdates)
        {
            TextManager.Instance.CaptiontextTime = 3;
            TextManager.Instance.CaptionTextHandler("Alert", "You already have Latest Upgrades!", Color.blue, true);
            return;
        }

        int totalCoins = GetTotalCoins();

        if (GetCurrentLevel() >= vehicle.levelsReq[vehicle.currentUpgradeNo])
        {
            if (totalCoins >= vehicle.coinsRequired[vehicle.currentUpgradeNo])
            {

                UpdateVehicleVisuals(vehicle.currentUpgradeNo);
                GameManager.Instance.AddCoins(-vehicle.coinsRequired[vehicle.currentUpgradeNo]);
                vehicle.currentUpgradeNo++;
                GameManager.Instance.SaveVehicleUpgrade(vehicle.currentUpgradeNo);
                GetVehicle.Instance.Restart();
                CheckInAnyUpgradeAvailable();
                AdmobController.Instance.ShowInterstitialAd();
            }
            else
            {
                TextManager.Instance.CaptiontextTime = 3;
                TextManager.Instance.CaptionTextHandler("Alert", "No Enough Coins to Purchase!", Color.blue, true);
            }
        }
        else
        {
            TextManager.Instance.CaptiontextTime = 3;
            TextManager.Instance.CaptionTextHandler("Alert", "You Need Level " + vehicle.levelsReq[vehicle.currentUpgradeNo], Color.blue, true);
        }
    }

    void UpdateVehicleVisuals(int upgradeNo)
    {
        //Changing Image Of Vehicle
        for (int i = 0; i < vehicle.prefabs.Length; i++)
        {
            if (i == upgradeNo)
            {
                Debug.Log("Update number on Update function is" + upgradeNo);
                vehicle.prefabs[i].transform.gameObject.SetActive(true);
                vehicle.currentSpeed = vehicle.speeds[i];
            }
            else vehicle.prefabs[i].transform.gameObject.SetActive(false);
        }

        if (upgradeNo + 1 < vehicle.totalUpdates)
        {
            vehicle.upgradeImageField.sprite = vehicle.upgradeSprites[upgradeNo + 1];

            vehicle.priceText.text = (vehicle.coinsRequired[vehicle.currentUpgradeNo + 1]).ToString();
        }
        for (int i = 0; i < vehicle.updateDots.Length; i++)
        {
            if (i <= upgradeNo)
            {
                vehicle.updateDots[i].sprite = vehicle.updateCompleteDot;
            }
        }
        if (vehicle.currentUpgradeNo + 1 == vehicle.totalUpdates)
        {
            vehicle.priceShowingObject.SetActive(false);
            vehicle.allUpdatesDone.gameObject.SetActive(true);

        }
      

    }
    void WriteVehicleVisuals(int upgradeNo)
    {
       
        for (int i = 0; i < vehicle.prefabs.Length; i++)
        {
            if (i == upgradeNo-1)
            {
                Debug.Log("Update number on Write function is" + upgradeNo);
                vehicle.prefabs[i ].transform.gameObject.SetActive(true);
                vehicle.currentSpeed = vehicle.speeds[i];
            }
            else vehicle.prefabs[i].transform.gameObject.SetActive(false);
        }
       // Debug.Log(vehicle.totalUpdates);
        //Changing Model Of TV

       // Debug.Log("Current Speed is" + vehicle.speeds[vehicle.currentUpgradeNo - 1]);

        vehicle.currentSpeed = vehicle.speeds[vehicle.currentUpgradeNo-1];

        if (upgradeNo < vehicle.totalUpdates)
        {
            vehicle.priceText.text = vehicle.coinsRequired[vehicle.currentUpgradeNo ].ToString();
            vehicle.upgradeImageField.sprite = vehicle.upgradeSprites[upgradeNo];
        }
        else if (upgradeNo == vehicle.totalUpdates)
        {
            vehicle.upgradeImageField.sprite = vehicle.upgradeSprites[upgradeNo - 1];
        }
        for (int i = 0; i < vehicle.updateDots.Length; i++)
        {
            if (i < upgradeNo)
            {
                vehicle.updateDots[i].sprite = vehicle.updateCompleteDot;
            }
        }

        if (vehicle.currentUpgradeNo == vehicle.totalUpdates)
        {
            vehicle.priceShowingObject.SetActive(false);
            vehicle.allUpdatesDone.gameObject.SetActive(true);

        }

        GetVehicle.Instance.Restart();
    }
    #endregion

    #region FoodMachineUpdate
    public void UpdateFoodMachine()
    {
        if (foodMachine.currentUpgradeNo >= foodMachine.totalUpdates)
        {
            TextManager.Instance.CaptiontextTime = 3;
            TextManager.Instance.CaptionTextHandler("Alert", "You already have Latest Upgrades!", Color.blue, true);
            return;
        }

        int totalCoins = GetTotalCoins();

        if (GetCurrentLevel() >= foodMachine.levelsReq[foodMachine.currentUpgradeNo])
        {
            if (totalCoins >= foodMachine.coinsRequired[foodMachine.currentUpgradeNo])
            {

                UpdateFoodMachineVisuals(foodMachine.currentUpgradeNo);
                GameManager.Instance.AddCoins(-foodMachine.coinsRequired[foodMachine.currentUpgradeNo]);
                foodMachine.currentUpgradeNo++;
                GameManager.Instance.SaveMachineUpgrade(foodMachine.currentUpgradeNo);
                CheckInAnyUpgradeAvailable();
                AdmobController.Instance.ShowInterstitialAd();
            }
            else
            {
                TextManager.Instance.CaptiontextTime = 3;
                TextManager.Instance.CaptionTextHandler("Alert", "No Enough Coins to Purchase!", Color.blue, true);
            }
        }
        else
        {
            TextManager.Instance.CaptiontextTime = 3;
            TextManager.Instance.CaptionTextHandler("Alert", "You Need Level " + foodMachine.levelsReq[foodMachine.currentUpgradeNo], Color.blue, true);
        }
    }

    void UpdateFoodMachineVisuals(int upgradeNo)
    {
        //Changing Speed Of Food Machine
        //SetFoodSpeed(foodMachine.speed[upgradeNo]);  //Not completed

        if (upgradeNo + 1 < foodMachine.totalUpdates)
        {
            foodMachine.upgradeImageField.sprite = foodMachine.upgradeSprites[upgradeNo + 1];

            foodMachine.priceText.text = (foodMachine.coinsRequired[foodMachine.currentUpgradeNo + 1]).ToString();
        }

        for (int i = 0; i < foodMachine.updateDots.Length; i++)
        {
            if (i <= upgradeNo)
            {
                foodMachine.updateDots[i].sprite = foodMachine.updateCompleteDot;
            }
        }
        if (foodMachine.currentUpgradeNo + 1 == foodMachine.totalUpdates)
        {
            foodMachine.priceShowingObject.SetActive(false);
            foodMachine.allUpdatesDone.gameObject.SetActive(true);

        }

    }

    void WriteFoodMachineVisuals(int upgradeNo)
    {

        if (upgradeNo < foodMachine.totalUpdates)
        {
            foodMachine.upgradeImageField.sprite = foodMachine.upgradeSprites[upgradeNo];

            foodMachine.priceText.text = (foodMachine.coinsRequired[foodMachine.currentUpgradeNo]).ToString();
        }




        if (upgradeNo < foodMachine.totalUpdates)
        {
            foodMachine.priceText.text = foodMachine.coinsRequired[foodMachine.currentUpgradeNo].ToString();
            foodMachine.upgradeImageField.sprite = foodMachine.upgradeSprites[upgradeNo];
        }
        else if (upgradeNo == foodMachine.totalUpdates)
        {
            foodMachine.upgradeImageField.sprite = foodMachine.upgradeSprites[upgradeNo - 1];
        }
        for (int i = 0; i < foodMachine.updateDots.Length; i++)
        {
            if (i < upgradeNo)
            {
                foodMachine.updateDots[i].sprite = foodMachine.updateCompleteDot;
            }
        }

        if (foodMachine.currentUpgradeNo == foodMachine.totalUpdates)
        {
            foodMachine.priceShowingObject.SetActive(false);
            foodMachine.allUpdatesDone.gameObject.SetActive(true);

        }


    }


    #endregion

    #region CheckUpgrades

    public void CheckInAnyUpgradeAvailable()
    {
        if (CheckAnyIfAnyUpgradeAvailableCoditions())
        {
            updateAvailbleImage.SetActive(true);
            TextManager.Instance.CaptiontextTime = 6f;
            TextManager.Instance.CaptionTextHandler("Alert", "New Upgrades are Avaiable! <br> If You Don't Update , It may increase the Level time and may results in Level Failure!", Color.blue, true);

        }
        else
        {
            updateAvailbleImage.SetActive(false);
        }
    }
    public bool CheckAnyIfAnyUpgradeAvailableCoditions()
    {
        int temp = 0;
        if (tv.currentUpgradeNo < tv.levelsReq.Length)
        {
            if (tv.levelsReq[tv.currentUpgradeNo] <= GetCurrentLevel())
            {
                if (tv.coinsRequired[tv.currentUpgradeNo] <= GetTotalCoins())
                {
                    tv.bellIcon.SetActive(true);
                    Debug.LogWarning("TV");
                    temp++;
                }
            }
        }
        else tv.bellIcon.SetActive(false);

        if (vehicle.currentUpgradeNo < vehicle.levelsReq.Length)
        {
            if (vehicle.levelsReq[vehicle.currentUpgradeNo] <= GetCurrentLevel())
            {
                if (vehicle.coinsRequired[vehicle.currentUpgradeNo] <= GetTotalCoins())
                {
                    Debug.LogWarning("Vehcile");
                    vehicle.bellIcon.SetActive(true);
                    temp++;
                }
            }
        }
        else vehicle.bellIcon.SetActive(false);

        if (decoration.currentUpgradeNo < decoration.levelsReq.Length)
        {
            if (decoration.levelsReq[decoration.currentUpgradeNo] <= GetCurrentLevel())
            {
                if (decoration.coinsRequired[decoration.currentUpgradeNo] <= GetTotalCoins())
                {
                    Debug.LogWarning("Dec");
                    decoration.bellIcon.SetActive(true);
                    temp++;
                }
            }
        }
        else decoration.bellIcon.SetActive(false);

        if (wallArt.currentUpgradeNo < wallArt.levelsReq.Length)
        {
            if (wallArt.levelsReq[wallArt.currentUpgradeNo] <= GetCurrentLevel())
            {
                if (wallArt.coinsRequired[wallArt.currentUpgradeNo] <= GetTotalCoins())
                {
                    Debug.LogWarning("WA");
                    wallArt.bellIcon.SetActive(true);
                    temp++;
                }
            }
        }
        else wallArt.bellIcon.SetActive(false);

        if (vegetation.currentUpgradeNo < vegetation.levelsReq.Length)
        {
            if (vegetation.levelsReq[vegetation.currentUpgradeNo] <= GetCurrentLevel())
            {
                if (vegetation.coinsRequired[vegetation.currentUpgradeNo] <= GetTotalCoins())
                {
                    Debug.LogWarning("Veg");
                    vegetation.bellIcon.SetActive(true);
                    temp++;
                }
            }
        }
        else vegetation.bellIcon.SetActive(false);

        if (soundSystem.currentUpgradeNo < soundSystem.levelsReq.Length)
        {
            if (soundSystem.levelsReq[soundSystem.currentUpgradeNo] <= GetCurrentLevel())
            {
                if (soundSystem.coinsRequired[soundSystem.currentUpgradeNo] <= GetTotalCoins())
                {
                    Debug.LogWarning("SS");
                    soundSystem.bellIcon.SetActive(true);
                    temp++;
                }
            }
        }
        else soundSystem.bellIcon.SetActive(false);

        if (foodMachine.currentUpgradeNo < foodMachine.levelsReq.Length)
        {
            if (foodMachine.levelsReq[foodMachine.currentUpgradeNo] <= GetCurrentLevel())
            {
                if (foodMachine.coinsRequired[foodMachine.currentUpgradeNo] <= GetTotalCoins())
                {
                    Debug.LogWarning("FM");
                    foodMachine.bellIcon.SetActive(true);
                    temp++;
                }
            }
        }
        else foodMachine.bellIcon.SetActive(false);

        if (temp > 0)
            return true;
        return false;
    }
    #endregion

    #region BasicFunction
    public int GetTotalCoins()
    {
        return GameManager.Instance.globalCoins;
    }
    public int GetCurrentLevel()
    {
        return GameManager.Instance.lastUnlockedLevel;
        
    }
    public void SetFoodSpeed(int speed)
    {

    }

    public void ShowMessage(string message, int time)
    {
        TextManager.Instance.ShowToast(message, time);
    }

    #endregion
}



