using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InsertCompany : MonoBehaviour
{
    enum CompanyInspector
    {
        Gasproff,
        Lukoshnik,
        Rospechenka,
        Surgutka,
        Bashmachnik,
        Navatonium,
        Russkopompas,
        Tatorium
    };
    public string CompanyName;

    private TMP_Text _companyDescription;
    private ListOfCompanies _companies;

    private void Start()
    {     
        _companies = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<ListOfCompanies>();
        _companyDescription = gameObject.GetComponent<TMP_Text>();
        SetDescription();
        InvokeRepeating("SetDescription", 10f, _companies.TimeRefreshStats);
    }
    
    public void SetDescription()
    {
        
        if (CompanyName == "Gasproff")
        {
            string temp = $"'Gasproff' : status-{_companies.Gasproff.CompanyStatus.ToString()} " +
                $"\nCunBuyOil-{_companies.Gasproff.CunBuyOilCount.ToString()}\t" +
                $"PticeOil-{_companies.Gasproff.PriceOil.ToString()}";
            _companyDescription.text = temp;
        }
        if (CompanyName == "Lukoshnik")
        {
            string temp = $"'Lukoshnik' : status-{_companies.Lukoshnik.CompanyStatus.ToString()} " +
                $"\nCunBuyOil-{_companies.Lukoshnik.CunBuyOilCount.ToString()}\t" +
                $"PticeOil-{_companies.Lukoshnik.PriceOil.ToString()}";
            _companyDescription.text = temp;
        }
        /*if (CompanyName == "Gasproff")
        {
            string temp = $"'Gasproff' : status-{_companies.Gasproff.CompanyStatus.ToString()} " +
                $"\nCunBuyOil-{_companies.Gasproff.CunBuyOilCount.ToString()}\t" +
                $"PticeOil-{_companies.Gasproff.PriceOil.ToString()}";
            _companyDescription.text = temp;
        }
        if (CompanyName == "Gasproff")
        {
            string temp = $"'Gasproff' : status-{_companies.Gasproff.CompanyStatus.ToString()} " +
                $"\nCunBuyOil-{_companies.Gasproff.CunBuyOilCount.ToString()}\t" +
                $"PticeOil-{_companies.Gasproff.PriceOil.ToString()}";
            _companyDescription.text = temp;
        }
        if (CompanyName == "Gasproff")
        {
            string temp = $"'Gasproff' : status-{_companies.Gasproff.CompanyStatus.ToString()} " +
                $"\nCunBuyOil-{_companies.Gasproff.CunBuyOilCount.ToString()}\t" +
                $"PticeOil-{_companies.Gasproff.PriceOil.ToString()}";
            _companyDescription.text = temp;
        }
        if (CompanyName == "Gasproff")
        {
            string temp = $"'Gasproff' : status-{_companies.Gasproff.CompanyStatus.ToString()} " +
                $"\nCunBuyOil-{_companies.Gasproff.CunBuyOilCount.ToString()}\t" +
                $"PticeOil-{_companies.Gasproff.PriceOil.ToString()}";
            _companyDescription.text = temp;
        }
        if (CompanyName == "Gasproff")
        {
            string temp = $"'Gasproff' : status-{_companies.Gasproff.CompanyStatus.ToString()} " +
                $"\nCunBuyOil-{_companies.Gasproff.CunBuyOilCount.ToString()}\t" +
                $"PticeOil-{_companies.Gasproff.PriceOil.ToString()}";
            _companyDescription.text = temp;
        }
        if (CompanyName == "Gasproff")
        {
            string temp = $"'Gasproff' : status-{_companies.Gasproff.CompanyStatus.ToString()} " +
                $"\nCunBuyOil-{_companies.Gasproff.CunBuyOilCount.ToString()}\t" +
                $"PticeOil-{_companies.Gasproff.PriceOil.ToString()}";
            _companyDescription.text = temp;
        }
        if (CompanyName == "Gasproff")
        {
            string temp = $"'Gasproff' : status-{_companies.Gasproff.CompanyStatus.ToString()} " +
                $"\nCunBuyOil-{_companies.Gasproff.CunBuyOilCount.ToString()}\t" +
                $"PticeOil-{_companies.Gasproff.PriceOil.ToString()}";
            _companyDescription.text = temp;
        }*/
    }
}
