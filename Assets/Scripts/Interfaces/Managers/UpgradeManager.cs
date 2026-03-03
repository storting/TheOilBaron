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

    public bool TryUpgrade(IUpgradable upgradable)
    {
        if (upgradable == null)
        {
            Debug.LogError("Upgradable is null");
            return false;
        }

        if (!upgradable.CanUpgrade())
        {
            // UIManager.Instance?.ShowNotification("Недостаточно средств");
            return false;
        }

        upgradable.Upgrade();
        Debug.Log($"Улучшено: {upgradable.DisplayName} до уровня {upgradable.CurrentLevel}");
        return true;
    }
}
