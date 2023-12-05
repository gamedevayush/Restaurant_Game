using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemHandler : MonoBehaviour
{
    public string name;
    public int quantity;
    public int price;
    public int amount;
    public string SpriteName;
	

    public TMP_Text itsText;
    void Start()
    {
        //quantity = 0;
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseQuantity(int Count)
    {
        quantity = quantity + Count;
        amount = price * quantity;
        UpdateUI();
    }

    public void AssignIcon(string iconName)
    {
        SpriteName = iconName;
    }

    public void AssignPrice(int thePrice)
    {
        price = thePrice;
    }
    void UpdateUI()
    {
        itsText.text =  SpriteName + " \t \t " + quantity.ToString() + "\t \t \t" + (amount).ToString();
        ReceiptGenerator.Instance.MakeAmount();
    }
    public void RemoveMe()
    {
                Destroy(gameObject,0.0f);
        
    }
	
	public void OnDestroy()
	{
	
		ReceiptGenerator.Instance.MakeAmount();
	}
 
}
