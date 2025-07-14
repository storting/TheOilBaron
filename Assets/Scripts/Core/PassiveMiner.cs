using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class PassiveMiner : MonoBehaviour
{
    public float MineScale = 1f;
    public int OilCountMine = 1;

    private MainScr _main;
    private void Start()
    {
        _main = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<MainScr>();
        InvokeRepeating("OilPassiveFarm", 0, 18);
    }

    private void OilPassiveFarm()
    {
        float temp = OilCountMine * MineScale;
        _main.OilCount += Mathf.RoundToInt(temp);
        _main.RefreshStats();
    }
}
