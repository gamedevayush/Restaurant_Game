using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCounter : MonoBehaviour
{
		bool samosaReady;
		bool pTikkaReady;
		bool teaReady;
		bool pakoriReady;
    public static FoodCounter Instance { get; set; }
    // Start is called before the first frame update
    [System.Serializable]
    public class foodSlots
    {
        public GameObject teaSlot,pakoraSlot,samosaSlot,paneerTikkaSlot;
        
    }
    [SerializeField]

    [System.Serializable]
    public class foodPrefabs
    {
        public GameObject teaPrefab, pakoraPrefab, samosaPrefab, paneerTikkaPrefab;

    }
    [SerializeField]

    public foodSlots FoodSlots;
    public foodPrefabs FoodPrefabs;
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

   public void AddFood(string food,int Quantity)
    {
        if (food == "Tea")
        {
            if (teaReady)
            {
                GameObject.Find("TeaModel").GetComponent<quantityInfo>().AddQuantity(Quantity);
                return;
            }

            GameObject g=Instantiate(FoodPrefabs.teaPrefab, FoodSlots.teaSlot.transform.position, Quaternion.identity);
            g.GetComponent<quantityInfo>().name = "Tea";
            g.GetComponent<quantityInfo>().AddQuantity(Quantity);
			g.name="TeaModel";
			teaReady=true;
        }

        else if (food == "Pakora")
        {
            if (pakoriReady)
            {
                GameObject.Find("PakoriModel").GetComponent<quantityInfo>().AddQuantity(Quantity);
                return;
            }
            GameObject g=Instantiate(FoodPrefabs.pakoraPrefab, FoodSlots.pakoraSlot.transform.position, Quaternion.identity);
            g.GetComponent<quantityInfo>().name = "Pakora";
            g.GetComponent<quantityInfo>().AddQuantity(Quantity);
            g.name="PakoriModel";
			pakoriReady=true;
        }

        else if (food == "PaneerTikka")
        {
            if (pTikkaReady)
            {
                GameObject.Find("PTikkaModel").GetComponent<quantityInfo>().AddQuantity(Quantity);
                return;
            }
            GameObject g=Instantiate(FoodPrefabs.paneerTikkaPrefab, FoodSlots.paneerTikkaSlot.transform.position, Quaternion.identity);
            g.GetComponent<quantityInfo>().name = "PaneerTikka";
            g.GetComponent<quantityInfo>().AddQuantity(Quantity); 
            g.name="PTikkaModel";
			pTikkaReady=true;
        }
        else if (food == "Samosa")
        {
            if (samosaReady)
            {
                GameObject.Find("SamosaModel").GetComponent<quantityInfo>().AddQuantity(Quantity);
                return;
            }
            GameObject g=Instantiate(FoodPrefabs.samosaPrefab, FoodSlots.samosaSlot.transform.position, Quaternion.identity);
            g.GetComponent<quantityInfo>().name = "Samosa";
            g.GetComponent<quantityInfo>().AddQuantity(Quantity);
            g.name="SamosaModel";
			samosaReady=true;
        }
        else
        {
            Debug.Log("Wrong Food Passed");
        }

        
        
    }
	
	public void RemoveFood(string food)
	{
		 if (food == "Tea"&&teaReady==true)
        {
            
			Destroy(GameObject.Find("TeaModel"));
			teaReady=false;
        }

        else if (food == "Pakora"&&pakoriReady== true)
        {
            Destroy(GameObject.Find("PakoriModel"));
			pakoriReady=false;
        }

        else if (food == "PaneerTikka"&&pTikkaReady== true)
        {
            Destroy(GameObject.Find("pTikkaModel"));
			pTikkaReady=false;
        }
        else if (food == "Samosa"&&samosaReady== true)
        {
            Destroy(GameObject.Find("SamosaModel"));
			samosaReady=false;
        }
        else 
        {

            Debug.Log("Wrong Food Passed");
        }
	}
}
