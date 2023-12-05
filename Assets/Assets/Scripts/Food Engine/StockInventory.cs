using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StockInventory : MonoBehaviour
{

    [System.Serializable]
    public class IngredientStocks
    {
        public float potato = 1;
        public TMP_Text PotatoText;
        public float flour = 1;
        public TMP_Text FlourText;
        public float spice = 1;
        public TMP_Text SpiceText;
        public float oil = 1;
        public TMP_Text OilText;
        public float besan = 1;
        public TMP_Text BesanText;
        public float sugar = 1;
        public TMP_Text SugarText;
        public float milk = 1;
        public TMP_Text MilkText;
        public float tealeaves = 1;
        public TMP_Text TeaLeavesText;
    }


    [SerializeField]

    [System.Serializable]
    public class IngredientsPrice
    {
        public int potato = 1;  
        public int flour = 1;
        public int spice = 1;
        public int oil = 2;
        public int besan = 2;
        public int tea_leaves = 2;
        public int sugar = 1;
        public int milk = 2;
    }
    [SerializeField]

    public IngredientStocks currentIngredientStocks;
    public IngredientsPrice ingredientsPrice;
   
    [System.Serializable]
    public class FoodStock
    {
        public int samosa = 1;   //Cost = 5  //Selling price = 10 (Reqiurements = 1Potato,1 flour, 1 spice,2oil)
        public int paneerTikka = 1; //Cost =15   //Selling Price =30  (Rq= 5milk,1 spice,2oil)
        public int tea = 1;//Cost=6   //Selling Price=20      (Rq= 1milk,1tealeaves,1sugar,1spice)
        public int pakora = 1;//Cost = 6   //Selling Price =15       (Reqiurements = 1Potato,1 besan, 1 spice,2oil)
        public TMP_Text FoodItemsText;//Cost=   //Selling Price =
    }
    [SerializeField]

    [System.Serializable]
    public class FoodCost
    {
        public int samosa = 10;
        public int paneerTikka = 30;
        public int tea = 20;
        public int pakora = 15;
       
    }
    [SerializeField]

    public FoodCost costOfFoods;

    public FoodStock currentFoodStocks;



    public static StockInventory Instance { get; set; }
    void Start()
    {
      
		
    }

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

        UpdateFoodStockUI();
        UpdateIngredientStockUI();
    }

	
    void Update()
    {
        
    }
	
	
	public float totalIngredientStock()
	{
		float sum = 0;
		sum += (currentIngredientStocks.besan + currentIngredientStocks.tealeaves + currentIngredientStocks.sugar);
		sum += currentIngredientStocks.spice + currentIngredientStocks.milk + currentIngredientStocks.potato;
		sum += currentIngredientStocks.oil + currentIngredientStocks.flour;
		return sum;
	}

    public void UpdateFoodStockUI()
    {
        currentFoodStocks.FoodItemsText.text = "<sprite=8>" + currentFoodStocks.samosa.ToString() + "  <sprite=10>" + currentFoodStocks.pakora.ToString() + "  <sprite=11>" + currentFoodStocks.tea.ToString() + "  <sprite=9>" + currentFoodStocks.paneerTikka.ToString();
    }
    public void UpdateIngredientStockUI()
    {
        currentIngredientStocks.PotatoText.text = "<sprite=0>" + currentIngredientStocks.potato.ToString();
        currentIngredientStocks.FlourText.text = "<sprite=1>" + currentIngredientStocks.flour.ToString();
        currentIngredientStocks.SpiceText.text = "<sprite=2>" + currentIngredientStocks.spice.ToString();
        currentIngredientStocks.OilText.text = "<sprite=3>" + currentIngredientStocks.oil.ToString();
        currentIngredientStocks.BesanText.text = "<sprite=4>" + currentIngredientStocks.besan.ToString();
        currentIngredientStocks.SugarText.text = "<sprite=5>" + currentIngredientStocks.sugar.ToString();
        currentIngredientStocks.MilkText.text = "<sprite=7>" + currentIngredientStocks.milk.ToString();
        currentIngredientStocks.TeaLeavesText.text = "<sprite=6>" + currentIngredientStocks.tealeaves.ToString();
    }


    public string GenerateRandomFood()
    {
        #region OLDCODE
        /**
        int maxSamosa = LevelManager.Instance.currentLevel.maxSamosa;
		int maxTea = LevelManager.Instance.currentLevel.maxTea;
		int maxPaneerTikka = LevelManager.Instance.currentLevel.maxPaneerTikka;
		int maxPakori = LevelManager.Instance.currentLevel.maxPakori;
		List<string> itemsAvaible = new List<string>();
		
		if(maxSamosa>0)
			itemsAvaible.Add("Samosa");
		if(maxTea>0)
			itemsAvaible.Add("Tea");
		if(maxPaneerTikka>0)
			itemsAvaible.Add("PaneerTikka");
		if(maxPakori>0)
			itemsAvaible.Add("Pakora");
		
        int foodNo = Random.Range(0,itemsAvaible.Count);
        **/
        #endregion
        // string foodItem = itemsAvaible[foodNo];

        // return foodItem;
        return "";

      

      

    }

    

    public int CalculateAmount(string foodItem, int quantity)
    {

        if(foodItem == "Samosa")
        {
            return quantity * costOfFoods.samosa;
        }
        if (foodItem == "Pakora")
        {
            return quantity * costOfFoods.pakora;
        }
        if (foodItem == "PaneerTikka")
        {
            return quantity * costOfFoods.paneerTikka;
        }
        if (foodItem == "Tea")
        {
            return quantity * costOfFoods.tea;
        }

        return 0;

    }

    public void AddAmountToCoin(int amount)
    {
        Debug.Log("Amount Added"+amount);
    }


    public void AddStocks(string item, int quantity)
    {
		if (item == "flour")
        {
            currentIngredientStocks.flour += quantity;
        }
        if (item == "potato")
        {
            currentIngredientStocks.potato += quantity;
        }
        if (item == "besan")
        {
            currentIngredientStocks.besan += quantity;
        }
        if (item == "milk" )
        {
            currentIngredientStocks.milk += quantity;
        }
        if (item == "tea_leaves")
        {
            currentIngredientStocks.tealeaves += quantity;
        }
        if (item == "oil")
        {
            currentIngredientStocks.oil += quantity;
        }
        if (item == "sugar")
        {
            currentIngredientStocks.sugar += quantity;
        }
        if (item == "spice")
        {
            currentIngredientStocks.spice += quantity;
        }

        UpdateIngredientStockUI();
    }


    

    public bool CheckCurrentFoodStock(string foodName, int quantity)
    {
        if (foodName.Equals("Samosa", System.StringComparison.OrdinalIgnoreCase))
        {
            if (currentFoodStocks.samosa >= quantity)
                return true;
            else
                return false;
        }

        if (foodName.Equals("Pakora", System.StringComparison.OrdinalIgnoreCase))
        {
            if (currentFoodStocks.pakora >= quantity)
                return true;
            else
                return false;
        }

        if (foodName.Equals("PaneerTikka", System.StringComparison.OrdinalIgnoreCase))
        {
            if (currentFoodStocks.paneerTikka>= quantity)
                return true;
            else
                return false;
        }
        if (foodName.Equals("Tea", System.StringComparison.OrdinalIgnoreCase))
        {
            if (currentFoodStocks.tea >= quantity)
                return true;
            else
                return false;
        }
        else
        {
            Debug.Log("Wrong Food Passed For" + foodName);
            return false;
        }



    }
}
