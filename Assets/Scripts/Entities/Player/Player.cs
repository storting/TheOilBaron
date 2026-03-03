using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour, ISaveLoadObject
{
    public static Player Instance { get; private set; } //Мы делаем Player синглетоном
    public string ComponentSaveId => "Player";
    public SaveLoadData GetSaveLoadData()
    {
        return new SaveLoadData(
            ComponentSaveId,
            new object[]
            {
                MoneyCount,
                OilCount,
                UserLevelCompany,
                Charisma,
                Erudition,
                Intelligence,
                Eloquence
            }
        );
    }

    public void RestoreValues(SaveLoadData loadData)
    {
        var data = loadData.Data;
        MoneyCount = Convert.ToInt32(data[0]);
        OilCount = Convert.ToInt32(data[1]);
        UserLevelCompany = Convert.ToInt32(data[3]);
        Charisma = Convert.ToInt32(data[4]);
        Erudition = Convert.ToInt32(data[5]);
        Intelligence = Convert.ToInt32(data[6]);
        Eloquence = Convert.ToInt32(data[7]);
    }

    [SerializeField] private int _moneyCount; //количество денег
    public int MoneyCount
    {
        get => _moneyCount;
        set
        {
            if (_moneyCount != value)
            {
                _moneyCount = value;
                OnMoneyCountChanged?.Invoke(_moneyCount); //событие для переменной
                if (_moneyCount >= 1000 && _moneyCount <= 1001)
                {
                    //Debug.Log("достижение - ТЫСЯЧА ДЕНЕЕЕГ!!!");
                }
            }
        }
    }

    public event System.Action<int> OnMoneyCountChanged;

    [SerializeField] private int _oilCount; //количество нефти
    public int OilCount
    {
        get => _oilCount;
        set
        {
            int newValue = value;
            int maxStorage = Pump.Instance.OilStorage;

            int clampedValue = Mathf.Min(newValue, maxStorage);

            if (_oilCount != clampedValue)
            {
                _oilCount = clampedValue;
                OnOilCountChanged?.Invoke(_oilCount);

                if (_oilCount >= 1000 && _oilCount <= 1001)
                {
                    // Достижение
                }
            }
            if (newValue > maxStorage)
            {
                // Debug.Log("Хранилище переполнено!");
            }
        }
    }
    public event System.Action<int> OnOilCountChanged;

    public int UserLevelCompany = 1;

    // СТАТЫ ИГРОКА ВЛИЯЮЩИЕ НА МЕТРИКИ КОМПАНИЙ

    [SerializeField] private int _charismaLevel = 1;
    public int Charisma //Харизма. Когда ты продаешь нефть тебе падает мультикаст на полученные деньги. Денежный крит. 0.1 за лвл шанса и 5% за лвл крита базова 5% шанса и 200 % крита
    {
        get => _charismaLevel;
        set
        {
            if (_charismaLevel != value)
            {
                _charismaLevel = value;
                OnCharismaLevelChanged?.Invoke(value);
            }
        }
    }
    public event System.Action<int> OnCharismaLevelChanged;

    [SerializeField] private int _eruditionLevel = 1;
    public int Erudition //Эрудиция + 0.05 к коэффиценту стоимости нефти
    {
        get => _eruditionLevel;
        set
        {
            if(_eruditionLevel != value)
            {
                _eruditionLevel = value;
                OnEruditionLevelChanged?.Invoke(value);
            }
        }
    }
    public event System.Action<int> OnEruditionLevelChanged;


    [SerializeField] private int _intelligenceLevel = 1;
    public int Intelligence //Интелект Поднимает минимально число  CunBuyOilCount + 5 
    {
        get => _intelligenceLevel;
        set
        {
            if (value != _intelligenceLevel)
            {
                _intelligenceLevel = value;
                OnIntelligenceLevelChanged?.Invoke(value);
            }
        }
    }
    public event System.Action<int> OnIntelligenceLevelChanged;

    [SerializeField] private int _eloquenceLevel = 1;
    public int Eloquence //Красноречие. Поднимает максимально число  CunBuyOilCount + 5 
    {
        get => _eloquenceLevel;
        set
        {
            if (_eloquenceLevel != value)
            {
                _eloquenceLevel = value;
                OnEloquenceLevelChanged?.Invoke(value);
            }
        }
    }
    public event System.Action<int> OnEloquenceLevelChanged;

    // ОДЕЖДА ГЕРОЯ

    [SerializeField] private int _headLevel = 1;
    public int HeadLevel
    {
        get => _headLevel;
        set { if (value != _headLevel) { _headLevel = value; OnHeadLevelChanged?.Invoke(value); } }
    }
    public event System.Action<int> OnHeadLevelChanged;

    [SerializeField] private int _torsoLevel = 1;
    public int TorsoLevel
    {
        get => _torsoLevel;
        set { if (value != _torsoLevel) { _torsoLevel = value; OnTorsoLevelChanged?.Invoke(value); } }
    }
    public event System.Action<int> OnTorsoLevelChanged;

    [SerializeField] private int _legsLevel = 1;
    public int LegsLevel
    {
        get => _legsLevel;
        set { if (value != _legsLevel) {  _legsLevel = value; OnLegsLevelChanged?.Invoke(value); } }
    }
    public event System.Action<int> OnLegsLevelChanged;

    [SerializeField] private int _shoesLevel = 1;
    public int ShoesLevel
    {
        get => _shoesLevel;
        set { if (value != _shoesLevel) { _shoesLevel = value; OnShoesLevelChanged?.Invoke(value); } }
    }
    public event System.Action<int> OnShoesLevelChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject); // Если нужно сохранять между сценами
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

