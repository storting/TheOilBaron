using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Попытка улучшить характеристику.
    /// </summary>
    /// <param name="stat">Данные характеристики (ScriptableObject)</param>
    /// <returns>true, если улучшение выполнено успешно</returns>
    public bool TryUpgrade(StatData stat)
    {
        if (stat == null)
        {
            Debug.LogError("StatData is null");
            return false;
        }

        int currentLevel = GetStatLevel(stat);
        int nextLevel = currentLevel + 1;
        int price = stat.GetPriceForLevel(currentLevel); // цена за переход на следующий уровень

        if (Player.Instance.MoneyCount < price)
        {
            //UIManager.Instance?.ShowNotification("Недостаточно средств");
            return false;
        }

        Player.Instance.MoneyCount -= price;
        SetStatLevel(stat, nextLevel);

        // Здесь можно добавить звук, эффект, аналитику

        Debug.Log($"Улучшено: {stat.StatName} до уровня {nextLevel}");
        return true;
    }

    private int GetStatLevel(StatData stat)
    {
        // Определяем текущий уровень по имени характеристики
        switch (stat.StatName)
        {
            case "Харизма": return Player.Instance.Charisma;
            case "Эрудиция": return Player.Instance.Erudition;
            case "Интеллект": return Player.Instance.Intelligence;
            case "Красноречие": return Player.Instance.Eloquence;
            default:
                Debug.LogWarning($"Неизвестная характеристика: {stat.StatName}");
                return 1;
        }
    }

    private void SetStatLevel(StatData stat, int level)
    {
        switch (stat.StatName)
        {
            case "Харизма": Player.Instance.Charisma = level; break;
            case "Эрудиция": Player.Instance.Erudition = level; break;
            case "Интеллект": Player.Instance.Intelligence = level; break;
            case "Красноречие": Player.Instance.Eloquence = level; break;
        }
    }
}
