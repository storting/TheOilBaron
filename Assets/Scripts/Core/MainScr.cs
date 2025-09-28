using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainScr : MonoBehaviour
{
    public int MoneyCount;
    public int OilCount;
    public int TapScale = 1;

    public int UserLevel;

    private TMP_Text _oilCounter;
    private TMP_Text _moneyCounter;
    private Data data;
    
    private void Start()
    {
        data = gameObject.GetComponent<Data>();
        data.LoadData();
        _oilCounter = GameObject.FindGameObjectWithTag("OilCounter").GetComponent<TMP_Text>();
        _oilCounter.text = OilCount.ToString() ;
        
        _moneyCounter = GameObject.FindGameObjectWithTag("MoneyCounter").GetComponent<TMP_Text>();
        _moneyCounter.text = MoneyCount.ToString();
    }

    private void Update()
    {

    }

    public void RefreshStats()
    {  
        _oilCounter.text = OilCount.ToString();
        _moneyCounter.text = MoneyCount.ToString();
    }

    private void OnApplicationQuit()
    {
        data.SaveData();
        PlayerPrefs.DeleteAll();
        Debug.Log("DataDelete");
    }

    public void OilMoneyBaf()
    {
        OilCount += 1000;
        MoneyCount += 1000;
    }
}
