using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackItemsView : MonoBehaviour
{
    [SerializeField] private Transform objContainer;   // Ссылка на Content
    [SerializeField] private StatItemView objItemPrefab; // Префаб элемента характеристики
    [SerializeField] private BackObjData[] availableObj;   // Массив ассетов характеристик

    private List<StatItemView> objItems = new List<StatItemView>();
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
        foreach (var objData in availableObj)
        {
            var item = Instantiate(objItemPrefab, objContainer);
            item.Initialize(objData); // statData автоматически кастится к IUpgradable
            objItems.Add(item);
        }
    }

    private void OnEnable()
    {
        if (BackItems.Instance == null) return;

        // Подписка на события изменения денег и уровней
        BackItems.Instance.OnHouseLevelChanged += UpdateAllStats;
        BackItems.Instance.OnCarLevelChanged += (level) => UpdateAllStats();
        BackItems.Instance.OnYardLevelChanged += (level) => UpdateAllStats();
        BackItems.Instance.OnAnimalLevelChanged += (level) => UpdateAllStats();
        BackItems.Instance.OnFrontHouseAeraLevelChanged += (level) => UpdateAllStats();

        // Первоначальное обновление
        UpdateAllStats();
    }

    private void OnDisable()
    {
        if (BackItems.Instance == null) return;

        BackItems.Instance.OnHouseLevelChanged -= UpdateAllStats;
        BackItems.Instance.OnCarLevelChanged -= (level) => UpdateAllStats();
        BackItems.Instance.OnYardLevelChanged -= (level) => UpdateAllStats();
        BackItems.Instance.OnAnimalLevelChanged -= (level) => UpdateAllStats();
        BackItems.Instance.OnFrontHouseAeraLevelChanged -= (level) => UpdateAllStats();
    }

    private void UpdateAllStats(int _ = 0)  // dummy parameter for event compatibility
    {
        foreach (var item in objItems)
        {
            if (item != null)
                item.UpdateDisplay();
        }
    }
}
