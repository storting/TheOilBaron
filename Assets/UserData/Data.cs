using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    private MainScr main;

    public void SaveData()
    {
        main = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<MainScr>();

        //UserBaseData
        PlayerPrefs.SetInt("MoneyUser", main.MoneyCount);
        PlayerPrefs.SetInt("OilUser", main.OilCount);
        PlayerPrefs.SetInt("TapScale", main.TapScale);
        PlayerPrefs.SetInt("UserLevel", main.UserLevel);
        PlayerPrefs.Save();

        Debug.Log("DataSave");
    }

    public void LoadData()
    {
        main = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<MainScr>();

        //UserBaseData
        if (PlayerPrefs.HasKey("MoneyUser")) main.MoneyCount = PlayerPrefs.GetInt("MoneyUser");
        if (PlayerPrefs.HasKey("OilUser")) main.OilCount = PlayerPrefs.GetInt("OilUser");
        if (PlayerPrefs.HasKey("TapScale")) main.TapScale = PlayerPrefs.GetInt("TapScale");
        if (PlayerPrefs.HasKey("UserLevel")) main.UserLevel = PlayerPrefs.GetInt("UserLevel");

        Debug.Log("DataLoad");
    }
}
