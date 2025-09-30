using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public string StatName;
    public int StatPrice = 200;

    private MainScr _main;

    private TMP_Text _LVLText;
    private TMP_Text _priceText;

    private void Start()
    {
        _main = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<MainScr>();
        _LVLText = transform.Find("LVLText").GetComponent<TMP_Text>();
        _priceText = transform.Find("PriceText").GetComponent<TMP_Text>();
        _LVLText.text = "LVL.";
        _priceText.text = "$";
        switch (StatName) 
        {
            case "Charisma":
                _LVLText.text += _main.Charisma.ToString();
                _priceText.text += StatPrice.ToString();
                break;
            case "Erudition":
                _LVLText.text += _main.Erudition.ToString();
                _priceText.text += StatPrice.ToString();
                break;
            case "Intelligence":
                _LVLText.text += _main.Intelligence.ToString();
                _priceText.text += StatPrice.ToString();
                break;
            case "Eloquence":
                _LVLText.text += _main.Eloquence.ToString();
                _priceText.text += StatPrice.ToString();
                break;
        }
    }
}
