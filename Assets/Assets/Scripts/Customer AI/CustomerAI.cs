using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;
using TextSpeech;
using UnityEditor;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AudioSource))]
public class CustomerAI : MonoBehaviour
{

    Rigidbody rb;
    NavMeshAgent theAgent;
    CapsuleCollider theCollider;
    Animator anim;
    SoundCollection mySounds;
    AudioSource src;
    bool isMoving;
    int coinsDedecuted;


    [System.Serializable]
    public class Information
    {
        public int custNumber;
        public string Gender;
        public string name;
        public int hutNo;
        public string emotion;
        public string foodOrder;
        public int quantity;
        public int amountToPay;
        public GameObject currentDestination;
        public bool isServed = false;
        public float cointDeduction = 0.0f;
        public bool isKid;
    }
    [SerializeField]


    [System.Serializable]
    public class DestinationsInfo
    {
        public Transform endPlace;
        [Header("The places AI can visit Randomly")]
        public Transform[] RandomPlaces;
    }
    [SerializeField]

    public Information AI_Information;
    public DestinationsInfo destinations;
    public HutsManager hutManager;

    public GameObject[] dirtMakers;
    public int amount;
    bool countTime = false;
    public float WaitingTime;
    public int ratingStar;
    GameObject currentdestination;
    public bool haveOrdered;
    private void Awake()
    {
        haveOrdered = false;
        anim = GetComponent<Animator>();
        theAgent = GetComponent<NavMeshAgent>();
        this.gameObject.tag = "Customer";
        if (hutManager == null)
            hutManager = GameObject.Find("Huts Manager").GetComponent<HutsManager>();
    }
    void Start()
    {

        //SetDestination(destinations.RandomPlaces[0]);
        FindHut();
        
        src = this.GetComponent<AudioSource>();
        theAgent.updateRotation = false;

    }


    void Update()
    {
        HandleAnimations();
        if (theAgent.velocity.sqrMagnitude > Mathf.Epsilon)
        {
            transform.rotation = Quaternion.LookRotation(theAgent.velocity.normalized);
        }



        if (countTime)
        {
            WaitingTime += Time.deltaTime;
        }

    }

    public void SetDestination(Transform destination)
    {
        this.currentdestination = destination.gameObject;
        theAgent.SetDestination(destination.position);
        AI_Information.currentDestination = destination.gameObject;
    }

    public void HandleAnimations()
    {
        if (theAgent.velocity != Vector3.zero)
        {
            isMoving = true;
            anim.SetBool("Move", true);
        }
        else
        {
            isMoving = false;
            anim.SetBool("Move", false);
        }
    }

    public void FindHut()
    {
        int hutNo = 0;
        hutNo = FindEmptyHut();
        if (hutNo == 0)
            Debug.Log("No Hut Is Empty");
        AI_Information.hutNo = hutNo;
    }
    public int FindEmptyHut()
    {

        if (!hutManager.hut1.isOccupied)
        {
            SetDestination(hutManager.hut1.locationOfHut);
            hutManager.hut1.isOccupied = true;
            hutManager.hut1.customer = this.gameObject;
            hutManager.hut1.customerName = AI_Information.name;

            return 1;
        }
        if (!hutManager.hut2.isOccupied)
        {
            SetDestination(hutManager.hut2.locationOfHut);
            hutManager.hut2.isOccupied = true;
            hutManager.hut2.customer = this.gameObject;
            hutManager.hut2.customerName = AI_Information.name;
            return 2;
        }
        if (!hutManager.hut3.isOccupied)
        {
            SetDestination(hutManager.hut3.locationOfHut);
            hutManager.hut3.isOccupied = true;
            hutManager.hut3.customer = this.gameObject;
            hutManager.hut3.customerName = AI_Information.name;
            return 3;
        }
        if (!hutManager.hut4.isOccupied)
        {
            SetDestination(hutManager.hut4.locationOfHut);
            hutManager.hut4.isOccupied = true;
            hutManager.hut4.customer = this.gameObject;
            hutManager.hut4.customerName = AI_Information.name;
            return 4;
        }
        if (!hutManager.hut5.isOccupied)
        {
            SetDestination(hutManager.hut5.locationOfHut);
            hutManager.hut5.isOccupied = true;
            hutManager.hut5.customer = this.gameObject;
            hutManager.hut5.customerName = AI_Information.name;
            return 5;
        }


        return 0;

    }

