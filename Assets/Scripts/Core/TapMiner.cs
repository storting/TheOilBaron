using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapMiner : MonoBehaviour
{
    private MainScr _main;
    private float lastExecutionTime = 0f;
    private float debounceDelay = 0.2f; 

    private void Start()
    {
        _main = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<MainScr>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    break;
                case TouchPhase.Moved:
                    // Проверяем, прошло ли достаточное время с предыдущего вызова
                    if (Time.time - lastExecutionTime >= debounceDelay)
                    {
                        IncreaseInOil(1, _main.TapScale);
                        lastExecutionTime = Time.time; // Запоминаем новое время
                    }
                    break;
                case TouchPhase.Ended:
                    IncreaseInOil(1, _main.TapScale);
                    break;
            }
        }
    }

    public void IncreaseInOil(int oilCountPlus, int TapScale)
    {
        _main.OilCount += oilCountPlus * TapScale;
        _main.RefreshStats();
    }

    private void OnMouseDown()
    {
        //IncreaseInOil(1, _main.TapScale);
    }
}
