using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewObj", menuName = "BackObjects/Obj Data", order = 51)]
public class BackObjData : ScriptableObject, IUpgradable
    { 
        public enum ObjType
    {
        House,
        Car,
        Yard,
        Animal,
        FrontHouseAera
    }

    [SerializeField] private string _objName;
    [SerializeField] private int _basePrice;
    [SerializeField] private float _priceMultiplier = 1.5f;
    [SerializeField] private ObjType _objType;

    public string DisplayName => _objName;
    public ObjType Type => _objType;

    public int CurrentLevel
    {
        get
        {
            switch (_objType)
            {
                case ObjType.House: return BackItems.Instance.HouseLevel;
                case ObjType.Car: return BackItems.Instance.CarLevel;
                case ObjType.Yard: return BackItems.Instance.YardLevel;
                case ObjType.Animal: return BackItems.Instance.AnimalLevel;
                case ObjType.FrontHouseAera: return BackItems.Instance.FrontHouseAeraLevel;
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

        switch (_objType)
        {
            case ObjType.House: BackItems.Instance.HouseLevel++; break;
            case ObjType.Car: BackItems.Instance.CarLevel++; break;
            case ObjType.Yard: BackItems.Instance.YardLevel++; break;
            case ObjType.Animal: BackItems.Instance.AnimalLevel++; break;
            case ObjType.FrontHouseAera: BackItems.Instance.FrontHouseAeraLevel++; break;
        }
    }

    // ќригинальный метод дл€ расчЄта цены (может пригодитьс€)
    public int GetPriceForLevel(int level)
    {
        return Mathf.RoundToInt(_basePrice * Mathf.Pow(_priceMultiplier, level));
    }
}
