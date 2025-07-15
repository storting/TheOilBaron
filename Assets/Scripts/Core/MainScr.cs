using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScr : MonoBehaviour
{
    public int MoneyCount;
    public int OilCount;
    public int TapScale = 1;

    public int UserLevel;

    private Text _oilCounter;
    private Text _moneyCounter;
    private Data data;
    
    private void Start()
    {
        data = gameObject.GetComponent<Data>();
        data.LoadData();
        _oilCounter = GameObject.FindGameObjectWithTag("OilCounter").GetComponent<Text>();
        _oilCounter.text = OilCount.ToString() + " .i.";

        _moneyCounter = GameObject.FindGameObjectWithTag("MoneyCounter").GetComponent<Text>();
        _moneyCounter.text = "$ " +MoneyCount.ToString();
    }

    private void Update()
    {

    }

    public void RefreshStats()
    {  
        _oilCounter.text = OilCount.ToString() + " .i.";
        _moneyCounter.text = "$ " + MoneyCount.ToString();
    }
    private void OnApplicationQuit()
    {
        data.SaveData();
        //PlayerPrefs.DeleteAll();
        //Debug.Log("DataDelete");
        
    }
}
