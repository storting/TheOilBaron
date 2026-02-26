using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pump : MonoBehaviour
{
    public static Pump Instance { get; private set; }
    public string ComponentSaveId => "Pump";
    public SaveLoadData GetSaveLoadData()
    {
        return new SaveLoadData(
            ComponentSaveId,
            new object[]
            {
                OilStorageLVL,
                PumpPistonLVL,
                PumpElectricMotorLVL,
                PumpBearingsLVL,
                PumpHandlesLVL,
                PumpPipeVolumeLVL,
                MineScale,
                MineTime,
                OilCountMine,
                TapScale
            }
        );
    }

    public void RestoreValues(SaveLoadData loadData)
    {
        var data = loadData.Data;
        OilStorageLVL = Convert.ToInt32(data[0]);
        PumpPistonLVL = Convert.ToInt32(data[1]);
        PumpElectricMotorLVL = Convert.ToInt32(data[3]);
        PumpBearingsLVL = Convert.ToInt32(data[4]);
        PumpHandlesLVL = Convert.ToInt32(data[5]);
        PumpPipeVolumeLVL = Convert.ToInt32(data[6]);
        MineScale = Convert.ToInt32(data[7]);
        MineTime = Convert.ToInt32(data[8]);
        OilCountMine = Convert.ToInt32(data[9]);
        TapScale = Convert.ToInt32(data[10]);
    }

    // Статы для прокачки на нефтином нассосе (passive)
    [SerializeField] private int _oilStorageLVL = 1;
    public int OilStorageLVL
    {
        get => _oilStorageLVL;
        set
        {
            if (_oilStorageLVL != value)
            {
                _oilStorageLVL = value;
                OnOilStorageLVLChanged?.Invoke(_oilStorageLVL); //событие для переменной
                {
                    OilStorage *= value; // Шаг увеличения хранилища в зависимости от уровня(Придумать)
                }
            }
        }
    }
    public event System.Action<int> OnOilStorageLVLChanged;

    [SerializeField] private int _pumpPistonLVL = 1;
    public int PumpPistonLVL
    {
        get => _pumpPistonLVL;
        set
        {
            if (_pumpPistonLVL != value)
            {
                _pumpPistonLVL = value;
                OnPumpPistonLVLChanged?.Invoke(_pumpPistonLVL);
            }
        }
    }
    public event System.Action<int> OnPumpPistonLVLChanged;

    [SerializeField] private int _pumpElectricMotorLVL = 1;
    public int PumpElectricMotorLVL
    {
        get => _pumpElectricMotorLVL;
        set
        {
            if ( _pumpElectricMotorLVL != value)
            {
                _pumpElectricMotorLVL= value;
                OnPumpElectricMotorLVLChanged?.Invoke(_pumpElectricMotorLVL);
            }
        }
    }
    public event System.Action<int> OnPumpElectricMotorLVLChanged;

    [SerializeField] private int _pumpBearingsLVL = 1;
    public int PumpBearingsLVL
    {
        get => _pumpBearingsLVL;
        set
        {
            if( _pumpBearingsLVL != value)
            {
                _pumpElectricMotorLVL = value;
                OnPumpBearingsLVLChanged?.Invoke(_pumpElectricMotorLVL);
            }
        }
    }
    public event System.Action<int> OnPumpBearingsLVLChanged;

    // Статы для прокачки на нефтином нассосе (active)
    [SerializeField] private int _pumpHandlesLVL = 1;
    public int PumpHandlesLVL
    {
        get => _pumpHandlesLVL;
        set
        {
            if (_pumpHandlesLVL != value)
            {
                _pumpHandlesLVL = value;
                OnPumpHandlesLVLChanged?.Invoke(_pumpHandlesLVL);
            }
        }
    }
    public event System.Action<int> OnPumpHandlesLVLChanged;

    [SerializeField] private int _pumpPipeVolumeLVL = 1;
    public int PumpPipeVolumeLVL
    {
        get => _pumpPipeVolumeLVL;
        set
        {
            if ( _pumpPipeVolumeLVL != value)
            {
                _pumpPipeVolumeLVL = value;
                OnPumpPipeVolumeLVLChanged?.Invoke(_pumpPipeVolumeLVL);
            }
        }
    }
    public event System.Action<int> OnPumpPipeVolumeLVLChanged;

    public int OilStorage = 350; // Хранилище нефти(Максимальное количество нефти)

    public float MineScale = 1f; // Произведение для увиличения количества нефти за круг насососа
    public int MineTime = 15; // Время за которое насос качает количество нефти(OilCountMine)

    public int OilCountMine = 1; // Количество нефти которое мы фармим за тайм(MineTime)

    public float TapScale = 1f; // Произведение для увиличения количества нефти за тап

    private void OilPassiveFarm() // Пассивный фарм
    {
        float temp = OilCountMine * MineScale;
        Player.Instance.OilCount += Mathf.RoundToInt(temp);
        // Debug.Log("OilPassiveFarm == True");
    }

    public void IncreaseInOil(int oilCountPlus, float TapScale)
    {
        Player.Instance.OilCount += Convert.ToInt32(oilCountPlus * TapScale);
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject); // Если нужно сохранять между сценами
        }
        else
        {
            Destroy(gameObject);
        }
        InvokeRepeating("OilPassiveFarm", 0, MineTime);
    }
}
