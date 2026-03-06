using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OilCompanyItemView : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text oilPriceText;
    [SerializeField] private TMP_Text cunBuyOilText;
    [SerializeField] private TMP_Text companyStatusText;
    [SerializeField] private Button sellButton;

    private OilCompanyData company;

    public void Initialize(OilCompanyData companyData)
    {
        company = companyData;
        nameText.text = company.DisplayName;
        UpdateDisplay();
        company.OnDataChanged += UpdateDisplay;
        sellButton.onClick.AddListener(SellOil);
    }

    private void UpdateDisplay()
    {
        if (company == null) return;

        oilPriceText.text = $"${company.CurrentPrice:F2}";
        cunBuyOilText.text = $"Н:{company.CurrentOilAmount}";
        companyStatusText.text = $"Статус:{company.Status}";
    }

    public void SellOil()
    {
        company?.ConvertOil();
    }

    private void OnDestroy()
    {
        if (company != null)
            company.OnDataChanged -= UpdateDisplay;
        sellButton.onClick.RemoveListener(SellOil);
    }
}
