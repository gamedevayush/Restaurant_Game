using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class FirstTimeManager : MonoBehaviour
{
	public GameObject Player;
    public GameObject ArrowHandler;
	public GameObject[] ButtonObjects;
	public GameObject TextHolder;
	public Transform[] PlaceHolder;
	public Transform[] ArrowPlaceHolder;
	public GameObject NextBtnGO;
	public GameObject CameraScript;
	public GameObject GoodsBuyButton;
	public GameObject VehicleSlider;
	public GameObject foodSlider;
	[Range(1,5)]
	
	public int Part=0;
    void Start()
    {
		
       ArrowHandler.SetActive(false);
	   NextBtnGO.SetActive(true);
	   StartCoroutine(StartTutorial());
    }

    // Update is called once per frame
    void Update()
    {
       		   
    }
	public void NextBtn()
	{
		StartCoroutine(StartTutorial());
	}
	public IEnumerator StartTutorial()
	{
		Part++;
		ResetButtons();
		ArrowHandler.SetActive(false);
		TextHolder.SetActive(false);
		RemoveHandle();
		if(Part==1)	
		{
			ButtonObjects[0].SetActive(true);
			TextHolder.transform.position=PlaceHolder[0].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","This is Level Selection Menu where you can Select any Unlocked Level. Tap on Next Button to Continue!",Color.cyan, false);
			NextBtnGO.SetActive(true);
		}
		if(Part==2)	
		{
			TextHolder.transform.position=PlaceHolder[1].transform.position;
			TextHolder.SetActive(true);
			ButtonObjects[1].SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","This is Shop Where You can Upgrade Items After Collecting Coins by Playing Levels. Tap on Next Button to Continue!", Color.cyan, false);
			NextBtnGO.SetActive(true);
		}
		if(Part==3)	
		{
			NextBtnGO.SetActive(false);
			ShowHandle(ArrowPlaceHolder[0]);
			TextHolder.transform.position=PlaceHolder[0].transform.position;
			TextHolder.SetActive(true);
			ButtonObjects[2].SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","Tap on Level 1 to Start your first Level of Game! Let's Go!", Color.cyan, false);
		}
		if(Part==4)	
		{
			NextBtnGO.SetActive(false);


			ButtonObjects[3].SetActive(true);
			TextHolder.transform.position=PlaceHolder[0].transform.position;
			TextHolder.SetActive(true);
		
			TextManager.Instance.CaptionTextHandler("Tutorial","These are Your Objectives. Read it Carefully and then Tap on Start Button to Start Level", Color.cyan, false);
		}
		if(Part==5)	
		{
			NextBtnGO.SetActive(false);

			//NextBtn();
			//yield return null;
			//REMOVE WHEN BUILD

			yield return new WaitForSeconds(3f);
			
			//Time.timeScale=0f;
			TextHolder.transform.position=PlaceHolder[0].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","Rotate Player's Camera by Swiping on Screen!",Color.cyan, false);
			bool done = false;
			int temp = 0;
			while(!done) // essentially a "while true", but with a bool to break out naturally
			{
				if(Input.GetAxis("Mouse X") !=0 ||Input.GetAxis("Mouse Y")!=0)
					{
						temp++;
						if(temp>50)
						done = true; // breaks the loop
					}
						yield return null; // wait until next frame, then continue execution from here (loop continues)
			}
			NextBtnGO.SetActive(true);
		}
		if(Part==6)
		{
			NextBtnGO.SetActive(false);

			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","Now, Tap on \"Move To\" Button", Color.cyan, false);
			ButtonObjects[4].SetActive(true);
			ShowHandle(ArrowPlaceHolder[1]);
			for(int i=0;i<7;i++)
			{
				if(i==5)
					ButtonObjects[5].transform.GetChild(2).GetChild(i).GetComponent<UnityEngine.UI.Button>().interactable=false;
				else
										ButtonObjects[5].transform.GetChild(2).GetChild(i).GetComponent<UnityEngine.UI.Button>().interactable=true;

			}
		}
		if(Part==7)
		{
			NextBtnGO.SetActive(false);

			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","Here are the places you can walk to serve or make Food. Tap On Any Button to see your Player moving!", Color.cyan, false);
			
			ButtonObjects[5].SetActive(true);
			RemoveHandle();
			
			
		}
		if(Part==8)
		{
			NextBtnGO.SetActive(false);

			yield return new WaitForSeconds(2f);
			bool done = false;
			while(!done) 
			{
				if(Player.GetComponent<PlayerController>().isMoving==false)
					{
						done = true; 
					}
						yield return null; 
			}
			 
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","That's Amazing! You Know how to move! Tap on Next Button to Continue!", Color.cyan, false);
			
			NextBtnGO.SetActive(true);
			
		}
		if(Part==9)
		{
			NextBtnGO.SetActive(false);

			LevelManager.Instance.CustSpawnforFirstTime();
			yield return new WaitForSeconds(2f);
			CameraScript.GetComponent<CameraFollow>().CameraFollowObj=GameObject.Find("AICustomer").transform.GetChild(0).gameObject;
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","A Customer is Coming, Make Sure to Fulfill thier Demands!", Color.cyan, false);
			yield return new WaitForSeconds(8f);
			TextManager.Instance.CaptionTextHandler("Tutorial","Customer will Sit in any Vacant Hut and will Order thier desired food! ", Color.cyan, false);
			yield return new WaitForSeconds(8f);
			TextManager.Instance.CaptionTextHandler("Tutorial","Please Wait!", Color.cyan, false);
			GameObject neckTarget = Player.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Neck).gameObject;
			CameraScript.GetComponent<CameraFollow>().CameraFollowObj = neckTarget;
			yield return new WaitForSeconds(5f);
			
		}
		if(Part==10)
		{
			NextBtnGO.SetActive(false);

			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","We have our First Customer in Hut 1", Color.cyan, false);	
			yield return new WaitForSeconds(5f);
			TextManager.Instance.CaptionTextHandler("Tutorial","Tap on Status Menu to check what are their Requirements!", Color.cyan, false);	
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			ShowHandle(ArrowPlaceHolder[2]);
			ButtonObjects[6].SetActive(true);
		}
		if(Part==11)
		{
			NextBtnGO.SetActive(false);

			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","As You can See, Customer wants One Samosa. Tap On Food Engine Menu, Because Customers are waiting!", Color.cyan, false);	
			ButtonObjects[7].SetActive(true);
			ButtonObjects[8].SetActive(true);
			ShowHandle(ArrowPlaceHolder[3]);
			ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0,180,0));
			yield return new WaitForSeconds(5f);
		}
		if(Part==12)
		{
			NextBtnGO.SetActive(false);

			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","Sorry, But Right Now You dont have Stock to Make Samosa. Tap on Shop to Purchase Goods ", Color.cyan, false);	
			
			ButtonObjects[9].SetActive(true);
			yield return new WaitForSeconds(5f);
			ButtonObjects[10].SetActive(true);
			ShowHandle(ArrowPlaceHolder[5]);
			ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0, 180,0));
		}
		if(Part==13)
		{
			ButtonObjects[10].SetActive(false);
			NextBtnGO.SetActive(false);

			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","This is your Shop Menu, You can Purchase Raw Goods from Here! ", Color.cyan, false);	
			
			ButtonObjects[11].SetActive(true);
			yield return new WaitForSeconds(5f);
			TextManager.Instance.CaptionTextHandler("Tutorial","Order Ingredients that is used to make Samosa ", Color.cyan, false);	
			
			ArrowHandler.transform.position=new Vector2(ArrowPlaceHolder[6].transform.GetChild(0).position.x-175,ArrowPlaceHolder[6].transform.GetChild(0).position.y);
			ArrowHandler.SetActive(true);
			ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0, 180,0));
			//ButtonObjects[10].SetActive(true);
			//ShowHandle(ArrowPlaceHolder[6]);
			//ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0, 180,0));
		}
		if(Part==14)
		{
			NextBtnGO.SetActive(false);

			ArrowHandler.SetActive(true);
			ButtonObjects[11].SetActive(true);
						ArrowHandler.transform.position=new Vector2(ArrowPlaceHolder[6].transform.GetChild(0).position.x-175,ArrowPlaceHolder[6].transform.GetChild(0).position.y-80);

		}
		if(Part==15)
		{
			NextBtnGO.SetActive(false);

			ArrowHandler.SetActive(true);
			ButtonObjects[11].SetActive(true);
						ArrowHandler.transform.position=new Vector2(ArrowPlaceHolder[6].transform.GetChild(0).position.x-175,ArrowPlaceHolder[6].transform.GetChild(0).position.y-160);

		}
		if(Part==16)
		{
			NextBtnGO.SetActive(false);

			ArrowHandler.SetActive(true);
			ButtonObjects[11].SetActive(true);
						ArrowHandler.transform.position=new Vector2(ArrowPlaceHolder[6].transform.GetChild(0).position.x-175,ArrowPlaceHolder[6].transform.GetChild(0).position.y-240);

		}
		if(Part==17)

		{
			NextBtnGO.SetActive(false);

			ArrowHandler.SetActive(true);
			ButtonObjects[11].SetActive(true);
			GoodsBuyButton.SetActive(true);
			ShowHandle(ArrowPlaceHolder[7]);
			ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0, 0,28));

		}
		if(Part==18)
		{
			NextBtnGO.SetActive(false);

			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","You can see our Vehicle is out to Purchase Goods! Till then You can wait! ", Color.cyan, false);	
			ButtonObjects[12].SetActive(true);
			ButtonObjects[12].transform.GetChild(0).GetComponent<GetVehicle>().StartRide();
			float reachTime=50f;
			VehicleSlider.SetActive(true);
			VehicleSlider.GetComponent<Slider>().maxValue=(int)reachTime;
			for(int i=0;i<(int)reachTime;i++)
				{
					yield return new WaitForSeconds(1);
				if (i == 25)
				{
					TextManager.Instance.CaptionTextHandler("Tutorial","You can Check the Current Vehicle Status in Bottom Left Box and in the Shop Slider at the Middle Right of Screen!   ", Color.cyan, false);
				}
					VehicleSlider.GetComponent<Slider>().value=i+1;
				}
			VehicleSlider.SetActive(false);
			NextBtn();

		}
		if(Part==19)
		{
			NextBtnGO.SetActive(false);

			TextManager.Instance.CaptionTextHandler("Tutorial","Items Reached, you can Check them in Storage Menu ", Color.cyan, false);
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			ButtonObjects[13].SetActive(true);
			ShowHandle(ArrowPlaceHolder[8]);
			ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0, 180,0));
		}
		if(Part==20)
		{
			NextBtnGO.SetActive(false);

			TextManager.Instance.CaptionTextHandler("Tutorial","Here, You Can See all the Stock We Have! ", Color.cyan, false);
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			ButtonObjects[14].SetActive(true);
			yield return new WaitForSeconds(5f);
			NextBtn();
		}
		if(Part==21)
		{
			NextBtnGO.SetActive(false);

			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","Again, As You can See Customer want One Samosa. Tap On Food Engine Menu", Color.cyan, false) ;	
			ButtonObjects[8].SetActive(true);
			ShowHandle(ArrowPlaceHolder[3]);
			ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0,180,0));
			yield return new WaitForSeconds(5f);
		}
		if(Part==22)
		{
			NextBtnGO.SetActive(false);

			ShowHandle(ArrowPlaceHolder[4]);
			ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0, 180,0));
			ButtonObjects[9].SetActive(true);
			TextHolder.transform.position=PlaceHolder[0].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","Tap on +1 ", Color.cyan, false);
			ButtonObjects[9].transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Button>().interactable=true;
	
		}
		if(Part==23)
		{
			NextBtnGO.SetActive(false);

			ButtonObjects[9].SetActive(true);
			TextHolder.transform.position = PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","Tap on Cook Button! ", Color.cyan, false);
			ShowHandle(ArrowPlaceHolder[7]);
			ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0,0,28));
		}
		if(Part==24)
		{
			NextBtnGO.SetActive(false);

			TextHolder.transform.position = PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","You can Check Cooking Status in the Slider at the Right Bottom Button Named FOOD MAKER ", Color.cyan, false);
			foodSlider.SetActive(true);
			foodSlider.GetComponent<Slider>().maxValue=(int)5;
		
			for(int i=0;i<5;i++)
			{
			yield return new WaitForSeconds(1);
			foodSlider.GetComponent<Slider>().value=i+1;
			}
		ButtonObjects[15].SetActive(true);
			TextHolder.transform.position = PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","You can See! Now, We have 1 Samosa Ready To Serve! Tap on Next ", Color.cyan, false);
			foodSlider.SetActive(false);
		ShowHandle(ArrowPlaceHolder[9]);
			ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0,0,-90));
			NextBtnGO.SetActive(true);
		}
		if(Part==25)
		{
			NextBtnGO.SetActive(false);

			ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0,0,30));
			ButtonObjects[15].SetActive(true);

			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","Now, Tap on \"Move To\" Button and Go to Kitchen ", Color.cyan, false);
			ButtonObjects[4].SetActive(true);
			ShowHandle(ArrowPlaceHolder[1]);
		}
		if(Part==26)

		{
			NextBtnGO.SetActive(false);

			ButtonObjects[15].SetActive(true);

			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","Tap on Kitchen", Color.cyan, false);
			
			ButtonObjects[5].SetActive(true);
			for(int i=0;i<7;i++)
			{
				if(i!=5)
					ButtonObjects[5].transform.GetChild(2).GetChild(i).GetComponent<UnityEngine.UI.Button>().interactable=false;
				else
					ButtonObjects[5].transform.GetChild(2).GetChild(i).GetComponent<UnityEngine.UI.Button>().interactable = true;
			}
			RemoveHandle();
			
			
		}
		if(Part==27)
		{
			NextBtnGO.SetActive(false);

			yield return new WaitForSeconds(2f);
			bool done = false;
			while(!done) 
			{
				if(Player.GetComponent<PlayerController>().isMoving==false)
					{
						done = true; 
					}
						yield return null; 
			}
			 
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","That's Amazing! You Know how to move! Tap on Next Button to Continue!", Color.cyan, false) ;
			
			NextBtn();
			
		}
		if(Part==28)
		{
			NextBtnGO.SetActive(false);

			TextHolder.transform.position = PlaceHolder[0].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","As You can See Customer in Hut 1 want 1 Samosa which is ready to Serve, Tap on Build to Create a Tray", Color.cyan, false);
			ButtonObjects[16].SetActive(true);
			ButtonObjects[17].SetActive(true);
		}
		if(Part==29)
		{
						NextBtnGO.SetActive(false);

			PlayerFoodHandling.Instance.PickFood("UniversalFood");
		
						ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0,0,30));

			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","Now, Tap on \"Move To\" Button", Color.cyan, false);
			ButtonObjects[4].SetActive(true);
			ShowHandle(ArrowPlaceHolder[1]);
		}
		if(Part==30)
		{
			NextBtnGO.SetActive(false);

			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","Move to Hut 1 and Serve the food", Color.cyan, false);
			
			ButtonObjects[5].SetActive(true);
			for(int i=0;i<7;i++)
			{
				if(i==0)
					ButtonObjects[5].transform.GetChild(2).GetChild(i).GetComponent<UnityEngine.UI.Button>().interactable=true;
				else
										ButtonObjects[5].transform.GetChild(2).GetChild(i).GetComponent<UnityEngine.UI.Button>().interactable=false;

			}
			RemoveHandle();
			
			
		}
		if(Part==31)
		{
			NextBtnGO.SetActive(false);

			yield return new WaitForSeconds(2f);
			bool done = false;
			while(!done) 
			{
				if(Player.GetComponent<PlayerController>().isMoving==false)
					{
						done = true; 
					}
						yield return null; 
			}
			 
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextManager.Instance.CaptionTextHandler("Tutorial","That's Amazing! Tap on Next Button to Continue!",Color.cyan, false) ;
			PlayerFoodHandling.Instance.RemoveFood("UniversalFood");
			NextBtn();
			
		}
		if(Part==32)
		{
			NextBtnGO.SetActive(false);

			ButtonObjects[18].SetActive(true);
						NextBtnGO.SetActive(true);

		}
		if (Part == 33)
        {
			NextBtnGO.SetActive(false);

			ButtonObjects[19].SetActive(true);

		}
	}
	public void ShowHandle(Transform FocusPoint)
	{

		ArrowHandler.SetActive(true);
		ArrowHandler.transform.position=new Vector2(FocusPoint.transform.GetChild(0).position.x+75,FocusPoint.transform.GetChild(0).position.y+70);
	}
	public void RemoveHandle()
	{
		ArrowHandler.SetActive(false);
	}
	public void ResetButtons()
	{
		for(int i=0;i<ButtonObjects.Length;i++)
		{
			ButtonObjects[i].SetActive(false);		
		}
		NextBtnGO.SetActive(false);
	}
	public void finalString(string streeng)
	{
		if(streeng=="restart")
		{
			GameManager.Instance.Reset();
		}
		if(streeng=="next")
		{
			GameManager.Instance.ChangeCoinsTo(500);
			GameManager.Instance.SaveLevel(1);
			GameManager.Instance.SaveLearnt();
			GameManager.Instance.Reset();
		}
	}

}
