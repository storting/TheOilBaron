using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLoyaltyStats : MonoBehaviour
{
    public string StatName;
    public int StatPrice = 200;

    private Player player;
    void Awake()
    {
        // Ищем Player если не присвоен
        if (player == null)
        {
            player = FindObjectOfType<Player>();

            // Если всё равно не нашли - ошибка
            if (player == null)
            {
                Debug.LogError("Player не найден на сцене!");
                return;
            }
        }
    }

    private TMP_Text _LVLText;
    private TMP_Text _priceText;

    private void Start()
    {
        _LVLText = transform.Find("LVLText").GetComponent<TMP_Text>();
        _priceText = transform.Find("PriceText").GetComponent<TMP_Text>();
        _LVLText.text = "LVL.";
        _priceText.text = "$";
        switch (StatName) 
        {
            case "Charisma":
                _LVLText.text += player .Charisma.ToString();
                _priceText.text += StatPrice.ToString();
                break;
            case "Erudition":
                _LVLText.text += player.Erudition.ToString();
                _priceText.text += StatPrice.ToString();
                break;
            case "Intelligence":
                _LVLText.text += player.Intelligence.ToString();
                _priceText.text += StatPrice.ToString();
                break;
            case "Eloquence":
                _LVLText.text += player.Eloquence.ToString();
                _priceText.text += StatPrice.ToString();
                break;
        }
    }
}
