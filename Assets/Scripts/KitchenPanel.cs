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
    public Toggle condition1, condition2, condition3, condition4,condition5;
    public GameObject buildTray1, buildTray2, buildTray3, buildTray4, buildTray5;
    public Color forSatisfied;
    public GameObject openButton;
    
    void Start()
    {
        KPanel.SetActive(false);

    }
    void OnTriggerEnter(Collider col)
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("foodModel");
      
        if (col.tag == "Player")
        {
            if (PlayerFoodHandling.Instance.currentFood.Equals("UniversalFood", System.StringComparison.OrdinalIgnoreCase))
            {
                TextManager.Instance.ShowToast("You Already Have A Tray", 2);
                return;
            }
            CalculateHutInfo();
            SetHutInfo();
            //CheckConditons();
            KPanel.SetActive(true);
       
        }
    }

    // Update is called once per frame
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
      

        if (hutsManager.hut1.isOccupied)
        {
            hut1.quantity = hutsManager.hut1.hutMarker.GetComponent<MarkerTrigger>().quntity;
            hut1.item = hutsManager.hut1.hutMarker.GetComponent<MarkerTrigger>().foodName;


            if (StockInventory.Instance.CheckCurrentFoodStock(hut1.item, hut1.quantity))
            {

                condition1.isOn = true;
                buildTray1.SetActive(true);
            }
            else
            {
                condition1.isOn = false;
                buildTray1.SetActive(false);
            }
          
        }
        else
        {
            hut1.quantity = 0;
            hut1.item = null;
            condition1.isOn = false;
            buildTray1.SetActive(false);
        }

        if (hutsManager.hut2.isOccupied)
        {
            hut2.quantity = hutsManager.hut2.hutMarker.GetComponent<MarkerTrigger>().quntity;
            hut2.item = hutsManager.hut2.hutMarker.GetComponent<MarkerTrigger>().foodName;

            if (StockInventory.Instance.CheckCurrentFoodStock(hut2.item, hut2.quantity))
            {

                condition2.isOn = true;
                buildTray2.SetActive(true);
            }
            else
            {     
                    condition2.isOn = false;
                buildTray2.SetActive(false);
            }
        }
        else
        {
            hut2.quantity = 0;
            hut2.item = null;
            condition2.isOn = false;
            buildTray2.SetActive(false);
        }


        //For HUT3

        if (hutsManager.hut3.isOccupied)
        {
            hut3.quantity = hutsManager.hut3.hutMarker.GetComponent<MarkerTrigger>().quntity;
            hut3.item = hutsManager.hut3.hutMarker.GetComponent<MarkerTrigger>().foodName;


            if (StockInventory.Instance.CheckCurrentFoodStock(hut3.item, hut3.quantity))
            {

                condition3.isOn = true;
                buildTray3.SetActive(true);
            }
            else
            { 
                    condition3.isOn = false;
                buildTray3.SetActive(false);
            }
        }
        else
        {
            hut3.quantity = 0;
            hut3.item = null;
            condition3.isOn = false;
            buildTray3.SetActive(false);
        }

        //FOR HUT 4
        if (hutsManager.hut4.isOccupied)
        {
            hut4.quantity = hutsManager.hut4.hutMarker.GetComponent<MarkerTrigger>().quntity;
            hut4.item = hutsManager.hut4.hutMarker.GetComponent<MarkerTrigger>().foodName;


            if (StockInventory.Instance.CheckCurrentFoodStock(hut4.item, hut4.quantity))
            {

                condition4.isOn = true;
                buildTray4.SetActive(true);
            }
            else
            { 
                    condition4.isOn = false;
                buildTray4.SetActive(false);
            }
        }
        else
        {
            hut4.quantity = 0;
            hut4.item = null;
            condition4.isOn = false;
            buildTray4.SetActive(false);

        }


        //FOR HUT5

        if (hutsManager.hut5.isOccupied)
        {
            hut5.quantity = hutsManager.hut5.hutMarker.GetComponent<MarkerTrigger>().quntity;
            hut5.item = hutsManager.hut5.hutMarker.GetComponent<MarkerTrigger>().foodName;


            if (StockInventory.Instance.CheckCurrentFoodStock(hut5.item, hut5.quantity))
            {
                condition5.isOn = true;
                buildTray5.SetActive(true);
            }
            else
            { 
                    condition5.isOn = false;
                buildTray5.SetActive(false);
            }

        }
        else
        {
            hut5.quantity = 0;
            hut5.item = null;
            condition5.isOn = false;
            buildTray5.SetActive(false);
        }

    }

    public void SetHutInfo()
    {
        if (hut1.quantity > 0)
            hut1UI.text = hut1.quantity + "  "+GetFoodCode(hut1.item);
        else
        {
            if(!hutsManager.hut1.isAvailable)
            {
                hut1UI.text = "Requirements Fullfilled";
            }
            else
            {
                hut1UI.text = "No Coustomer";
            }
        }

        if (hut2.quantity >0)
            hut2UI.text = hut2.quantity + "  " + GetFoodCode(hut2.item);
        else
        {
            if (!hutsManager.hut2.isAvailable)
            {
                hut2UI.text = "Requirements Fullfilled";
            }
            else
            {
                hut2UI.text = "No Coustomer";
            }
        }

        if (hut3.quantity >0)
            hut3UI.text = hut3.quantity + "  " + GetFoodCode(hut3.item);
        else
        {
            if (!hutsManager.hut3.isAvailable)
            {
                hut3UI.text = "Requirements Fullfilled";
            }
            else
            {
                hut3UI.text = "No Coustomer";
            }
        }

        if (hut4.quantity > 0)
            hut4UI.text = hut4.quantity + "  " + GetFoodCode(hut4.item);
        else
        {
            if (!hutsManager.hut4.isAvailable)
            {
                hut4UI.text = "Requirements Fullfilled";
            }
            else
            {
                hut4UI.text = "No Coustomer";
            }
        }   

        if (hut5.quantity > 0)
            hut5UI.text = hut5.quantity + "  " + GetFoodCode( hut5.item);
        else
        {
            if (!hutsManager.hut5.isAvailable)
            {
                hut5UI.text = "Requirements Fullfilled";
            }
            else
            {
                hut5UI.text = "No Coustomer";
            }
        }//Test kro bahiya 
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
        if (hutNo == 1 && condition1.isOn)
        {
            buildTray1.SetActive(false);
            TextManager.Instance.ShowToast(hut1.item + " Is ADDED", 2);
            PlayerFoodHandling.Instance.PickFood("UniversalFood");
            PlayerFoodHandling.Instance.itemName = hut1.item;
            KPanel.SetActive(false);
        }

        if (hutNo == 2 && condition2.isOn)
        {
            buildTray2.SetActive(false);
            TextManager.Instance.ShowToast(hut2.item + " Is ADDED", 2);
            PlayerFoodHandling.Instance.PickFood("UniversalFood");
            PlayerFoodHandling.Instance.itemName = hut2.item;
            KPanel.SetActive(false);
        }

        if (hutNo == 3 && condition3.isOn)
        {
            buildTray3.SetActive(false);
            PlayerFoodHandling.Instance.PickFood("UniversalFood");
            TextManager.Instance.ShowToast(hut3.item + " Is ADDED", 2);
            PlayerFoodHandling.Instance.itemName = hut3.item;
            KPanel.SetActive(false);
        }

        if (hutNo == 4 && condition4.isOn)
        {

            buildTray4.SetActive(false);
            PlayerFoodHandling.Instance.PickFood("UniversalFood");
            TextManager.Instance.ShowToast(hut4.item + " Is ADDED", 2);
            PlayerFoodHandling.Instance.itemName = hut4.item;
            KPanel.SetActive(false);
        }


        if (hutNo == 5 && condition5.isOn)
        {
            buildTray5.SetActive(false);
            PlayerFoodHandling.Instance.PickFood("UniversalFood");
            PlayerFoodHandling.Instance.itemName = hut5.item;
            TextManager.Instance.ShowToast(hut5.item + " Is ADDED", 2);
            KPanel.SetActive(false);
        }

    

    }

    private void OnTriggerStay(Collider other)
    {
        if (KPanel.active)
        {
            openButton.SetActive(false);
        }
        else
            openButton.SetActive(true);
    }

    public void OpenKitchen()
    {
        if (PlayerFoodHandling.Instance.currentFood.Equals("UniversalFood", System.StringComparison.OrdinalIgnoreCase))
        {
            TextManager.Instance.ShowToast("You Already Have A Tray", 2);
            return;
        }
        CalculateHutInfo();
        SetHutInfo();
        //CheckConditons();
        KPanel.SetActive(true);
    }




}

public struct hutInfo
{
   public int quantity;
   public string item;
}


