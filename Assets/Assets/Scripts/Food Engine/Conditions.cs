using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Food_Condition",menuName ="Food Condition")]
public class Conditions : ScriptableObject
{
    [System.Serializable]
    public class conditions
    {
        public float potato, flour, spice, milk, sugar, tea_leaves,oil, besan = 0.0f;
    }

    public conditions forTea, forPakora, forPaneerTikka,forSamosa;
   
}
