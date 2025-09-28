using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TapMiner : MonoBehaviour
{
    private MainScr _main;

    private void Start()
    {
        _main = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<MainScr>();
    }

    public void IncreaseInOil(int oilCountPlus, int TapScale)
    {
        _main.OilCount += oilCountPlus * TapScale;
        _main.RefreshStats();
    }

    public void OnPointerDown()
    {
        IncreaseInOil(1, _main.TapScale);
    }
}
