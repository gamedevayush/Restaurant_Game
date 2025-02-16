using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerTrigger : MonoBehaviour
{

    public string foodName;
    public int quantity;
   public  CustomerAI customer;
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bool isTrue =  CheckConditionSuccessful();
            if (isTrue )
            {
                if (PlayerFoodHandling.Instance.itemName.Equals(foodName, System.StringComparison.OrdinalIgnoreCase))
                {
                    SubtractFoodItems();
                    StockInventory.Instance.UpdateFoodStockUI();
                    customer.ServeFood();
                    foodName = "";
                    quantity = 0;
                    PlayerFoodHandling.Instance.RemoveFood("UniversalFood");
                    Debug.Log("COnditions Satisfied");
                    ToastManager.Instance.ShowToast("FOOD SERVED", 3);
                    this.gameObject.SetActive(false);
                }
                else
                {
                    Debug.Log("Wrong Tray Delivered");
                    ToastManager.Instance.ShowToast("Wrong Tray", 1);
                }
            }
            else
                Debug.Log("Condtions Not Matched");
        }
    }

    public bool CheckConditionSuccessful()
    {
		Debug.Log("FoodName: "+foodName);
        if(foodName == "Samosa")
        if (StockInventory.Instance.currentFoodStocks.samosa >= quantity)
        {
			Debug.Log("Samosa is less than needed");
                return true;
        }

        if (foodName == "Tea")
            if (StockInventory.Instance.currentFoodStocks.tea >= quantity)
            {
				Debug.Log("Tea is less than needed");
                return true;
            }

        if (foodName == "PaneerTikka")
            if (StockInventory.Instance.currentFoodStocks.paneerTikka >= quantity)
            {
				Debug.Log("PTikka is less than needed");
                return true;
            }

        if (foodName == "Pakora")
            if (StockInventory.Instance.currentFoodStocks.pakora >= quantity)
            {
				Debug.Log("Pakora is less than needed");
                return true;
            }


        return false;
    }


    void SubtractFoodItems()
    {
        if (foodName == "Samosa")
            StockInventory.Instance.currentFoodStocks.samosa -= quantity;

        if (foodName == "Tea")
            StockInventory.Instance.currentFoodStocks.tea -= quantity;


        if (foodName == "PaneerTikka")
            StockInventory.Instance.currentFoodStocks.paneerTikka -= quantity;

        if (foodName == "Pakora")
            StockInventory.Instance.currentFoodStocks.pakora -= quantity;
            
               
    }   
}
