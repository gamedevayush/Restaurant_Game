using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quantityInfo : MonoBehaviour
{
   public  string name;
    public int quantity;
    string tag = "foodModel";
    public void AddQuantity(int incomingQuantity)
    {
        quantity = quantity+incomingQuantity;
    }

    private void Awake()
    {
        this.gameObject.tag = tag;
       
    }
}