    public void SetEmotion(string Emotion)
    {

        //Here we are also changing the values of huts occupied
        switch (AI_Information.hutNo)
        {
            case 1:
                hutManager.hut1.isAvailable = false;
                break;
            case 2:
                hutManager.hut2.isAvailable = false;
                break;
            case 3:
                hutManager.hut3.isAvailable = false;
                break;
            case 4:
                hutManager.hut4.isAvailable = false;
                break;
            case 5:
                hutManager.hut5.isAvailable = false;
                break;
        }

        //Now Setting the Emotion Of Hut
        string emotionString = "";
        if (Emotion == "Thinking")  //Index ID = 12
        {
            emotionString = "<sprite=12>";
        }
        if (Emotion == "Happy")   //Index ID = 04
        {
            emotionString = "<sprite=4>";
        }
        if (Emotion == "Sad")     //IndexID = 15
        {
            emotionString = "<sprite=15>";
        }
        if (Emotion == "Frustrated") //IndexID = 10
        {
            emotionString = "<sprite=10>";
        }

        hutManager.SetEmotionStatus(AI_Information.hutNo, emotionString);
    }

    public void OrderFood()
    {
        haveOrdered = true;
        #region OlDCODE
        /** AI_Information.foodOrder = StockInventory.Instance.GenerateRandomFood();
          Debug.Log(AI_Information.foodOrder);
          if(AI_Information.foodOrder.Equals("Samosa",StringComparison.OrdinalIgnoreCase))
          {
               AI_Information.quantity = UnityEngine.Random.Range(1, LevelManager.Instance.currentLevel.maxSamosa+1);
          }
          if(AI_Information.foodOrder.Equals("PaneerTikka",StringComparison.OrdinalIgnoreCase))
          {
               AI_Information.quantity = UnityEngine.Random.Range(1, LevelManager.Instance.currentLevel.maxPaneerTikka+1);
          }
          if(AI_Information.foodOrder.Equals("Pakora",StringComparison.OrdinalIgnoreCase))
          {
               AI_Information.quantity = UnityEngine.Random.Range(1, LevelManager.Instance.currentLevel.maxPakori+1);
          }
          if(AI_Information.foodOrder.Equals("Tea",StringComparison.OrdinalIgnoreCase))
          {
               AI_Information.quantity = UnityEngine.Random.Range(1, LevelManager.Instance.currentLevel.maxTea+1);
          }

          **/
        #endregion
        int custNo = AI_Information.custNumber - 1;
        Level currentLevel = LevelManager.Instance.currentLevel;

        if (currentLevel.Requirements[custNo].samosa > 0)
        {
            AI_Information.foodOrder = "Samosa";
            AI_Information.quantity = currentLevel.Requirements[custNo].samosa;
        }
        else if (currentLevel.Requirements[custNo].paneerTikka > 0)
        {
            AI_Information.foodOrder = "PaneerTikka";
            AI_Information.quantity = currentLevel.Requirements[custNo].paneerTikka;
        }
        else if (currentLevel.Requirements[custNo].pakori > 0)
        {
            AI_Information.foodOrder = "Pakora";
            AI_Information.quantity = currentLevel.Requirements[custNo].pakori;
        }
        else if (currentLevel.Requirements[custNo].tea > 0)
        {
            AI_Information.foodOrder = "Tea";
            AI_Information.quantity = currentLevel.Requirements[custNo].tea;
        }
        else
        {
            TextSpeech.TextToSpeech.Instance.StartSpeak("Enteries in level Manager misMatch" + currentLevel.levelNum);
        }

        TextManager.Instance.CaptionTextHandler("Alert","New Order Recieved from Hut No."+ AI_Information.hutNo+ "<br> Name- "+AI_Information.name+ "<br>Order- " + AI_Information.foodOrder + " <br>Quantity- " + AI_Information.quantity +" . ", Color.red,true);

        AI_Information.amountToPay = StockInventory.Instance.CalculateAmount(AI_Information.foodOrder, AI_Information.quantity);

        //PlayOrderFoodSound(AI_Information.foodOrder);

        SetFoodOrderDisplay(AI_Information.foodOrder, AI_Information.quantity);
        LevelManager.Instance.ShuruKrvaao();

        if (AI_Information.hutNo == 1)
        {
            hutManager.hut1.hutMarker.SetActive(true);


            hutManager.hut1.hutMarker.GetComponent<MarkerTrigger>().foodName = AI_Information.foodOrder;
            hutManager.hut1.hutMarker.GetComponent<MarkerTrigger>().quntity = AI_Information.quantity;
            hutManager.hut1.hutMarker.GetComponent<MarkerTrigger>().customer = this;

        }
        if (AI_Information.hutNo == 2)
        {
            hutManager.hut2.hutMarker.SetActive(true);
            hutManager.hut2.hutMarker.GetComponent<MarkerTrigger>().foodName = AI_Information.foodOrder;
            hutManager.hut2.hutMarker.GetComponent<MarkerTrigger>().quntity = AI_Information.quantity;
            hutManager.hut2.hutMarker.GetComponent<MarkerTrigger>().customer = this;
        }
        if (AI_Information.hutNo == 3)
        {
            hutManager.hut3.hutMarker.SetActive(true);
            hutManager.hut3.hutMarker.GetComponent<MarkerTrigger>().foodName = AI_Information.foodOrder;
            hutManager.hut3.hutMarker.GetComponent<MarkerTrigger>().quntity = AI_Information.quantity;
            hutManager.hut3.hutMarker.GetComponent<MarkerTrigger>().customer = this;
        }
        if (AI_Information.hutNo == 4)
        {
            hutManager.hut4.hutMarker.SetActive(true);
            hutManager.hut4.hutMarker.GetComponent<MarkerTrigger>().foodName = AI_Information.foodOrder;
            hutManager.hut4.hutMarker.GetComponent<MarkerTrigger>().quntity = AI_Information.quantity;
            hutManager.hut4.hutMarker.GetComponent<MarkerTrigger>().customer = this;
        }
        if (AI_Information.hutNo == 5)
        {
            hutManager.hut5.hutMarker.SetActive(true);
            hutManager.hut5.hutMarker.GetComponent<MarkerTrigger>().foodName = AI_Information.foodOrder;
            hutManager.hut5.hutMarker.GetComponent<MarkerTrigger>().quntity = AI_Information.quantity;
            hutManager.hut5.hutMarker.GetComponent<MarkerTrigger>().customer = this;
        }
    }



