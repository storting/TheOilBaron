using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class MainScr : MonoBehaviour
{
    [SerializeField] private Player player;
    private TMP_Text _oilCounter;
    private TMP_Text _moneyCounter;

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
        player.OnMoneyCountChanged += RefreshStatsMoney;
        player.OnOilCountChanged += RefreshStatsOil;

        _oilCounter = GameObject.FindGameObjectWithTag("OilCounter").GetComponent<TMP_Text>();
        _oilCounter.text = player.OilCount.ToString() ;
        
        _moneyCounter = GameObject.FindGameObjectWithTag("MoneyCounter").GetComponent<TMP_Text>();
        _moneyCounter.text = player.MoneyCount.ToString();
    }

    private void OnApplicationQuit()
    {
        Player save = player.GetSaveData();
        Debug.Log(save);
        DataManager.SaveData(save, "User");
    }
    private void RefreshStatsMoney(int NewMoney)
    {
        _moneyCounter.text = NewMoney.ToString();
    }
    private void RefreshStatsOil(int NewOil)
    {
        _oilCounter.text = NewOil.ToString();
    }

    public void OilMoneyBaf()
    {
        player.OilCount += 1000;
        player.MoneyCount += 1000;
    }
}
