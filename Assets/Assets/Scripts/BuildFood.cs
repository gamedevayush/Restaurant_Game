using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class BuildFood : MonoBehaviour
{
    // Start is called before the first frame update
    
    ItemHandler[] items;
    public string[] foodNames;
    public int[] quantities;
	public float delayTime;
    public GameObject AOSliderHolder;
    public GameObject ItemHolder;
	public GameObject foodingUI,nonFoodingUI;
    public Slider foodSlider;
    public Slider foodSlider2;
	public KitchenPanel kPanel;

    public AudioSource src;
  
	
    void Start()
    {
        foodingUI.SetActive(true);
		nonFoodingUI.SetActive(false);
       
        foodSlider.value = 100f;
        foodSlider2.value = 100f;
        AOSliderHolder.SetActive(false);

        src = this.GetComponent<AudioSource>();
    }


    public void closeButton()
    {
        foreach (Transform child in ItemHolder.transform)
        {
            child.gameObject.GetComponent<ItemHandler>().RemoveMe();
        }
    }


    public void BuildFoood()
    {
		items = ItemHolder.GetComponentsInChildren<ItemHandler>();
		if(items.Length==0)
		{
			return;
		}
        SetDelayTime();
		StartCoroutine(foodDelay());
		
	}
		
	IEnumerator foodDelay()
	{
		items = ItemHolder.GetComponentsInChildren<ItemHandler>();
        foodNames = new string[items.Length + 1];
        quantities = new int[items.Length + 1];

        for (int i = 0; i < items.Length; i++)
        { 
            foodNames[i] = items[i].name;
            quantities[i] = items[i].quantity;
        }
		foodingUI.SetActive(false);
		nonFoodingUI.SetActive(true);
        AOSliderHolder.SetActive(true);
        TextManager.Instance.ShowToast("Starts Cooking", 2);
        src.Play();

		foodSlider.maxValue=(int)delayTime;
		foodSlider2.maxValue=(int)delayTime;
		 for (int i = 0; i < items.Length; i++)
        {		
               FoodEngine.Instance.RemoveFoodIngre(foodNames[i], quantities[i]);	 
        }
		for(int i=0;i<delayTime;i++)
		{
		yield return new WaitForSeconds(1);
		foodSlider.value=i+1;
		foodSlider2.value=i+1;
		}

        AOSliderHolder.SetActive(false);
        for (int i = 0; i < items.Length; i++)
        {			
				FoodEngine.Instance.AddFood(foodNames[i], quantities[i]);	
				FoodCounter.Instance.AddFood(foodNames[i], quantities[i]);
               
        }
		kPanel.CalculateHutInfo();
		kPanel.SetHutInfo();
        TextManager.Instance.CaptiontextTime = 2;
        TextManager.Instance.CaptionTextHandler("Notification","Cooking Done! Check Kitchen to Serve!", Color.blue, true);
        src.Stop();

        StockInventory.Instance.UpdateFoodStockUI();
		closeButton();        
		foodingUI.SetActive(true);
		nonFoodingUI.SetActive(false);
        ReceiptGenerator.Instance.CurrSlots = 0;

    }
    public void SetDelayTime()
    {
        delayTime = 30f/(GameManager.Instance.currentMachineUpgrade+1);
		Debug.Log("DelayTime"+delayTime);
    }

    public void PickFoood()
    {
        //if (items == null)
        //{
        //  return;
        ////}
        //foodNames = new string[items.Length + 1];
        //  quantities = new int[items.Length + 1];

        // for (int i = 0; i < items.Length; i++)
        // {

        //     foodNames[i] = items[i].name;
        //     quantities[i] = items[i].quantity;

        // }

        // for (int i = 0; i < items.Length; i++)
        // {
        //   bool isTrue = FoodEngine.Instance.buildFood(foodNames[i], quantities[i]);
        //     if (isTrue)
        //    {

        //        FoodEngine.Instance.AddFood(foodNames[i], quantities[i]);

        //  FoodCounter.Instance.RemoveFood(foodNames[i]);
        //    }
        // }

        GameObject[] items = GameObject.FindGameObjectsWithTag("foodModel");


        for (int i = 0; i < items.Length; i++)
        {
            string name = items[i].GetComponent<quantityInfo>().name;
            int quantity = items[i].GetComponent<quantityInfo>().quantity;
            items[i].GetComponent<quantityInfo>().quantity = 0;
            if (quantity > 0)
            {
                FoodEngine.Instance.AddFood(name, quantity);
                TextManager.Instance.ShowToast(name + " Is ADDED", 2);
            }
        }

        quantities = null;
        items = null;


        StockInventory.Instance.UpdateFoodStockUI();



    }
}
