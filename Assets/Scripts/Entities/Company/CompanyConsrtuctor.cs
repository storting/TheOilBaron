using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanyBuyOil
{
    public float PriceOil;
    public int CunBuyOilCount;
    public int CompanyStatus;
 
    public CompanyBuyOil(int CompanyStatus)
    {
        Debug.Log("Попытка создать компанию. Player.Instance = " + Player.Instance);

        if (Player.Instance == null)
        {
            Debug.LogError("Player не инициализирован! Проверьте:");
            Debug.LogError("- Есть ли объект Player в сцене?");
            Debug.LogError("- Отработал ли Awake() у Player?");
            Debug.LogError("- Нет ли ошибок в Player.cs?");
            // Дефолтные значения на случай ошибки
            PriceOil = Random.Range(1, 4);
            CunBuyOilCount = Random.Range(30, 200);
            return;
        }
        this.CompanyStatus = CompanyStatus;
        if (CompanyStatus == 1)
        {
            PriceOil = Random.Range(1, 4) * (0.95f + (Player.Instance.Erudition * 0.05f));
            CunBuyOilCount = Random.Range(30 + (Player.Instance.Intelligence * 5), 100 + (Player.Instance.Eloquence * 5));
        }
        else if (CompanyStatus == 2) 
        {
            PriceOil = Random.Range(10, 15) * (0.95f + (Player.Instance.Erudition * 0.05f));
            CunBuyOilCount = Random.Range(1000 + (Player.Instance.Intelligence * 5), 10000 + (Player.Instance.Eloquence * 5));
        }
        else if (CompanyStatus == 3)
        {
            PriceOil = Random.Range(10, 15) * (0.95f + (Player.Instance.Erudition * 0.05f));
            CunBuyOilCount = Random.Range(1000 + (Player.Instance.Intelligence * 5), 10000 + (Player.Instance.Eloquence * 5));
        }
    }
}


