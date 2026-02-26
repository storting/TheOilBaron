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
        DontDestroyOnLoad(Instance);
    }

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
            case "ХАРИЗМА": return Player.Instance.Charisma;
            case "ЭРУДИЦИЯ": return Player.Instance.Erudition;
            case "ИНТЕЛЕКТ": return Player.Instance.Intelligence;
            case "РИТОРИКА": return Player.Instance.Eloquence;
            default:
                Debug.LogWarning($"Неизвестная характеристика: {stat.StatName}");
                return 1;
        }
    }

    private void SetStatLevel(StatData stat, int level)
    {
        switch (stat.StatName)
        {
            case "ХАРИЗМА": Player.Instance.Charisma = level; break;
            case "ЭРУДИЦИЯ": Player.Instance.Erudition = level; break;
            case "ИНТЕЛЕКТ": Player.Instance.Intelligence = level; break;
            case "РИТОРИКА": Player.Instance.Eloquence = level; break;
        }
    }
}
