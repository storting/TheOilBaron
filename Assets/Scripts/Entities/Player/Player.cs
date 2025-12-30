using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour, ISaveLoadObject
{
    public string ComponentSaveId => "Player";
    public SaveLoadData GetSaveLoadData()
    {
        return new SaveLoadData(
            ComponentSaveId,
            new object[]
            {
                MoneyCount,
                OilCount,
                TapScale,
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
        TapScale = Convert.ToInt32(data[2]);
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
                    Debug.Log("достижение - ТЫСЯЧА ДЕНЕЕЕГ!!!");
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
            if (_oilCount != value)
            {
                _oilCount = value;
                OnOilCountChanged?.Invoke(_oilCount); //событие для переменной
                if (_oilCount >= 1000 && _oilCount <= 1001)
                {
                    Debug.Log("достижение - ТЫСЯЧА НЕФТИИИ!!!");
                }
            }
        }
    }
    public event System.Action<int> OnOilCountChanged;

    public int TapScale = 1; //количество нефти за тап

    public int UserLevelCompany = 1; 

    public int Charisma = 1; //Харизма
    public int Erudition = 1; //Эрудиция
    public int Intelligence = 1; //Интелект
    public int Eloquence = 1; //Красноречие
    //В дальнейшем влияет на лояльность компании
    
    public Player GetSaveData() //Выгрузить данные
    {
        return new Player
        {
            MoneyCount = this.MoneyCount,
            OilCount = this.OilCount,
            TapScale = this.TapScale,
            UserLevelCompany = this.UserLevelCompany,
            Charisma = this.Charisma,
            Erudition = this.Erudition,
            Intelligence = this.Intelligence,
            Eloquence = this.Eloquence
        };
    }

    public void LoadFromData(Player data) //Загрузить данные
    {
        MoneyCount = data.MoneyCount;
        OilCount = data.OilCount;
        TapScale = data.TapScale;
        UserLevelCompany = data.UserLevelCompany;
        Charisma = data.Charisma;
        Erudition = data.Erudition;
        Intelligence = data.Intelligence;
        Eloquence = data.Eloquence;
    }
}

