using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatItemView : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private Button upgradeButton;

    private StatData statData;
    private System.Action<StatData> onUpgradeClicked;

    public void Initialize(StatData data, System.Action<StatData> upgradeCallback)
    {
        statData = data;
        onUpgradeClicked = upgradeCallback;
        nameText.text = data.StatName;          // берём название из ассета
        upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
    }

    public void UpdateDisplay(int currentLevel, int currentMoney)
    {
        levelText.text = $"LVL.{currentLevel}";
        int price = statData.GetPriceForLevel(currentLevel); // цена для текущего уровня
        priceText.text = $"${price.ToString()}";
        upgradeButton.interactable = currentMoney >= price;
    }

    private void OnUpgradeButtonClick()
    {
        onUpgradeClicked?.Invoke(statData);    // передаём ассет в колбэк
    }

    private void OnDestroy()
    {
        upgradeButton.onClick.RemoveListener(OnUpgradeButtonClick);
    }
}
