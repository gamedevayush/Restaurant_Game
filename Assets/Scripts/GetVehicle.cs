using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetVehicle : MonoBehaviour
{
    public int currentVehicle;
    public ExtShopManager shopManager;
    public int[] speeds;
    public int speed;
    bool speeding;
    public float acceleration = 0.5f;
    public static GetVehicle Instance { get; set; }
    public GameObject[] CurrVehicle;
    public UnityEngine.UI.Slider VehicleSlider;
    public UnityEngine.UI.Image FillImage;
    public OrderGoods OG;
    public AudioSource tap;
    public bool canPlay = false;

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

    void Start()
    {
        ResetVehicle();
        currentVehicle = GameManager.Instance.currentVehicleUpgrade;
        Debug.Log(currentVehicle);
        CurrVehicle[currentVehicle - 1].SetActive(true);
        this.GetComponent<Animation>()["VehicleAnim"].speed = speeds[currentVehicle - 1];
    }
    void ResetVehicle()
    {
        for (int i = 0; i < CurrVehicle.Length; i++)
        {
            CurrVehicle[i].SetActive(false);
        }
    }
    public void Restart()
    {
        ResetVehicle();
        currentVehicle = GameManager.Instance.currentVehicleUpgrade;
        Debug.Log(currentVehicle);
        
        CurrVehicle[currentVehicle - 1].SetActive(true);
        this.GetComponent<Animation>()["VehicleAnim"].speed = speeds[currentVehicle - 1];
    }
    public void StartRide()
    {
        this.GetComponent<Animation>().Play();

        canPlay = true;
    }

    public void IncreaseVehicleSpeed()
    {
        StartCoroutine(IncreaseSpeed());

    }

    public void SetSlider(float comingValue)
    {
        VehicleSlider.transform.gameObject.SetActive(true);
        VehicleSlider.value = comingValue;
    }

    IEnumerator IncreaseSpeed()
    {
        if (!speeding)
        {
            speeding = true;
            if(canPlay)
                tap.Play();
            float temp = this.GetComponent<Animation>()["VehicleAnim"].speed;
            Debug.Log(temp);
            this.GetComponent<Animation>()["VehicleAnim"].speed += acceleration;
            yield return new WaitForSeconds(0.2f);
            this.GetComponent<Animation>()["VehicleAnim"].speed = temp;
            
            speeding = false;
        }
       
    }
    void CallReached()
    {
        OG.VehicleReached();
        canPlay = false;
        VehicleSlider.transform.gameObject.SetActive(false);
    }

    public void SliderEffect()
    {
        Color color = Color.white;
        color.a = 0.5f;
        Color color2 = Color.white;
        color2.a = 0f;
        

        while (FillImage.color.a != 0.5f)
        {
            FillImage.color = Color.Lerp(color, color2, 0.2f);
        }
    }

}
