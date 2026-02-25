using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class MainScr : MonoBehaviour
{
    private TMP_Text _oilCounter;
    private TMP_Text _moneyCounter;

    private void Start()
    {
        if (Player.Instance == null)
        {
            Debug.LogError("Player не инициализирован! Проверьте:");
            Debug.LogError("- Есть ли объект Player в сцене?");
            Debug.LogError("- Отработал ли Awake() у Player?");
            Debug.LogError("- Нет ли ошибок в Player.cs?");
            // Дефолтные значения на случай ошибки
            // PriceOil = Random.Range(1, 4);
            // CunBuyOilCount = Random.Range(30, 200);
            return;
        }

        Player.Instance.OnMoneyCountChanged += RefreshStatsMoney;
        Player.Instance.OnOilCountChanged += RefreshStatsOil;

        _oilCounter = GameObject.FindGameObjectWithTag("OilCounter").GetComponent<TMP_Text>();
        _oilCounter.text = Player.Instance.OilCount.ToString() ;
        
        _moneyCounter = GameObject.FindGameObjectWithTag("MoneyCounter").GetComponent<TMP_Text>();
        _moneyCounter.text = Player.Instance.MoneyCount.ToString();
    }

    private void OnApplicationQuit() //События при выходе из игры
    {
        
    }

    private void RefreshStatsMoney(int NewMoney)
    {
        _moneyCounter.text = NewMoney.ToString();
    }

    private void RefreshStatsOil(int NewOil)
    {
        _oilCounter.text = NewOil.ToString();
    }

    public void OilMoneyBaf() //Для тестов
    {
        Player.Instance.OilCount += 350;
        Player.Instance.MoneyCount += 1000;
    }
}
