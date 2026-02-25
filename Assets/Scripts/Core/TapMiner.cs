using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TapMiner : MonoBehaviour
{
    public void OnPointerDown()
    {
        Pump.Instance.IncreaseInOil(Pump.Instance.OilCountMine, Pump.Instance.TapScale);
    }
}