    public void SetFoodOrderDisplay(string food, int quantity)
    {
        string foodString = "";
        if (food == "Samosa")
        {
            foodString = "<sprite=8>";
        }
        if (food == "PaneerTikka")
        {
            foodString = "<sprite=9>";
        }
        if (food == "Pakora")
        {
            foodString = "<sprite=10>";
        }
        if (food == "Tea")
        {
            foodString = "<sprite=11>";
        }

        hutManager.SetHutStatus(AI_Information.hutNo, foodString, AI_Information.quantity);
        countTime = true;
        PlayRequirementSound();
    }


    public void PlayRequirementSound()
    {
                SoundManager.Instance.PlayAISound(AI_Information.Gender, AI_Information.isKid, AI_Information.foodOrder);
    }
    public void PlayFeedbackSound()
    {
        SoundManager.Instance.PlayAIFeedback(AI_Information.Gender, AI_Information.isKid, ratingStar);
    }

    public void ServeFood()
    {
        //int newCoins = LevelManager.Instance.coins;

        countTime = false;
        if (WaitingTime <= 300.0f)
        {
            ratingStar = 3;

        }
        if (WaitingTime > 300.0f && WaitingTime <= 500.0f)
        {

            ratingStar = 2;


        }

        if (WaitingTime > 500.0f)
        {
            ratingStar = 1;

        }

        if (!LevelManager.Instance.customerId.Contains(AI_Information.custNumber))
        {
            LevelManager.Instance.totalPayable += AI_Information.amountToPay;
            Debug.Log("TotalPayableSent" + AI_Information.custNumber);
            LevelManager.Instance.customerId.Add(AI_Information.custNumber);

        }
        int FoodCost= AI_Information.amountToPay;
       
        AI_Information.isServed = true;
       // Debug.Log("New coins are" + newCoins);
        if (GameManager.Instance.garbageStatus != 0)
        {
            DirtDetected(GameManager.Instance.garbageStatus);
        coinsDedecuted = (int)(AI_Information.amountToPay * (AI_Information.cointDeduction / 100));
            Debug.Log(coinsDedecuted);
            //Sirf Amount
        AI_Information.amountToPay = AI_Information.amountToPay - coinsDedecuted;
        if (coinsDedecuted > 0)
            TextManager.Instance.ShowToast("Coins dedecuted due to dirt" + coinsDedecuted, 2);
            if (LevelManager.Instance.customerId.Contains(AI_Information.custNumber))
            {
                LevelManager.Instance.totalDeducted += coinsDedecuted;
            }
        }
        //Amount + Deduction
        //newCoins += AI_Information.amountToPay;
        AI_Information.amountToPay += CoinsIncreaseDueToUpgrade();//To Increase Amount Due To Upgrade
        //Amount with Upgrades and Deductions

        //AI_Information.amountToPay += CoinsIncreaseDueToUpgrade();
        if (LevelManager.Instance.customerId.Contains(AI_Information.custNumber))
        {
            LevelManager.Instance.coinsDueToUpgrade += CoinsIncreaseDueToUpgrade();
        }
        TextSpeech.TextToSpeech.Instance.StartSpeak(AI_Information.amountToPay+ " Coins Received from "+ AI_Information.name);
       
        
        TextManager.Instance.CaptionTextHandler(AI_Information.name," Food Cost- " + FoodCost +" Coins"+ "<br> Rating- " + ratingStar + "<br>Deduction- " + coinsDedecuted + " <br> Extra Vibes- " + CoinsIncreaseDueToUpgrade() + "<br> Total Paid- " + AI_Information.amountToPay, Color.red, true);
        LevelManager.Instance.AddCoins(AI_Information.amountToPay);
        if (LevelManager.Instance.customerId.Contains(AI_Information.custNumber))
        {
            LevelManager.Instance.finalAmount += AI_Information.amountToPay;
        }
		
		 if (AI_Information.hutNo == 1)
        {
            hutManager.hut1.cashToPay = 0;
            hutManager.hut1.customer = null;
            hutManager.hut1.customerName = null;
            hutManager.hut1.Gender = null;
            hutManager.hut1.isOccupied = false;
            hutManager.hut1.Statusorder.text = "Empty";
            hutManager.hut1.TimeLeft.text = "";
            hutManager.ResetHutStatus(1);
            hutManager.hut1.isAvailable = true;

        }


        if (AI_Information.hutNo == 2)
        {
            hutManager.hut2.cashToPay = 0;
            hutManager.hut2.customer = null;
            hutManager.hut2.customerName = null;
            hutManager.hut2.Gender = null;
            hutManager.hut2.TimeLeft.text = "";
            hutManager.hut2.Statusorder.text = "Empty";
            hutManager.hut2.isAvailable = true;
            hutManager.hut2.isOccupied = false;
            hutManager.ResetHutStatus(2);
        }

        if (AI_Information.hutNo == 3)
        {
            hutManager.hut3.cashToPay = 0;
            hutManager.hut3.customer = null;
            hutManager.hut3.customerName = null;
            hutManager.hut3.Gender = null;
            hutManager.hut3.TimeLeft.text = "";
            hutManager.hut3.Statusorder.text = "Empty";
            hutManager.hut3.isOccupied = false;
            hutManager.hut3.isAvailable = true;
            hutManager.ResetHutStatus(3);
        }

        if (AI_Information.hutNo == 4)
        {
            hutManager.hut4.cashToPay = 0;
            hutManager.hut4.customer = null;
            hutManager.hut4.customerName = null;
            hutManager.hut4.Gender = null;
            hutManager.hut4.TimeLeft.text = "";
            hutManager.hut4.Statusorder.text = "Empty";
            hutManager.hut4.isOccupied = false;
            hutManager.hut4.isAvailable = true;
            hutManager.ResetHutStatus(4);
        }

        if (AI_Information.hutNo == 5)
        {
            hutManager.hut5.cashToPay = 0;
            hutManager.hut5.customer = null;
            hutManager.hut5.customerName = null;
            hutManager.hut5.TimeLeft.text = "";
            hutManager.hut5.Statusorder.text = "Empty";
            hutManager.hut5.Gender = null;
            hutManager.hut5.isAvailable = true;
            hutManager.hut5.isOccupied = false;
            hutManager.ResetHutStatus(5);
        }

        Invoke("ResetValues", 2);
      

    }

