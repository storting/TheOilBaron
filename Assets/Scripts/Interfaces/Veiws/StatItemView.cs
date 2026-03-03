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

    private IUpgradable upgradable;

    private void Awake()
    {
        // если кнопка не привязана в инспекторе, привяжем программно
        // if (upgradeButton != null)
        //    upgradeButton.onClick.AddListener(Upgrade);
    }

    public void Initialize(IUpgradable data)
    {
        upgradable = data;
        nameText.text = data.DisplayName;
    }

    public void UpdateDisplay()
    {
        if (this == null || upgradeButton == null) return;

        levelText.text = $"LVL.{upgradable.CurrentLevel}";
        priceText.text = "$" + upgradable.GetPriceForNextLevel().ToString();
        upgradeButton.interactable = upgradable.CanUpgrade();
    }

    public void Upgrade()
    {
        if (upgradable != null)
            UpgradeManager.Instance.TryUpgrade(upgradable);
    }
    private void OnDestroy()
    {
        if (upgradeButton != null)
            upgradeButton.onClick.RemoveListener(Upgrade);
    }
}
