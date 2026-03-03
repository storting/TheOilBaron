using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PumpUpgrade", menuName = "Stats/Pump Upgrade Data", order = 52)]
public class PumpComponentData : ScriptableObject, IUpgradable
{
    public enum ComponentType
    {
        OilStorage,      // _oilStorageLVL
        Piston,          // _pumpPistonLVL
        ElectricMotor,   // _pumpElectricMotorLVL
        Bearings,        // _pumpBearingsLVL
        Handles,         // _pumpHandlesLVL
        PipeVolume       // _pumpPipeVolumeLVL
    }

    [SerializeField] private string _displayName;
    [SerializeField] private ComponentType _componentType;
    [SerializeField] private int _basePrice = 100;          // цена первого уровня
    [SerializeField] private float _priceMultiplier = 1.8f; // множитель цены

    public string DisplayName => _displayName;

    public int CurrentLevel
    {
        get
        {
            switch (_componentType)
            {
                case ComponentType.OilStorage: return Pump.Instance.OilStorageLVL;
                case ComponentType.Piston: return Pump.Instance.PumpPistonLVL;
                case ComponentType.ElectricMotor: return Pump.Instance.PumpElectricMotorLVL;
                case ComponentType.Bearings: return Pump.Instance.PumpBearingsLVL;
                case ComponentType.Handles: return Pump.Instance.PumpHandlesLVL;
                case ComponentType.PipeVolume: return Pump.Instance.PumpPipeVolumeLVL;
                default: return 1;
            }
        }
    }

    public int GetPriceForNextLevel()
    {
        // Цена = базовая * множитель^(текущий уровень)
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

        // Повышаем соответствующий уровень в Pump
        switch (_componentType)
        {
            case ComponentType.OilStorage: Pump.Instance.OilStorageLVL++; break;
            case ComponentType.Piston: Pump.Instance.PumpPistonLVL++; break;
            case ComponentType.ElectricMotor: Pump.Instance.PumpElectricMotorLVL++; break;
            case ComponentType.Bearings: Pump.Instance.PumpBearingsLVL++; break;
            case ComponentType.Handles: Pump.Instance.PumpHandlesLVL++; break;
            case ComponentType.PipeVolume: Pump.Instance.PumpPipeVolumeLVL++; break;
        }
    }
}
