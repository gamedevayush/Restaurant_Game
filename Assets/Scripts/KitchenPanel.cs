using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KitchenPanel : MonoBehaviour
{
    public GameObject KPanel;
    public HutsManager hutsManager;
    public hutInfo hut1, hut2, hut3, hut4, hut5;
    public TMP_Text hut1UI, hut2UI, hut3UI, hut4UI, hut5UI;
    public Toggle condition1, condition2, condition3, condition4, condition5;
    public GameObject buildTray1, buildTray2, buildTray3, buildTray4, buildTray5;
    public Color forSatisfied;
    public GameObject openButton;


    void Start()
    {
        KPanel.SetActive(false);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            openButton.SetActive(true);
            if (GameManager.Instance.isLearnt() == false)
            {
                FindAnyObjectByType<FirstTimeManager>().ShowStep(33);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            openButton.SetActive(true);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            KPanel.SetActive(false);
            openButton.SetActive(false);
        }
    }

    public void CalculateHutInfo()
    {
        ProcessHut(hutsManager.hut1, hut1, condition1, buildTray1);
        ProcessHut(hutsManager.hut2, hut2, condition2, buildTray2);
        ProcessHut(hutsManager.hut3, hut3, condition3, buildTray3);
        ProcessHut(hutsManager.hut4, hut4, condition4, buildTray4);
        ProcessHut(hutsManager.hut5, hut5, condition5, buildTray5);
    }

    private void ProcessHut(HutsManager.HutsInfo hutManager, hutInfo hutData, Toggle condition, GameObject buildTray)
    {
        if (hutManager.isOccupied)
        {
            MarkerTrigger marker = hutManager.hutMarker.GetComponent<MarkerTrigger>();
            hutData.quantity = marker.quantity;
            hutData.item = marker.foodName;

            if (StockInventory.Instance.CheckCurrentFoodStock(hutData.item, hutData.quantity))
            {
                condition.isOn = true;
                buildTray.SetActive(true);
            }
            else
            {
                condition.isOn = false;
                buildTray.SetActive(false);
            }
        }
        else
        {
            hutData.quantity = 0;
            hutData.item = null;
            condition.isOn = false;
            buildTray.SetActive(false);
        }
    }

    public void SetHutInfo()
    {
        SetHutUI(hut1, hutsManager.hut1, hut1UI);
        SetHutUI(hut2, hutsManager.hut2, hut2UI);
        SetHutUI(hut3, hutsManager.hut3, hut3UI);
        SetHutUI(hut4, hutsManager.hut4, hut4UI);
        SetHutUI(hut5, hutsManager.hut5, hut5UI);
    }

    private void SetHutUI(hutInfo hutData, HutsManager.HutsInfo hutManager, TMP_Text hutUI)
    {
        if (hutData.quantity > 0)
        {
            hutUI.text = hutData.quantity + "  " + GetFoodCode(hutData.item);
        }
        else
        {
            hutUI.text = !hutManager.isAvailable ? "Requirements Fulfilled" : "No Customer";
        }
    }




    public string GetFoodCode(string food)
    {
        if (food.Equals("Samosa", System.StringComparison.OrdinalIgnoreCase))
            return "<sprite=08>";
        if (food.Equals("PaneerTikka", System.StringComparison.OrdinalIgnoreCase))
            return "<sprite=09>";
        if (food.Equals("Pakora", System.StringComparison.OrdinalIgnoreCase))
            return "<sprite=10>";
        if (food.Equals("Tea", System.StringComparison.OrdinalIgnoreCase))
            return "<sprite=11>";

        Debug.LogWarning("Wrong Food Passed In Get Food Code");
        return "";
    }

    public void SetTray(int hutNo)
    {
        ProcessTray(hutNo, condition1, buildTray1, hut1, 1);
        ProcessTray(hutNo, condition2, buildTray2, hut2, 2);
        ProcessTray(hutNo, condition3, buildTray3, hut3, 3);
        ProcessTray(hutNo, condition4, buildTray4, hut4, 4);
        ProcessTray(hutNo, condition5, buildTray5, hut5, 5);
    }

    private void ProcessTray(int hutNo, Toggle condition, GameObject buildTray, hutInfo hutData, int hutIndex)
    {
        if (hutNo == hutIndex && condition.isOn)
        {
            buildTray.SetActive(false);
            PlayerFoodHandling.Instance.PickFood("UniversalFood");
            PlayerFoodHandling.Instance.itemName = hutData.item;
            ToastManager.Instance.ShowToast(hutData.item + " Is ADDED", 2);
            KPanel.SetActive(false);
        }
    }




    public void OpenKitchen()
    {
        if (PlayerFoodHandling.Instance.currentFood.Equals("UniversalFood", System.StringComparison.OrdinalIgnoreCase))
        {
            ToastManager.Instance.ShowToast("You Already Have A Tray", 2);
            return;
        }
        CalculateHutInfo();
        SetHutInfo();
        KPanel.SetActive(true);
    }
}

public struct hutInfo
{
    public int quantity;
    public string item;
}


