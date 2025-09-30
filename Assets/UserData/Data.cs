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
        PlayerPrefs.SetInt("UserLevel", main.UserLevelCompany);
        PlayerPrefs.SetInt("Charisma", main.Charisma);
        PlayerPrefs.SetInt("Erudition", main.Erudition);
        PlayerPrefs.SetInt("Intelligence", main.Intelligence);
        PlayerPrefs.SetInt("Eloquence", main.Eloquence);
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
        if (PlayerPrefs.HasKey("UserLevel")) main.UserLevelCompany = PlayerPrefs.GetInt("UserLevel");
        if (PlayerPrefs.HasKey("Charisma")) main.Charisma = PlayerPrefs.GetInt("Charisma");
        if (PlayerPrefs.HasKey("Erudition")) main.Erudition = PlayerPrefs.GetInt("Erudition");
        if (PlayerPrefs.HasKey("Intelligence")) main.Intelligence = PlayerPrefs.GetInt("Intelligence");
        if (PlayerPrefs.HasKey("Eloquence")) main.Eloquence = PlayerPrefs.GetInt("Eloquence");
        Debug.Log("DataLoad");
    }
}
