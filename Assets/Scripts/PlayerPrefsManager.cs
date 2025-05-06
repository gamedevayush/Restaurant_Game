using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPrefsManager : MonoBehaviour
{
    public BuildFood buildFood;
    [System.Serializable]
    public class PlayerPrefsManagement
    {
        public TMP_Text current;
        public TMP_InputField Desired;
    }
    public string[] foodnames;
    public PlayerPrefsManagement level, vehicle, islearnt, coins, speed, stock;
    void OnEnable()
    {
        level.current.text = PlayerPrefs.GetInt("Level", 1).ToString();
        vehicle.current.text = PlayerPrefs.GetInt("VehicleUpgrade", 1).ToString();
        islearnt.current.text = PlayerPrefs.GetInt("isLearnt", 0).ToString();
        coins.current.text = PlayerPrefs.GetInt("globalCoins", 100).ToString();
        speed.current.text = Time.timeScale.ToString();
    }

    // Update is called once per frame
    public void ChangeValues(string name)

    {
        if (name == "stock")
        {
            for (int i = 0; i < foodnames.Length; i++)
            {
                FoodEngine.Instance.AddFood(foodnames[i], int.Parse(stock.Desired.text));
                FoodCounter.Instance.AddFood(foodnames[i], int.Parse(stock.Desired.text));
            }
            StockInventory.Instance.UpdateFoodStockUI();
        }
        if (name == "level")
        {
            PlayerPrefs.SetInt("Level", int.Parse(level.Desired.text));
        }
        if (name == "coins")
        {
            PlayerPrefs.SetInt("globalCoins", int.Parse(coins.Desired.text));
        }
        if (name == "learnt")
        {
            PlayerPrefs.SetInt("isLearnt", int.Parse(islearnt.Desired.text));
        }
        if (name == "vehicle")
        {
            PlayerPrefs.SetInt("VehicleUpgrade", int.Parse(vehicle.Desired.text));
        }
        if (name == "speed")
        {
            Time.timeScale = float.Parse(speed.Desired.text);
            speed.current.text = Time.timeScale.ToString();
        }
    }
}
