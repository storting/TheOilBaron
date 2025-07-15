using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void OnMouseDown()
    {
        IncreaseInOil(1, _main.TapScale);
    }
}
