using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapMiner : MonoBehaviour
{
    MainScr main;
    private void Start()
    {
        main = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<MainScr>();
    }

    public void IncreaseInOil(int oilCountPlus, int TapScale)
    {
        main.OilCount += oilCountPlus * TapScale;
        main.RefreshStats();
    }

    private void OnMouseDown()
    {
        transform.localScale *= 1.01f;
        IncreaseInOil(1, main.TapScale);
    }
    private void OnMouseUp()
    {
        transform.localScale /= 1.01f;
    }

}
