using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour
{
    [SerializeField] private int _moneyCount;
    public int MoneyCount
    {
        get => _moneyCount;
        set
        {
            if (_moneyCount != value)
            {
                _moneyCount = value;
                OnMoneyCountChanged?.Invoke(_moneyCount);
                if (_moneyCount >= 1000 && _moneyCount <= 1001)
                {
                    Debug.Log("äîñòèæåíèå - ÒÛÑß×À ÄÅÍÅÅÅÃ!!!");
                }
            }
        }
    }
    public event System.Action<int> OnMoneyCountChanged;

    [SerializeField] private int _oilCount;
    public int OilCount
    {
        get => _oilCount;
        set
        {
            if (_oilCount != value)
            {
                _oilCount = value;
                OnOilCountChanged?.Invoke(_oilCount);
                if (_oilCount >= 1000 && _oilCount <= 1001)
                {
                    Debug.Log("äîñòèæåíèå - ÒÛÑß×À ÍÅÔÒÈÈÈ!!!");
                }
            }
        }
    }
    public event System.Action<int> OnOilCountChanged;

    public int TapScale = 1;

    public int UserLevelCompany = 1;

    public int Charisma = 1;
    public int Erudition = 1;
    public int Intelligence = 1;
    public int Eloquence = 1;

    public Player GetSaveData()
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

    public void LoadFromData(Player data)
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

