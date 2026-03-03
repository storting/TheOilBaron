using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpStatsView : MonoBehaviour
{
    [SerializeField] private Transform statsContainer;         // Content из Scroll View
    [SerializeField] private StatItemView statItemPrefab;      // тот же универсальный префаб
    [SerializeField] private PumpComponentData[] availableComponents; // массив ассетов компонентов

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
        foreach (var componentData in availableComponents)
        {
            var item = Instantiate(statItemPrefab, statsContainer);
            item.Initialize(componentData); // componentData автоматически приводится к IUpgradable
            statItems.Add(item);
        }
    }

    private void OnEnable()
    {
        if (Pump.Instance == null || Player.Instance == null) return;

        // Подписка на изменения всех уровней насоса
        Pump.Instance.OnOilStorageLVLChanged += (level) => UpdateAllStats();
        Pump.Instance.OnPumpPistonLVLChanged += (level) => UpdateAllStats();
        Pump.Instance.OnPumpElectricMotorLVLChanged += (level) => UpdateAllStats();
        Pump.Instance.OnPumpBearingsLVLChanged += (level) => UpdateAllStats();
        Pump.Instance.OnPumpHandlesLVLChanged += (level) => UpdateAllStats();
        Pump.Instance.OnPumpPipeVolumeLVLChanged += (level) => UpdateAllStats();

        // Подписка на изменение нефти (она в Player)
        Player.Instance.OnOilCountChanged += UpdateAllStats;

        UpdateAllStats();
    }

    private void OnDisable()
    {
        if (Pump.Instance == null || Player.Instance == null) return;

        Pump.Instance.OnOilStorageLVLChanged -= (level) => UpdateAllStats();
        Pump.Instance.OnPumpPistonLVLChanged -= (level) => UpdateAllStats();
        Pump.Instance.OnPumpElectricMotorLVLChanged -= (level) => UpdateAllStats();
        Pump.Instance.OnPumpBearingsLVLChanged -= (level) => UpdateAllStats();
        Pump.Instance.OnPumpHandlesLVLChanged -= (level) => UpdateAllStats();
        Pump.Instance.OnPumpPipeVolumeLVLChanged -= (level) => UpdateAllStats();

        Player.Instance.OnOilCountChanged -= UpdateAllStats;
    }

    private void UpdateAllStats(int _ = 0) // совместимость с событием
    {
        foreach (var item in statItems)
        {
            if (item != null) item.UpdateDisplay();
        }
    }
}
