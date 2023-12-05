using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodEngine : MonoBehaviour
{


    
   

    public Conditions conditions;

    [System.Serializable]
    public class currentFoodUI
    {
        public Text SamosaText, TeaText, PakoraText, PaneerTikka;
    }
    [SerializeField]

    public currentFoodUI currenttFoodUI;
    
    public static FoodEngine Instance  { get; set;}

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

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool buildFood(string food,int quantity)
    {
        if (food == "Samosa")
        {

          
            bool isValid = checkConditionForSamosa(quantity);
            if (isValid)
            {
               
                return true;
            }
            else
                return false;
        }
        if (food == "PaneerTikka")
        {
            bool isValid = checkConditionForPaneerTikka(quantity);
            if (isValid)
            {
              
                return true;
            }
            else
                return false;
        }

        if (food == "Tea")
        {
            bool isValid = checkConditionForTea(quantity);
            if (isValid)
            {
               
                return true;
            }
            else
            {
                return false;
            }

            //bool isAvailable = checkConditionForSamosa();
            //StockInventory.Instance.currentFoodStocks.samosa += 1;

        }

        if (food == "Pakora")
        {
            bool isValid = checkConditionForPakora(quantity);
            //Debug.Log("Pakora valid" + isValid);
            if (isValid)
            {
              
                return true;
               
            }
            else
            {
                return false;
            }
        }

        return false;

    }

	public void RemoveFoodIngre(string food, int quantity)
	{
		if(food.Equals("Samosa",System.StringComparison.OrdinalIgnoreCase))
        {
          removeSamosaIngredients(quantity); 
        }

        if (food.Equals("PaneerTikka",System.StringComparison.OrdinalIgnoreCase))
        {
           removePaneerTikkaIngredients(quantity);
        }


        if (food.Equals("Tea",System.StringComparison.OrdinalIgnoreCase))
        {
          removeTeaIngredients(quantity);
        }

        if(food.Equals("Pakora",System.StringComparison.OrdinalIgnoreCase))
        {
           removePakoraIngredients(quantity);
        }
		StockInventory.Instance.UpdateIngredientStockUI();
	}
    public void AddFood(string food,int quantity)
    {
        SoundManager.Instance.PlaySound("ting");
        if(food.Equals("Samosa",System.StringComparison.OrdinalIgnoreCase))
        {

            StockInventory.Instance.currentFoodStocks.samosa += quantity;
            currenttFoodUI.SamosaText.text = StockInventory.Instance.currentFoodStocks.samosa.ToString();
           // removeSamosaIngredients(quantity);
            
        }

        if (food.Equals("PaneerTikka",System.StringComparison.OrdinalIgnoreCase))
        {
            StockInventory.Instance.currentFoodStocks.paneerTikka += quantity;
            currenttFoodUI.PaneerTikka.text = StockInventory.Instance.currentFoodStocks.paneerTikka.ToString();
           // removePaneerTikkaIngredients(quantity);
        }


        if (food.Equals("Tea",System.StringComparison.OrdinalIgnoreCase))
        {
            Debug.Log("Tea is added");
            StockInventory.Instance.currentFoodStocks.tea += quantity;
            currenttFoodUI.TeaText.text = StockInventory.Instance.currentFoodStocks.tea.ToString();
          //  removeTeaIngredients(quantity);
        }

        if(food.Equals("Pakora",System.StringComparison.OrdinalIgnoreCase))
        {
            StockInventory.Instance.currentFoodStocks.pakora += quantity;
            currenttFoodUI.PakoraText.text = StockInventory.Instance.currentFoodStocks.pakora.ToString();
           // removePakoraIngredients(quantity);
            
        }

        StockInventory.Instance.UpdateIngredientStockUI();
    }
    bool checkConditionForSamosa(int quantity)
    {
        if(StockInventory.Instance.currentIngredientStocks.flour  >= conditions.forSamosa.flour * quantity)
        {
          
        }
        else
        {
            return false;
        }
        if (StockInventory.Instance.currentIngredientStocks.besan >= conditions.forSamosa.besan *quantity )
        {
           
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.spice >= conditions.forSamosa.spice * quantity)
        {
           
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.milk >= conditions.forSamosa.milk * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.potato >= conditions.forSamosa.potato * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.sugar >= conditions.forSamosa.sugar * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.tealeaves >= conditions.forSamosa.tea_leaves * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.oil >= conditions.forSamosa.oil * quantity)
        {
            
        }
        else
        {
            return false;
        }

        return true;


    }

    public void removeSamosaIngredients(int quantity)
    {
        StockInventory.Instance.currentIngredientStocks.flour = StockInventory.Instance.currentIngredientStocks.flour - conditions.forSamosa.flour * quantity;
        StockInventory.Instance.currentIngredientStocks.besan = StockInventory.Instance.currentIngredientStocks.besan - conditions.forSamosa.besan * quantity;
        StockInventory.Instance.currentIngredientStocks.spice = StockInventory.Instance.currentIngredientStocks.spice - conditions.forSamosa.spice * quantity;
        StockInventory.Instance.currentIngredientStocks.milk = StockInventory.Instance.currentIngredientStocks.milk - conditions.forSamosa.milk * quantity;
        StockInventory.Instance.currentIngredientStocks.potato = StockInventory.Instance.currentIngredientStocks.potato - conditions.forSamosa.potato * quantity;
        StockInventory.Instance.currentIngredientStocks.sugar = StockInventory.Instance.currentIngredientStocks.sugar - conditions.forSamosa.sugar * quantity;
        StockInventory.Instance.currentIngredientStocks.tealeaves = StockInventory.Instance.currentIngredientStocks.tealeaves - conditions.forSamosa.tea_leaves * quantity;
        StockInventory.Instance.currentIngredientStocks.oil = StockInventory.Instance.currentIngredientStocks.oil - conditions.forSamosa.oil * quantity;
    }




    bool checkConditionForTea(int quantity)
    {
        if (StockInventory.Instance.currentIngredientStocks.flour >= conditions.forTea.flour * quantity)
        {
            
        }
        else
        {
            return false;
        }
        if (StockInventory.Instance.currentIngredientStocks.besan >= conditions.forTea.besan * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.spice >= conditions.forTea.spice * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.milk >= conditions.forTea.milk * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.potato >= conditions.forTea.potato * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.sugar >= conditions.forTea.sugar * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.tealeaves >= conditions.forTea.tea_leaves * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.oil >= conditions.forTea.oil * quantity)
        {
            
        }
        else
        {
            return false;
        }

        return true;


    }


    public void removeTeaIngredients(int quantity)
    {
        StockInventory.Instance.currentIngredientStocks.flour = StockInventory.Instance.currentIngredientStocks.flour - conditions.forTea.flour * quantity;
        StockInventory.Instance.currentIngredientStocks.besan = StockInventory.Instance.currentIngredientStocks.besan - conditions.forTea.besan * quantity;
        StockInventory.Instance.currentIngredientStocks.spice = StockInventory.Instance.currentIngredientStocks.spice - conditions.forTea.spice * quantity;
        StockInventory.Instance.currentIngredientStocks.milk = StockInventory.Instance.currentIngredientStocks.milk - conditions.forTea.milk * quantity;
        StockInventory.Instance.currentIngredientStocks.potato = StockInventory.Instance.currentIngredientStocks.potato - conditions.forTea.potato * quantity;
        StockInventory.Instance.currentIngredientStocks.sugar = StockInventory.Instance.currentIngredientStocks.sugar - conditions.forTea.sugar  *quantity;
        StockInventory.Instance.currentIngredientStocks.tealeaves = StockInventory.Instance.currentIngredientStocks.tealeaves - conditions.forTea.tea_leaves * quantity;
        StockInventory.Instance.currentIngredientStocks.oil = StockInventory.Instance.currentIngredientStocks.oil - conditions.forTea.oil * quantity;

    }

    public void removePakoraIngredients(int quantity)
    {
        StockInventory.Instance.currentIngredientStocks.flour = StockInventory.Instance.currentIngredientStocks.flour - conditions.forPakora.flour * quantity;
        StockInventory.Instance.currentIngredientStocks.besan = StockInventory.Instance.currentIngredientStocks.besan - conditions.forPakora.besan * quantity;
        StockInventory.Instance.currentIngredientStocks.spice = StockInventory.Instance.currentIngredientStocks.spice - conditions.forPakora.spice * quantity;
        StockInventory.Instance.currentIngredientStocks.milk = StockInventory.Instance.currentIngredientStocks.milk - conditions.forPakora.milk * quantity;
        StockInventory.Instance.currentIngredientStocks.potato = StockInventory.Instance.currentIngredientStocks.potato - conditions.forPakora.potato * quantity;
        StockInventory.Instance.currentIngredientStocks.sugar = StockInventory.Instance.currentIngredientStocks.sugar - conditions.forPakora.sugar * quantity;
        StockInventory.Instance.currentIngredientStocks.tealeaves = StockInventory.Instance.currentIngredientStocks.tealeaves - conditions.forPakora.tea_leaves * quantity;
        StockInventory.Instance.currentIngredientStocks.oil = StockInventory.Instance.currentIngredientStocks.oil - conditions.forPakora.oil * quantity;

    }

    public void removePaneerTikkaIngredients(int quantity)
    {
        StockInventory.Instance.currentIngredientStocks.flour = StockInventory.Instance.currentIngredientStocks.flour - conditions.forPaneerTikka.flour * quantity;
        StockInventory.Instance.currentIngredientStocks.besan = StockInventory.Instance.currentIngredientStocks.besan - conditions.forPaneerTikka.besan * quantity;
        StockInventory.Instance.currentIngredientStocks.spice = StockInventory.Instance.currentIngredientStocks.spice - conditions.forPaneerTikka.spice * quantity;
        StockInventory.Instance.currentIngredientStocks.milk = StockInventory.Instance.currentIngredientStocks.milk - conditions.forPaneerTikka.milk * quantity;
        StockInventory.Instance.currentIngredientStocks.potato = StockInventory.Instance.currentIngredientStocks.potato - conditions.forPaneerTikka.potato * quantity;
        StockInventory.Instance.currentIngredientStocks.sugar = StockInventory.Instance.currentIngredientStocks.sugar - conditions.forPaneerTikka.sugar * quantity;
        StockInventory.Instance.currentIngredientStocks.tealeaves = StockInventory.Instance.currentIngredientStocks.tealeaves - conditions.forPaneerTikka.tea_leaves * quantity;
        StockInventory.Instance.currentIngredientStocks.oil = StockInventory.Instance.currentIngredientStocks.oil - conditions.forPaneerTikka.oil * quantity;

    }
    bool checkConditionForPakora(int quantity)
    {
        if (StockInventory.Instance.currentIngredientStocks.flour >= conditions.forPakora.flour * quantity)
        {
            
        }
        else
        {
            return false;
        }
        if (StockInventory.Instance.currentIngredientStocks.besan >= conditions.forPakora.besan * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.spice >= conditions.forPakora.spice * quantity)
        {
         
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.milk >= conditions.forPakora.milk * quantity)
        {
         
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.potato >= conditions.forPakora.potato * quantity)
        {
          
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.sugar >= conditions.forPakora.sugar * quantity)
        {
           
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.tealeaves >= conditions.forPakora.tea_leaves * quantity)
        {
        
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.oil >= conditions.forPakora.oil * quantity)
        {
          
        }
        else
        {
            return false;
        }

        return true;


    }

    bool checkConditionForPaneerTikka(int quantity)
    {
        if (StockInventory.Instance.currentIngredientStocks.flour >= conditions.forPaneerTikka.flour * quantity)
        {
           
        }
        else
        {
            return false;
        }
        if (StockInventory.Instance.currentIngredientStocks.besan >= conditions.forPaneerTikka.besan * quantity)
        {
           
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.spice >= conditions.forPaneerTikka.spice * quantity)
        {
         
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.milk >= conditions.forPaneerTikka.milk * quantity)
        {
          
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.potato >= conditions.forPaneerTikka.potato * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.sugar >= conditions.forPaneerTikka.sugar * quantity)
        {
           
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.tealeaves >= conditions.forPaneerTikka.tea_leaves * quantity)
        {
           
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.oil >= conditions.forPaneerTikka.oil * quantity)
        {
          
        }
        else
        {
            return false;
        }

        return true;


    }



    bool checkConditionForSamosa()
    {
        if( StockInventory.Instance.currentIngredientStocks.potato < conditions.forSamosa.potato)
        {
            return false;
        }
        else
        {
            StockInventory.Instance.currentIngredientStocks.potato -= conditions.forSamosa.potato;
        }
        if (StockInventory.Instance.currentIngredientStocks.flour< conditions.forSamosa.flour)
        {
            return false;
        }
        if (StockInventory.Instance.currentIngredientStocks.spice < conditions.forSamosa.spice)
        {
            return false;
        }
        if (StockInventory.Instance.currentIngredientStocks.oil < conditions.forSamosa.oil)
        {
            return false;
        }
        if (StockInventory.Instance.currentIngredientStocks.besan < conditions.forSamosa.besan)
        {
            return false;
        }
        if (StockInventory.Instance.currentIngredientStocks.tealeaves < conditions.forSamosa.tea_leaves)
        {
            return false;
        }
        if (StockInventory.Instance.currentIngredientStocks.sugar < conditions.forSamosa.sugar)
        {
            return false;
        }
        if (StockInventory.Instance.currentIngredientStocks.milk < conditions.forSamosa.milk)
        {
            return false;
        }
        return true;
    }
}

    



