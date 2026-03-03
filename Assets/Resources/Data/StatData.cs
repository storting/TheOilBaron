using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStat", menuName = "Stats/Stat Data", order = 51)]
public class StatData : ScriptableObject, IUpgradable
{
    public enum StatType
    {
        Charisma,
        Erudition,
        Intelligence,
        Eloquence,
        Head,
        Torso,
        Legs,
        Shoes
    }

    [SerializeField] private string _statName;
    [SerializeField] private int _basePrice;
    [SerializeField] private float _priceMultiplier = 1.5f;
    [SerializeField] private StatType _statType;

    public string DisplayName => _statName;
    public StatType Type => _statType;

    public int CurrentLevel
    {
        get
        {
            switch (_statType)
            {
                case StatType.Charisma: return Player.Instance.Charisma;
                case StatType.Erudition: return Player.Instance.Erudition;
                case StatType.Intelligence: return Player.Instance.Intelligence;
                case StatType.Eloquence: return Player.Instance.Eloquence;
                case StatType.Head: return Player.Instance.HeadLevel;
                case StatType.Torso: return Player.Instance.TorsoLevel;
                case StatType.Legs: return Player.Instance.LegsLevel;
                case StatType.Shoes: return Player.Instance.ShoesLevel;
                default: return 1;
            }
        }
    }

    public int GetPriceForNextLevel()
    {
        // цена за переход с текущего уровн€ на следующий
        return Mathf.RoundToInt(_basePrice * Mathf.Pow(_priceMultiplier, CurrentLevel));
    }

    public bool CanUpgrade()
    {
        return Player.Instance.MoneyCount >= GetPriceForNextLevel();
    }

    public void Upgrade()
    {
        if (!CanUpgrade()) return;

        Player.Instance.MoneyCount -= GetPriceForNextLevel();

        switch (_statType)
        {
            case StatType.Charisma: Player.Instance.Charisma++; break;
            case StatType.Erudition: Player.Instance.Erudition++; break;
            case StatType.Intelligence: Player.Instance.Intelligence++; break;
            case StatType.Eloquence: Player.Instance.Eloquence++; break;
            case StatType.Head: Player.Instance.HeadLevel++; break;
            case StatType.Torso: Player.Instance.TorsoLevel++; break;
            case StatType.Legs: Player.Instance.LegsLevel++; break;
            case StatType.Shoes: Player.Instance.ShoesLevel++; break;
        }
    }

    // ќригинальный метод дл€ расчЄта цены (может пригодитьс€)
    public int GetPriceForLevel(int level)
    {
        return Mathf.RoundToInt(_basePrice * Mathf.Pow(_priceMultiplier, level));
    }
}
