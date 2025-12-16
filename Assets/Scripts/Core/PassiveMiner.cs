using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class PassiveMiner : MonoBehaviour
{
    public float MineScale = 1f;
    public int OilCountMine = 1;

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

    private void Start()
    {
        InvokeRepeating("OilPassiveFarm", 0, 18);
    }

    private void OilPassiveFarm() //Пассивный фарм(позже завязать на насосе)
    {
        float temp = OilCountMine * MineScale;
        player.OilCount += Mathf.RoundToInt(temp);
    }
}
