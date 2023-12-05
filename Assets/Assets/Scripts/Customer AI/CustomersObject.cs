using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomersData" , menuName = "Customers Data")]
public class CustomersObject : ScriptableObject
{
    public GameObject[] maleCustomersModel;
    public GameObject[] femaleCustomersModel;

    public string[] maleCustomerNames;
    public string[] femaleCustomersNames;

}
