using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequirementPanelOnStatus : MonoBehaviour
{
    public GameObject samosaPanel, paneerTikkaPanel, pakoraPanel, teaPanel;
    public HutsManager hutsManager;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowPanel(int hutNo)
    {
        switch (hutNo)
        {
            case 1:
                string s1 = hutsManager.hut1.hutMarker.GetComponent<MarkerTrigger>().foodName;
                activatePanel(s1);
                break;
            case 2:
                string s2 = hutsManager.hut2.hutMarker.GetComponent<MarkerTrigger>().foodName;
                activatePanel(s2);

                break;
            case 3:
                string s3 = hutsManager.hut3.hutMarker.GetComponent<MarkerTrigger>().foodName;
                activatePanel(s3);
                break;
            case 4:
                string s4 = hutsManager.hut4.hutMarker.GetComponent<MarkerTrigger>().foodName;
                activatePanel(s4);
                break;
            case 5:
                string s5 = hutsManager.hut5.hutMarker.GetComponent<MarkerTrigger>().foodName;
                activatePanel(s5);
                break;



        }
    }

    public void activatePanel(string s)
    {
        if (s.Equals("Samosa", System.StringComparison.OrdinalIgnoreCase))
        {
            samosaPanel.SetActive(true);
            return;
        }
        if (s.Equals("paneerTikka", System.StringComparison.OrdinalIgnoreCase))
        {
           paneerTikkaPanel.SetActive(true);
            return;
        }
        if (s.Equals("pakora", System.StringComparison.OrdinalIgnoreCase))
        {
            pakoraPanel.SetActive(true);
            return;
        }
        if (s.Equals("tea", System.StringComparison.OrdinalIgnoreCase))
        {
            teaPanel.SetActive(true);
            return;
        }
    }


    public void disablePanel()
    {
        teaPanel.SetActive(false);
        pakoraPanel.SetActive(false);
        paneerTikkaPanel.SetActive(false);
        samosaPanel.SetActive(false);
    }
}
