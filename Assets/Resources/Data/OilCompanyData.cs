using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCompany", menuName = "Company/CompanyData", order = 51)]
public class OilCompanyData : ScriptableObject, IUpdatable
{
    public enum CompanyType
    {
        Gasproff,
        Lukoshnik,
        Rospechenka,
        Surgutka,
        Bashmachnik,
        Navatonium,
        Russkopompas,
        Tatorium,
        Slavneftepioner,
        Yakutparadisel,
        Nizhgribny,
        Tatrefinans,
        Ikrutimetchel
    }

    [SerializeField] private string _companyName;
    [SerializeField] private int CompanyStatus;
    [SerializeField] private CompanyType _companyType;

    public string DisplayName => _companyName;
    public CompanyType Type => _companyType;

    private CompanyBuyOil _companyObj;

    public int Status => CompanyStatus;
    public float CurrentPrice => _companyObj?.PriceOil ?? 0;
    public int CurrentOilAmount => _companyObj?.CunBuyOilCount ?? 0;

    private static List<OilCompanyData> pendingCompanies = new List<OilCompanyData>();
    public event Action OnDataChanged;

    private void Awake()
    {
        RefreshCompany();
    }

    private void OnEnable()
    {
        if (TimeManager.Instance != null)
        {
            TimeManager.Instance.Register(this);
        }
        else
        {
            pendingCompanies.Add(this);
            //Debug.Log($"Компания {name} добавлена в очередь ожидания TimeManager");
        }
    }

    private void OnDisable()
    {
        if (TimeManager.Instance != null)
            TimeManager.Instance.Unregister(this);
        else
            pendingCompanies.Remove(this);
    }

    public void Tick()
    {
        RefreshCompany();
        OnDataChanged?.Invoke();
    }

    public void ConvertOil()
    {
       
        if (Player.Instance.OilCount > 0)
        {
            float temp = 0;
            if ((Player.Instance.OilCount - _companyObj.CunBuyOilCount) >= 0)
            {
                Player.Instance.OilCount = Player.Instance.OilCount - _companyObj.CunBuyOilCount;
                if (UnityEngine.Random.Range(1, 100) <= (Player.Instance.Charisma / 10) + 4.9) // проверяем попали ли мы в шанс крита
                {
                    temp = _companyObj.CunBuyOilCount * (_companyObj.PriceOil * ((Player.Instance.Charisma * 5) + 195) / 100);
                }
                else
                {
                    temp = _companyObj.CunBuyOilCount * _companyObj.PriceOil;
                }
                Player.Instance.MoneyCount += Convert.ToInt32(temp);
                _companyObj.CunBuyOilCount = 0;
            }
            else
            {
                if (UnityEngine.Random.Range(1, 100) <= (Player.Instance.Charisma / 10) + 4.9) // проверяем попали ли мы в шанс крита
                {
                    temp = Player.Instance.OilCount * (_companyObj.PriceOil * ((Player.Instance.Charisma * 5) + 195) / 100);
                }
                else
                {
                    temp = Player.Instance.OilCount * _companyObj.PriceOil;
                }
                _companyObj.CunBuyOilCount -= Player.Instance.OilCount;
                Player.Instance.OilCount = 0;
                Player.Instance.MoneyCount += Convert.ToInt32(temp);

            }
        }
        else
        {
            // Debug.Log("Нефть = 0");
        }
        OnDataChanged?.Invoke();
    }
    private void RefreshCompany()
    {
        _companyObj = new CompanyBuyOil(CompanyStatus, _companyType.ToString());
    }

    public static void RegisterPending(TimeManager manager)
    {
        foreach (var company in pendingCompanies)
        {
            manager.Register(company);
        }
        pendingCompanies.Clear();
    }
}

