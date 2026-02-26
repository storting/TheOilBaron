using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsView : MonoBehaviour
{
    [SerializeField] private Transform statsContainer;   // Content из Scroll View
    [SerializeField] private StatItemView statItemPrefab;
    [SerializeField] private StatData[] availableStats;  // настраиваем в инспекторе Ассеты

    private List<StatItemView> statItems = new List<StatItemView>();

    private void Awake()
    {
        CreateStatItems();
    }
    private void CreateStatItems()
    {
        int index = 0;
        foreach (var statData in availableStats)
        {
            var item = Instantiate(statItemPrefab, statsContainer);
            item.name = $"{statData.StatName}_item_{index}";
            item.Initialize(statData);
            statItems.Add(item);
            index++;
        }
    }

    private void OnEnable()
    {
        if (Player.Instance != null)
        {
            Player.Instance.OnMoneyCountChanged += UpdateAllStats;
            Player.Instance.OnCharismaLevelChanged += (level) => UpdateAllStats(Player.Instance.MoneyCount);
            Player.Instance.OnEruditionLevelChanged += (level) => UpdateAllStats(Player.Instance.MoneyCount);
            Player.Instance.OnIntelligenceLevelChanged += (level) => UpdateAllStats(Player.Instance.MoneyCount);
            Player.Instance.OnEloquenceLevelChanged += (level) => UpdateAllStats(Player.Instance.MoneyCount);

            // Первичное обновление
            UpdateAllStats(Player.Instance.MoneyCount);
        }
    }

    private void OnDisable()
    {
        if (Player.Instance != null)
        {
            Player.Instance.OnMoneyCountChanged -= UpdateAllStats;
        }
    }

    private void UpdateAllStats(int currentMoney)
    {
        for (int i = 0; i < availableStats.Length; i++)
        {
            if (statItems[i] != null)
                statItems[i].UpdateDisplay(GetStatLevel(availableStats[i]), currentMoney);
        }
    }

    private int GetStatLevel(StatData stat)
    {
        // Сравнение по имени (или используй enum для надёжности)
        if (stat.StatName == "ХАРИЗМА") return Player.Instance.Charisma;
        if (stat.StatName == "ЭРУДИЦИЯ") return Player.Instance.Erudition;
        if (stat.StatName == "ИНТЕЛЕКТ") return Player.Instance.Intelligence;
        if (stat.StatName == "РИТОРИКА") return Player.Instance.Eloquence;
        Debug.LogWarning($"Неизвестная характеристика: {stat.StatName}");
        return 1;
    }
}
