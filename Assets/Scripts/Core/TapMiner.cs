using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TapMiner : MonoBehaviour
{
    [SerializeField] private Player player;

    void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();

            if (player == null)
            {
                Debug.LogError("Player не найден на сцене!");
                return;
            }
        }
    }

    public void IncreaseInOil(int oilCountPlus, int TapScale)
    {
        player.OilCount += oilCountPlus * TapScale;
    }

    public void OnPointerDown()
    {
        IncreaseInOil(1, player.TapScale);
    }
}
