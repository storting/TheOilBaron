using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfCompanies : MonoBehaviour
{
    CompanyBuyOil Gasproff;
    CompanyBuyOil Lukoshnik;
    CompanyBuyOil Rospechenka;
    CompanyBuyOil Surgutka;
    CompanyBuyOil Bashmachnik;
    CompanyBuyOil Navatonium;
    CompanyBuyOil Russkopompas;
    CompanyBuyOil Tatorium;
    CompanyBuyOil Slavneftepioner;
    CompanyBuyOil Yakutparadisel;
    CompanyBuyOil Nizhgribny;
    CompanyBuyOil Tatrefinans;
    CompanyBuyOil Ikrutimetchel;

    private void Start()
    {
        InvokeRepeating("RefreshCompanyStats", 0f, 20f);
    }

    private void RefreshCompanyStats()
    {
        Gasproff = new CompanyBuyOil(1);
        Lukoshnik = new CompanyBuyOil(1);
        Rospechenka = new CompanyBuyOil(1);
        Surgutka = new CompanyBuyOil(1);
        Bashmachnik = new CompanyBuyOil(2);
        Navatonium = new CompanyBuyOil(2);
        Russkopompas = new CompanyBuyOil(2);
        Tatorium = new CompanyBuyOil(2);
        Slavneftepioner = new CompanyBuyOil(3);
        Yakutparadisel = new CompanyBuyOil(3);
        Nizhgribny = new CompanyBuyOil(3);
        Tatrefinans = new CompanyBuyOil(3);
        Ikrutimetchel = new CompanyBuyOil(3);
    }


}
