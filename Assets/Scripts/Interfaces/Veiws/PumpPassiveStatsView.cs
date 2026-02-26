using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpPassiveStatsView : MonoBehaviour
{
    [SerializeField] private Transform statsContainer;   // Content из Scroll View
    [SerializeField] private StatItemView statItemPrefab;
    [SerializeField] private PumpPassiveStatData[] availableStats;  // настраиваем в инспекторе Ассеты

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
            Pump.Instance.OnOilStorageLVLChanged += (level) => UpdateAllStats(Player.Instance.MoneyCount);
            Pump.Instance.OnPumpPistonLVLChanged += (level) => UpdateAllStats(Player.Instance.MoneyCount);
            Pump.Instance.OnPumpElectricMotorLVLChanged += (level) => UpdateAllStats(Player.Instance.MoneyCount);
            Pump.Instance.OnPumpBearingsLVLChanged += (level) => UpdateAllStats(Player.Instance.MoneyCount);

            // Первичное обновление
            UpdateAllStats(Player.Instance.MoneyCount);
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

    private int GetStatLevel(PumpPassiveStatData stat)
    {
        // Сравнение по имени (или используй enum для надёжности)
        if (stat.StatName == "Хранилище") return Pump.Instance.OilStorageLVL;
        if (stat.StatName == "Подшипники и клапаны") return Pump.Instance.PumpBearingsLVL;
        if (stat.StatName == "Электро-давигатель") return Pump.Instance.PumpElectricMotorLVL;
        if (stat.StatName == "Поршень") return Pump.Instance.PumpPistonLVL;
        Debug.LogWarning($"Неизвестная характеристика: {stat.StatName}");
        return 1;
    }
}
