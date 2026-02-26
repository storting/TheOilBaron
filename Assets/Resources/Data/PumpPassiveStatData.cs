using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStat", menuName = "Stats/Stat Data PPump", order = 51)]
public class PumpPassiveStatData : ScriptableObject
{
    [SerializeField] private string _statName;        // Название для отображения
    [SerializeField] private int _basePrice;          // Цена первого уровня
    [SerializeField] private float _priceMultiplier = 1.5f; // Множитель цены за уровень

    public string StatName => _statName;
    public int BasePrice => _basePrice;
    public float PriceMultiplier => _priceMultiplier;

    // Метод для получения цены следующего уровня
    public int GetPriceForLevel(int currentLevel)
    {
        // Пример формулы: цена = базовая * (множитель ^ (текущий уровень))
        // Для первого уровня (currentLevel=1) получим basePrice * mult^(1) — цена за переход на 2-й уровень.
        return Mathf.RoundToInt(_basePrice * Mathf.Pow(_priceMultiplier, currentLevel));
    }
}
