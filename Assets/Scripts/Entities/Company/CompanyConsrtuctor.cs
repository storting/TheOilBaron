using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyBuyOil
{
    public float PriceOil;
    public int CunBuyOilCount;
    public int CompanyStatus;

    public CompanyBuyOil(int CompanyStatus)
    {
        this.CompanyStatus = CompanyStatus;
        if (CompanyStatus == 1)
        {
            PriceOil = Random.Range(1, 4);
            CunBuyOilCount = Random.Range(30, 200);
        }
        else if (CompanyStatus == 2) 
        {
            PriceOil = Random.Range(10, 15);
            CunBuyOilCount = Random.Range(1000, 10000);
        }
        else if (CompanyStatus == 3)
        {
            PriceOil = Random.Range(10, 15);
            CunBuyOilCount = Random.Range(1000, 10000);
        }
    }
}


