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

    public float Charisma = 1; //Харизма. Когда ты продаешь нефть тебе падает мультикаст на полученные деньги. Денежный крит. 0.1 за лвл шанса и 5% за лвл крита базова 5% шанса и 200 % крита
    public float Erudition = 1; //Эрудиция + 0.05 к коэффиценту стоимости нефти
    public int Intelligence = 1; //Интелект Поднимает минимально число  CunBuyOilCount + 5 
    public int Eloquence = 1; //Красноречие. Поднимает максимально число  CunBuyOilCount + 5 
    //В дальнейшем влияет на лояльность компании

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

