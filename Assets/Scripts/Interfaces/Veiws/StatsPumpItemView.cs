using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsPumpItemView : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private Button upgradeButton;

    private PumpPassiveStatData statData;

    public void Initialize(PumpPassiveStatData data)
    {
        statData = data;
        nameText.text = data.StatName;
    }

    public void UpdateDisplay(int currentLevel, int currentMoney)
    {
        if (this == null || upgradeButton == null) return;

        levelText.text = $"LVL.{currentLevel}";
        int price = statData.GetPriceForLevel(currentLevel); // цена для текущего уровня
        priceText.text = $"${price.ToString()}";
        upgradeButton.interactable = currentMoney >= price;
    }

    public void Upgrade()
    {
        if (statData != null)
            UpgradeManager.Instance.TryUpgrade(statData);
    }
}
