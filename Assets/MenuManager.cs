using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
	private static MenuManager _instance;
	public static MenuManager Instance { get { return _instance; } }
	public GameObject SideMenu;
	public GameObject ShopMenu;
	public GameObject StorageMenu;
	public GameObject FoodEngineMenu;
	public GameObject PickupMenu;
	public GameObject TransformMenu;
	public GameObject HeaderMenu;
	public GameObject AOGMenu;
	public GameObject StatusMenu;
	public GameObject MapViewMenu;
	public GameObject TextViewMenu;
	public GameObject OpenkitchenMenu;
	public GameObject PauseMenu;
	
	

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			_instance = this;
		}
		
	}

	IEnumerator PlayPauseSound()
	{
		yield return new WaitForSeconds(1f);
		AudioListener.pause = true;
		Time.timeScale = 0;
	}
	public void ChangeMenu(string name)
	{
		ResetAll();
		if (name == "pause")
		{
			PauseMenu.SetActive(true);
			
			StartCoroutine(PlayPauseSound());
		}
		
		if (name == "openkitchen")
		{
			OpenkitchenMenu.SetActive(true);
			
		}
		if (name == "status")
		{
			StatusMenu.SetActive(true);
		}
		if (name == "shop")
		{
			ShopMenu.SetActive(true);
		}

		if (name == "storage")
		{
			StorageMenu.SetActive(true);
		}
		if (name == "foodengine")
		{
			FoodEngineMenu.SetActive(true);
		}
		if (name == "side")
		{
			SideMenu.SetActive(true);
			HeaderMenu.SetActive(true);
			AOGMenu.SetActive(true);
		}
		if (name == "pickup")
		{
			PickupMenu.SetActive(true);

		}
		if (name == "transform")
		{
			TransformMenu.SetActive(true);

		}


	}

	public void ResetAll()
	{
		//SideMenu.SetActive(false);
		ShopMenu.SetActive(false);
		StorageMenu.SetActive(false);
		FoodEngineMenu.SetActive(false);
		PickupMenu.SetActive(false);
		TransformMenu.SetActive(false);
		StatusMenu.SetActive(false);
		MapViewMenu.SetActive(false);
		TextViewMenu.SetActive(false);
		OpenkitchenMenu.SetActive(false);
		PauseMenu.SetActive(false);
		Time.timeScale=1;
		AudioListener.pause = false;
	}

}