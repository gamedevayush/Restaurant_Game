using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGenerator : MonoBehaviour
{
    public CustomersObject customerDatabase;       //Refers to the database Of the Customer [Scriptable Object]
    public Transform customerGenratingPoint;       //Location Where customers are generated
    public Transform customerEndingPoint;

    [System.Serializable]
    public class CurrentCustomersData
    {
        public int totalCustomersPresent = 0;
        public int maleCustomersPresent = 0;
        public int femaleCustomersPresent = 0;
        public List<string> namesOfCurrentMale;
        public List<string> namesofCurrentFemale;
    }
    [SerializeField]

    public CurrentCustomersData currentData;
    public int startingCustomers = 1;
    public int customerCount = 0;


    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void GenerateCustomer()
    {
        int Gender = Random.Range(1, 3);
			
            Debug.Log(Gender);
            if (Gender == 1) //Generate a male
            {
                GenerateMale();
            }
            if (Gender == 2)
                GenerateFemale();
			
			if(Gender ==3)
				GenerateCustomer();
		
    }
                                                  
    public void GenerateMale()
    {
        customerCount++;
        int randomMaleNo = Random.Range(0, customerDatabase.maleCustomersModel.Length);
        GameObject AI = Instantiate(customerDatabase.maleCustomersModel[randomMaleNo], customerGenratingPoint.position, Quaternion.identity) as GameObject;
		AI.name="AICustomer";
		
        int randomNameNo = Random.Range(0, customerDatabase.maleCustomerNames.Length);
        string randomName = customerDatabase.maleCustomerNames[randomNameNo];

        //Setting the name and gender to AI
        AI.GetComponent<CustomerAI>().AI_Information.name = randomName;
        AI.GetComponent<CustomerAI>().AI_Information.Gender = "Male";
        AI.GetComponent<CustomerAI>().destinations.endPlace= customerEndingPoint.transform;

        AI.GetComponent<CustomerAI>().AI_Information.custNumber = customerCount;


        currentData.totalCustomersPresent += 1;
        currentData.maleCustomersPresent += 1;
        currentData.namesOfCurrentMale.Add(randomName);

    }

    public void GenerateFemale()
    {
        customerCount++;
        int randomMaleNo = Random.Range(0, customerDatabase.femaleCustomersModel.Length);
        GameObject AI = Instantiate(customerDatabase.femaleCustomersModel[randomMaleNo], customerGenratingPoint.position, Quaternion.identity) as GameObject;
		AI.name="AICustomer";
        int randomNameNo = Random.Range(0, customerDatabase.femaleCustomersNames.Length);
        string randomName = customerDatabase.femaleCustomersNames[randomNameNo];

        AI.GetComponent<CustomerAI>().AI_Information.name = randomName;
        AI.GetComponent<CustomerAI>().AI_Information.Gender = "Female";
        AI.GetComponent<CustomerAI>().destinations.endPlace= customerEndingPoint.transform;
        AI.GetComponent<CustomerAI>().AI_Information.custNumber = customerCount ;
        currentData.totalCustomersPresent += 1;
        currentData.femaleCustomersPresent += 1;
        currentData.namesofCurrentFemale.Add(randomName);
    }


    public void RemoveCustomer(GameObject customer)
    {
        string gender = customer.GetComponent<CustomerAI>().AI_Information.Gender;
        string name = customer.GetComponent<CustomerAI>().AI_Information.name;

        if (gender == "Male")
        {
            currentData.maleCustomersPresent -= 1;
            currentData.namesOfCurrentMale.Remove(name);

        }
        if (gender == "Female")
        {
            currentData.femaleCustomersPresent -= 1;
            currentData.namesOfCurrentMale.Remove(name);
        }

        currentData.totalCustomersPresent -= 1;
        Destroy(customer);


    }


}
