using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HutsManager : MonoBehaviour
{
	public GameObject FTManager;
public TMP_Text TimeLeft2;
        public TMP_Text Statusorder2;
    [System.Serializable]
    public class HutsInfo
    {
        public GameObject customer;
        public Transform locationOfHut;
        public bool isOccupied = false;
        public string customerName;
        public int cashToPay;
        public string Gender;
        public TMP_Text emotion;
        public TMP_Text order;
        public TMP_Text Statusorder;
        public TMP_Text TimeLeft;
        public GameObject hutMarker;
        public bool isAvailable = true;

    }
    [SerializeField]


    public HutsInfo hut1, hut2, hut3, hut4, hut5;

    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        ShowTime();
    }

    public void SetEmotionStatus(int hutNo, string Emotion)
    {
        if (hutNo == 1)
        {
            hut1.emotion.text = Emotion;
        }
        if (hutNo == 2)
        {
            hut2.emotion.text = Emotion;

        }
        if (hutNo == 3)
        {
            hut3.emotion.text = Emotion;
        }
        if (hutNo == 4)
        {
            hut4.emotion.text = Emotion;
        }
        if (hutNo == 5)
        {
            hut5.emotion.text = Emotion;
        }

    }


    public void ShowTime()
    {
        if (hut1.isOccupied == true)
        {
            int time1 = (int)hut1.customer.GetComponent<CustomerAI>().WaitingTime;

            if (time1 < 100)
            {
                hut1.TimeLeft.color = Color.green;
                TimeLeft2.color = Color.green;
            }
            if (time1 > 100 && time1<=200)
            {
                hut1.TimeLeft.color = Color.yellow;
                TimeLeft2.color = Color.yellow;
            }
            if (time1 > 200)
            {
                hut1.TimeLeft.color = Color.red;
                TimeLeft2.color = Color.red;
            }
            hut1.TimeLeft.text = time1.ToString();
            TimeLeft2.text = time1.ToString();
        }

        //For HUt2
        if (hut2.isOccupied == true)
        {
            int time2 = (int)hut2.customer.GetComponent<CustomerAI>().WaitingTime;

            if (time2 < 100)
            {
                hut2.TimeLeft.color = Color.green;
            }
            if (time2 > 100 && time2 <= 200)
            {
                hut2.TimeLeft.color = Color.yellow;
            }
            if (time2 > 200)
            {
                hut2.TimeLeft.color = Color.red;
            }
            hut2.TimeLeft.text = time2.ToString();
        }

        if (hut3.isOccupied == true)
        {
            int time3 = (int)hut3.customer.GetComponent<CustomerAI>().WaitingTime;

            if (time3 < 100)
            {
                hut3.TimeLeft.color = Color.green;
            }
            if (time3 > 100 && time3 <= 200)
            {
                hut3.TimeLeft.color = Color.yellow;
            }
            if (time3 > 200)
            {
                hut3.TimeLeft.color = Color.red;
            }
            hut3.TimeLeft.text = time3.ToString();
        }

        if (hut4.isOccupied == true)
        {
            int time4 = (int)hut4.customer.GetComponent<CustomerAI>().WaitingTime;

            if (time4 < 100)
            {
                hut4.TimeLeft.color = Color.green;
            }
            if (time4 > 100 && time4 <= 200)
            {
                hut4.TimeLeft.color = Color.yellow;
            }
            if (time4 > 200)
            {
                hut4.TimeLeft.color = Color.red;
            }
            hut4.TimeLeft.text = time4.ToString();
        }

        if (hut5.isOccupied == true)
        {
            int time5 = (int)hut5.customer.GetComponent<CustomerAI>().WaitingTime;

            if (time5 < 100)
            {
                hut5.TimeLeft.color = Color.green;
            }
            if (time5 > 100 && time5 <= 200)
            {
                hut5.TimeLeft.color = Color.yellow;
            }
            if (time5 > 200)
            {
                hut5.TimeLeft.color = Color.red;
            }
            hut5.TimeLeft.text = time5.ToString();
        }
    }

    public void SetHutStatus(int hutNo, string food, int quantity)
    {
		if(GameManager.Instance.isLearnt()==false)
		{
       FTManager.GetComponent<FirstTimeManager>().NextBtn();
		}
        if (hutNo == 1)
        {
            hut1.order.text = food + quantity;
            hut1.Statusorder.text = food + quantity;
		           Statusorder2.text = food + quantity;
        }
        if (hutNo == 2)
        {
            hut2.order.text = food + quantity;
            hut2.Statusorder.text = food + quantity;
        }
        if (hutNo == 3)
        {
            hut3.order.text = food + quantity;
            hut3.Statusorder.text = food + quantity;
        }
        if (hutNo == 4)
        {
            hut4.order.text = food + quantity;
            hut4.Statusorder.text = food + quantity;
        }
        if (hutNo == 5)
        {
            hut5.order.text = food + quantity;
            hut5.Statusorder.text = food + quantity;
        }

    }


    public void ResetHutStatus(int hutNo)
    {

        if (hutNo == 1)
        {
            hut1.order.text ="Empty";
			Statusorder2.text = "";
			hut1.Statusorder.color=Color.green;
			hut1.TimeLeft.color=Color.green;
            hut1.Statusorder.text = "Item";
			hut1.TimeLeft.text="SERVED";

        }
        if (hutNo == 2)
        {
            hut2.Statusorder.color=Color.green;
			hut2.TimeLeft.color=Color.green;
            hut2.Statusorder.text = "Item";
			hut2.TimeLeft.text="SERVED";
        }
        if (hutNo == 3)
        {
            hut3.Statusorder.color=Color.green;
			hut3.TimeLeft.color=Color.green;
            hut3.Statusorder.text = "Item";
			hut3.TimeLeft.text="SERVED";
        }
        if (hutNo == 4)
        {
            hut4.Statusorder.color=Color.green;
			hut4.TimeLeft.color=Color.green;
            hut4.Statusorder.text = "Item";
			hut4.TimeLeft.text="SERVED";
        }
        if (hutNo == 5)
        {
            hut5.Statusorder.color=Color.green;
			hut5.TimeLeft.color=Color.green;
            hut5.Statusorder.text = "Item";
			hut5.TimeLeft.text="SERVED";
        }

    }
}