    public void CurtainOut()
    {
        anim.SetBool("Sit", false);
        currentdestination.GetComponent<BenchLocation>().curtainOff();
        Invoke("GetOut", 2);


    }
    public void GetOut()
    {
        theAgent.enabled = true;
        theAgent.SetDestination(destinations.endPlace.transform.position);
        
    }

    public void ResetValues()
    {
        PlayFeedbackSound();
        SendReachSignal();
        Invoke("CurtainOut", 10);

    }

    int CoinsIncreaseDueToUpgrade()
    {
        int coins = 0;
        coins += GameManager.Instance.currentTVUpgrade + GameManager.Instance.currentHeartUpgrade + GameManager.Instance.currentVehicleUpgrade;
        coins += GameManager.Instance.currentVaseUpgrade + GameManager.Instance.currentWallArtUpgrade + GameManager.Instance.currentSpeakerUpgrade;
        coins += GameManager.Instance.currentMachineUpgrade;
        return coins;
    }
    public void SendReachSignal()
    {
        LevelManager.Instance.CustomerReached(ratingStar);
    }

    public void PlayOrderFoodSound(string food)
    {
        if (food.Equals("Samosa", System.StringComparison.OrdinalIgnoreCase))
        {
            src.PlayOneShot(mySounds.askingForSamosa[0]);
        }
        if (food.Equals("paneerTikka", System.StringComparison.OrdinalIgnoreCase))
        {
            src.PlayOneShot(mySounds.askingForPaneerTikka[0]);
        }
        if (food.Equals("pakori", System.StringComparison.OrdinalIgnoreCase))
        {
            src.PlayOneShot(mySounds.askingForPakori[0]);
        }
        if (food.Equals("tea", System.StringComparison.OrdinalIgnoreCase))
        {
            src.PlayOneShot(mySounds.askingForTea[0]);
        }
    }

    public void DirtDetected(int count)
    {
            switch (count)
            {
                case 2:
                case 3:
                    AI_Information.cointDeduction = 10f;
                    break;
                case 4:
                case 5:
                    AI_Information.cointDeduction = 15f;
                    break;
                case 6:
                case 7:
                    AI_Information.cointDeduction = 20f;
                    break;

            }
        
    }
}
