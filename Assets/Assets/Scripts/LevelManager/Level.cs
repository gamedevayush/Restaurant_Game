using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelManager" , menuName = "Add Level")]
public class Level : ScriptableObject
{
    
    public int levelNum;
    public int totalCustomers;
    public int consecCustomers;
    public int totalLevelTime;
    public float avgRatingReq;
    public bool isCompleted;
    public int givenCoins;
    [SerializeField]public List<CustomerRequirement> Requirements;

}

[System.Serializable]
public class CustomerRequirement
{
    [SerializeField]public int paneerTikka =0, samosa=0, pakori=0, tea=0;
}