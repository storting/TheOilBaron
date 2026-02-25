using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ConvertorScript : MonoBehaviour
{
    private ListOfCompanies _companies;
    private string _companiesName;

    private void Start()
    {
        _companiesName = gameObject.GetComponent<InsertCompany>().CompanyName;
    }

    public void ConvertOilToMoney()
    {        
        _companies = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<ListOfCompanies>();
        if (_companiesName == "Gasproff")
        {
            tempCompany(_companies.Gasproff);
        }
        if (_companiesName == "Lukoshnik")
        {
            tempCompany(_companies.Lukoshnik);
        }
    }
    private void tempCompany(CompanyBuyOil comp)
    {
        if (Player.Instance.OilCount > 0)
        {
            float temp = 0;
            if ((Player.Instance.OilCount - comp.CunBuyOilCount) >= 0)
            {
                Player.Instance.OilCount = Player.Instance.OilCount - comp.CunBuyOilCount;
                if (UnityEngine.Random.Range(1, 100) <= (Player.Instance.Charisma / 10) + 4.9) // проверяем попали ли мы в шанс крита
                {
                    temp = comp.CunBuyOilCount * (comp.PriceOil * ((Player.Instance.Charisma * 5) + 195) / 100);
                }
                else
                {
                    temp = comp.CunBuyOilCount * comp.PriceOil;
                }
                Player.Instance.MoneyCount += Convert.ToInt32(temp);
                comp.CunBuyOilCount = 0;
            }
            else
            {
                if (UnityEngine.Random.Range(1, 100) <= (Player.Instance.Charisma / 10) + 4.9) // проверяем попали ли мы в шанс крита
                {
                    temp = Player.Instance.OilCount * (comp.PriceOil * ((Player.Instance.Charisma * 5) + 195) / 100);
                }
                else
                {
                    temp = Player.Instance.OilCount * comp.PriceOil;
                }
                comp.CunBuyOilCount -= Player.Instance.OilCount;
                Player.Instance.OilCount = 0;
                Player.Instance.MoneyCount += Convert.ToInt32(temp);
                
            }
        }
        else
        {
            // Debug.Log("Нефть = 0");
        }
        InsertCompany refresh = gameObject.GetComponent<InsertCompany>();
        refresh.SetDescription();
    }
}
