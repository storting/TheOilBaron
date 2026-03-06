using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsView : MonoBehaviour
{
    [SerializeField] private Transform statsContainer;   // Ссылка на Content 
    [SerializeField] private StatItemView statItemPrefab; // Префаб элемента характеристики
    [SerializeField] private StatData[] availableStats;   // Массив ассетов характеристик

    private List<StatItemView> statItems = new List<StatItemView>();
    private bool _itemsCreated = false;

    private void Awake()
    {
        if (!_itemsCreated)
        {
            CreateStatItems();
            _itemsCreated = true;
        }
    }

    private void CreateStatItems()
    {
        foreach (var statData in availableStats)
        {
            var item = Instantiate(statItemPrefab, statsContainer);
            item.Initialize(statData); // statData автоматически кастится к IUpgradable
            statItems.Add(item);
        }
    }

    private void OnEnable()
    {
        if (Player.Instance == null) return;

        // Подписка на события изменения денег и уровней
        Player.Instance.OnMoneyCountChanged += UpdateAllStats;
        Player.Instance.OnCharismaLevelChanged += (level) => UpdateAllStats();
        Player.Instance.OnEruditionLevelChanged += (level) => UpdateAllStats();
        Player.Instance.OnIntelligenceLevelChanged += (level) => UpdateAllStats();
        Player.Instance.OnEloquenceLevelChanged += (level) => UpdateAllStats();

        // Первоначальное обновление
        UpdateAllStats();
    }

    private void OnDisable()
    {
        if (Player.Instance == null) return;

        Player.Instance.OnMoneyCountChanged -= UpdateAllStats;
        Player.Instance.OnCharismaLevelChanged -= (level) => UpdateAllStats();
        Player.Instance.OnEruditionLevelChanged -= (level) => UpdateAllStats();
        Player.Instance.OnIntelligenceLevelChanged -= (level) => UpdateAllStats();
        Player.Instance.OnEloquenceLevelChanged -= (level) => UpdateAllStats();
    }

    private void UpdateAllStats(int _ = 0)  // dummy parameter for event compatibility
    {
        foreach (var item in statItems)
        {
            if (item != null)
                item.UpdateDisplay();
        }
    }
}
