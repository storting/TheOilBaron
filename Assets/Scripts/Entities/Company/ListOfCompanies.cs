using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class ListOfCompanies : MonoBehaviour
{
    public float TimeRefreshStats = 30f;

    public CompanyBuyOil Gasproff;
    public CompanyBuyOil Lukoshnik;
    public CompanyBuyOil Rospechenka;
    public CompanyBuyOil Surgutka;
    public CompanyBuyOil Bashmachnik;
    public CompanyBuyOil Navatonium;
    public CompanyBuyOil Russkopompas;
    public CompanyBuyOil Tatorium;

    public CompanyBuyOil Slavneftepioner;
    public CompanyBuyOil Yakutparadisel;
    public CompanyBuyOil Nizhgribny;
    public CompanyBuyOil Tatrefinans;
    public CompanyBuyOil Ikrutimetchel;

    private void Awake()
    {
        Gasproff = new CompanyBuyOil(1);
        Debug.Log(Gasproff.CunBuyOilCount);
        Lukoshnik = new CompanyBuyOil(1);
        Rospechenka = new CompanyBuyOil(2);
        Surgutka = new CompanyBuyOil(2);
        Bashmachnik = new CompanyBuyOil(3);
        Navatonium = new CompanyBuyOil(3);
        Russkopompas = new CompanyBuyOil(3);
        Tatorium = new CompanyBuyOil(3);
        InvokeRepeating("RefreshCompanyStats", 10f, TimeRefreshStats);
    }

    private void RefreshCompanyStats()
    {
        Gasproff = new CompanyBuyOil(1);
        Debug.Log(Gasproff.CunBuyOilCount);
        Lukoshnik = new CompanyBuyOil(1);
        Rospechenka = new CompanyBuyOil(2);
        Surgutka = new CompanyBuyOil(2);
        Bashmachnik = new CompanyBuyOil(3);
        Navatonium = new CompanyBuyOil(3);
        Russkopompas = new CompanyBuyOil(3);
        Tatorium = new CompanyBuyOil(3);

        Slavneftepioner = new CompanyBuyOil(3);
        Yakutparadisel = new CompanyBuyOil(3);
        Nizhgribny = new CompanyBuyOil(3);
        Tatrefinans = new CompanyBuyOil(3);
        Ikrutimetchel = new CompanyBuyOil(3);
    }
}
