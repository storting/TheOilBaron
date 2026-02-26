using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsView : MonoBehaviour
{
    [SerializeField] private Transform statsContainer;   // Content из Scroll View
    [SerializeField] private StatItemView statItemPrefab;
    [SerializeField] private StatData[] availableStats;  // настраиваем в инспекторе

    private List<StatItemView> statItems = new List<StatItemView>();

    private void Start()
    {
        // Создаём элементы UI
        foreach (var statData in availableStats)
        {
            var item = Instantiate(statItemPrefab, statsContainer);
            item.Initialize(statData, OnUpgradeStat);
            statItems.Add(item);
        }

        // Подписываемся на события изменения денег и уровней характеристик
        Player.Instance.OnMoneyCountChanged += UpdateAllStats;
        Player.Instance.OnCharismaLevelChanged += (level) => UpdateStat(availableStats[0], level);
        Player.Instance.OnEruditionLevelChanged += (level) => UpdateStat(availableStats[1], level);
        // ... подписки для остальных

        // Первоначальное обновление
        UpdateAllStats(Player.Instance.MoneyCount);
    }

    private void UpdateAllStats(int currentMoney)
    {
        // Обновляем каждый элемент
        for (int i = 0; i < availableStats.Length; i++)
        {
            int level = GetStatLevel(availableStats[i]);
            statItems[i].UpdateDisplay(level, currentMoney);
        }
    }

    private void UpdateStat(StatData stat, int newLevel)
    {
        // Можно обновить только конкретный элемент, но проще вызвать UpdateAllStats
        UpdateAllStats(Player.Instance.MoneyCount);
    }

    private int GetStatLevel(StatData stat)
    {
        // Получаем текущий уровень из Player
        if (stat.StatName == "Харизма") return Player.Instance.Charisma;
        if (stat.StatName == "Эрудиция") return Player.Instance.Erudition;
        // и т.д.
        return 1;
    }

    private void OnUpgradeStat(StatData stat)
    {
        UpgradeManager.Instance.TryUpgrade(stat);
    }

    private void OnDestroy()
    {
        if (Player.Instance != null)
        {
            Player.Instance.OnMoneyCountChanged -= UpdateAllStats;
            Player.Instance.OnCharismaLevelChanged -= (level) => UpdateStat(availableStats[0], level);
            // отписка от остальных...
        }
    }
}
