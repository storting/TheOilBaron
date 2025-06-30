using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ConvertotScript : MonoBehaviour
{
    private MainScr _mainScr;

    private void Start()
    {
        _mainScr = GameObject.FindGameObjectWithTag("MainObject").GetComponent<MainScr>();
    }

    

    public void ConvertOilToMoney()
    {        
        if(_mainScr.OilCount > 0)
        {
            CompanyBuyOil ChesnokOil = new CompanyBuyOil(1);
            Debug.Log("Oil cun buy: " + ChesnokOil.CunBuyOilCount);
            Debug.Log("Oil price: " + ChesnokOil.PriceOil);
            float temp = 0;
            if (_mainScr.OilCount - ChesnokOil.CunBuyOilCount >= 0)
            {
                _mainScr.OilCount = _mainScr.OilCount - ChesnokOil.CunBuyOilCount;
                temp = ChesnokOil.CunBuyOilCount * ChesnokOil.PriceOil;
                _mainScr.MoneyCount = Convert.ToInt32(temp);
                ChesnokOil.CunBuyOilCount = 0;
            }
            else if(_mainScr.OilCount - ChesnokOil.CunBuyOilCount < 0)
            {
                int tempOilCount = _mainScr.OilCount;
                _mainScr.OilCount = 0;
                temp = tempOilCount * ChesnokOil.PriceOil;
                _mainScr.MoneyCount = Convert.ToInt32(temp);
                ChesnokOil.CunBuyOilCount -= tempOilCount;
            }
            Debug.Log("Oil cun buy aslo: " + ChesnokOil.CunBuyOilCount);
            _mainScr.RefreshStats();
        }
        else
        {
            Debug.Log("ֽופעü = 0");
        }
    }
}
