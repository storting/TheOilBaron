using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BackItems : MonoBehaviour
{
    public static BackItems Instance { get; private set; }
    public string ComponentSaveId => "BackStage";

    [SerializeField] private int _houseLevel = 1; //количество денег
    public int HouseLevel
    {
        get => _houseLevel;
        set
        {
            if (_houseLevel != value)
            {
                _houseLevel = value;
                OnHouseLevelChanged?.Invoke(_houseLevel); 
            }
        }
    }
    public event System.Action<int> OnHouseLevelChanged;

    [SerializeField] private int _carLevel = 1;
    public int CarLevel
    {
        get => _carLevel;
        set
        {
            if (_carLevel != value)
            {
                _carLevel = value;
                OnCarLevelChanged?.Invoke(_carLevel);
            }
        }
    }
    public event System.Action<int> OnCarLevelChanged;

    [SerializeField] private int _yardLevel = 1;
    public int YardLevel
    {
        get => _yardLevel;
        set
        {
            if( _yardLevel != value)
            {
                _yardLevel = value;
                OnYardLevelChanged?.Invoke(_yardLevel);
            }
        }
    }
    public event System.Action<int> OnYardLevelChanged;

    [SerializeField] private int _animalLevel = 1;
    public int AnimalLevel
    {
        get => _animalLevel;
        set
        {
            if ( _animalLevel != value)
            {
                _animalLevel = value;
                OnAnimalLevelChanged?.Invoke(_animalLevel);
            }
        }
    }
    public event System.Action<int> OnAnimalLevelChanged;

    [SerializeField] private int _frontHouseAeraLevel = 1;
    public int FrontHouseAeraLevel
    {
        get => _frontHouseAeraLevel;
        set
        {
            if (_frontHouseAeraLevel != value)
            {
                _frontHouseAeraLevel = value;
                OnFrontHouseAeraLevelChanged?.Invoke(_frontHouseAeraLevel);
            }
        }
    }
    public event System.Action<int> OnFrontHouseAeraLevelChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject); // Если нужно сохранять между сценами
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
