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

    [SerializeField] private Player player;

    void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();

            if (player == null)
            {
                Debug.LogError("Player не найден на сцене!");
                return;
            }
        }
    }

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
        if (player.OilCount > 0)
        {
            float temp = 0;
            if ((player.OilCount - comp.CunBuyOilCount) >= 0)
            {
                player.OilCount = player.OilCount - comp.CunBuyOilCount;
                if (UnityEngine.Random.Range(1, 100) <= (player.Charisma / 10) + 4.9) // проверяем попали ли мы в шанс крита
                {
                    temp = comp.CunBuyOilCount * (comp.PriceOil * ((player.Charisma * 5) + 195) / 100);
                }
                else
                {
                    temp = comp.CunBuyOilCount * comp.PriceOil;
                }
                player.MoneyCount += Convert.ToInt32(temp);
                comp.CunBuyOilCount = 0;
            }
            else
            {
                if (UnityEngine.Random.Range(1, 100) <= (player.Charisma / 10) + 4.9) // проверяем попали ли мы в шанс крита
                {
                    temp = player.OilCount * (comp.PriceOil * ((player.Charisma * 5) + 195) / 100);
                }
                else
                {
                    temp = player.OilCount * comp.PriceOil;
                }
                comp.CunBuyOilCount -= player.OilCount;
                player.OilCount = 0;
                player.MoneyCount += Convert.ToInt32(temp);
                
            }
        }
        else
        {
            Debug.Log("Нефть = 0");
        }
        InsertCompany refresh = gameObject.GetComponent<InsertCompany>();
        refresh.SetDescription();
    }
}
