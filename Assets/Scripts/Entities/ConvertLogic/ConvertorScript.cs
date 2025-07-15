using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ConvertorScript : MonoBehaviour
{
    private MainScr _mainScr;
    private ListOfCompanies _companies;
    private string _companiesName;

    private void Start()
    {
        _mainScr = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<MainScr>();
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
        if (_mainScr.OilCount > 0)
        {
            float temp = 0;
            if (_mainScr.OilCount - comp.CunBuyOilCount >= 0)
            {
                _mainScr.OilCount = _mainScr.OilCount - comp.CunBuyOilCount;
                temp = comp.CunBuyOilCount * comp.PriceOil;
                _mainScr.MoneyCount = Convert.ToInt32(temp);
                comp.CunBuyOilCount = 0;
            }
            else if (_mainScr.OilCount - comp.CunBuyOilCount < 0)
            {
                int tempOilCount = _mainScr.OilCount;
                _mainScr.OilCount = 0;
                temp = tempOilCount * comp.PriceOil;
                _mainScr.MoneyCount = Convert.ToInt32(temp);
                comp.CunBuyOilCount -= tempOilCount;
            }
            _mainScr.RefreshStats();
        }
        else
        {
            Debug.Log("ֽופעü = 0");
        }
        InsertCompany refresh = gameObject.GetComponent<InsertCompany>();
        refresh.SetDescription();
    }
}
