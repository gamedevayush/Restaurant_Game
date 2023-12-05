using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerFoodHandling : MonoBehaviour
{
    public string currentFood;
    public bool isHolding = false;
    public float speedToDecrese = 1f;
   
    public float originalSpeed;
    public string itemName = "";
    [System.Serializable]
    public class FoodPrefabs
    {
        public GameObject Tea;
        public GameObject Pakora, Samosa, PaneerTikka,UniversalTray;
    }
    [SerializeField]

    public FoodPrefabs foodItems;


    [System.Serializable]
    public class IKConstraints
    {
        public GameObject RightHandEffector, LeftHandEffector;
    }
    [SerializeField]

    public IKConstraints TeaIK;
    public IKConstraints SamosaIK;
    public IKConstraints PaneerTikkaIK;
    public IKConstraints PakoriIK;
    public IKConstraints UniversalTrayIK;
    public IKConstraints broomIK;

    public static PlayerFoodHandling Instance { get; set; }

     Animator anim;
    public bool broomIk = false;
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
        anim = this.GetComponent<Animator>();
       // PickFood("Tea");
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnAnimatorIK(int layerIndex)
    {
        if (currentFood == "Samosa")
        {
            //Debug.Log("Hello");

            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, SamosaIK.LeftHandEffector.transform.rotation);

            anim.SetIKPosition(AvatarIKGoal.LeftHand, SamosaIK.LeftHandEffector.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);

            //For Right Hand
            anim.SetIKPosition(AvatarIKGoal.RightHand, SamosaIK.RightHandEffector.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            anim.SetIKRotation(AvatarIKGoal.RightHand, SamosaIK.RightHandEffector.transform.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
        }

        else if (currentFood == "PaneerTikka")
        {
            //For Right Hand
            anim.SetIKPosition(AvatarIKGoal.RightHand, PaneerTikkaIK.RightHandEffector.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            anim.SetIKRotation(AvatarIKGoal.RightHand, PaneerTikkaIK.RightHandEffector.transform.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            //For Left Hand
            anim.SetIKPosition(AvatarIKGoal.LeftHand, PaneerTikkaIK.LeftHandEffector.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, PaneerTikkaIK.LeftHandEffector.transform.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
        }

        else if (currentFood == "Pakora")
        {
            //For Right Hand
            anim.SetIKPosition(AvatarIKGoal.RightHand, PakoriIK.RightHandEffector.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            anim.SetIKRotation(AvatarIKGoal.RightHand, PakoriIK.RightHandEffector.transform.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            //For Left Hand
            anim.SetIKPosition(AvatarIKGoal.LeftHand, PakoriIK.LeftHandEffector.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, PakoriIK.LeftHandEffector.transform.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);

        }

        else if (currentFood == "Tea")
        {
            //For Right Hand
            anim.SetIKPosition(AvatarIKGoal.RightHand, TeaIK.RightHandEffector.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, TeaIK.LeftHandEffector.transform.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            //For Left Hand
            anim.SetIKPosition(AvatarIKGoal.LeftHand, TeaIK.LeftHandEffector.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            anim.SetIKRotation(AvatarIKGoal.RightHand, TeaIK.RightHandEffector.transform.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);

        }
        else if (currentFood == "UniversalFood")
        {
            //For Right Hand
            anim.SetIKPosition(AvatarIKGoal.RightHand, UniversalTrayIK.RightHandEffector.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            anim.SetIKRotation(AvatarIKGoal.RightHand, UniversalTrayIK.RightHandEffector.transform.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            //For Left Hand
            anim.SetIKPosition(AvatarIKGoal.LeftHand, UniversalTrayIK.LeftHandEffector.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, UniversalTrayIK.LeftHandEffector.transform.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
        }
        else if(broomIk)
        {
            anim.SetIKPosition(AvatarIKGoal.RightHand, broomIK.RightHandEffector.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            anim.SetIKRotation(AvatarIKGoal.RightHand, broomIK.RightHandEffector.transform.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            //For Left Hand
            anim.SetIKPosition(AvatarIKGoal.LeftHand, broomIK.LeftHandEffector.transform.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, broomIK.LeftHandEffector.transform.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
        }
        else
        {
        
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
      
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            //For Left Hand
           
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            anim.SetIKRotation(AvatarIKGoal.RightHand, TeaIK.RightHandEffector.transform.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
        }
    }



    public void PickFood(string food)   //Player ke haatho mein food laane key liye ise call kre
    {
        currentFood = food;
        
        if (food == "Samosa")
        {
            foodItems.Samosa.SetActive(true);
        }

        if (food == "Tea")
        {
            foodItems.Tea.SetActive(true);
           
        }

        if (food == "Pakora")
        {
            foodItems.Pakora.SetActive(true);
           
        }


        if (food == "PaneerTikka")
        {
            foodItems.PaneerTikka.SetActive(true);
           

        }

        if (food == "UniversalFood")
        {
            originalSpeed = this.GetComponent<NavMeshAgent>().speed;
            this.GetComponent<NavMeshAgent>().speed = speedToDecrese  ;
            foodItems.UniversalTray.SetActive(true);
            
        }

    }

    public void RemoveFood(string food)   //Player ke haatho mein food hatane key liye ise call kre
    {
        currentFood = "";

        if (food == "Samosa")
        {
            foodItems.Samosa.SetActive(false);
        }

        if (food == "Tea")
        {
            foodItems.Tea.SetActive(false);

        }

        if (food == "Pakora")
        {
            foodItems.Pakora.SetActive(false);

        }


        if (food == "PaneerTikka")
        {
            foodItems.PaneerTikka.SetActive(false);


        }

        if (food == "UniversalFood")
        {
            this.GetComponent<NavMeshAgent>().speed = originalSpeed;
            foodItems.UniversalTray.SetActive(false);
        }

    }



    




}
