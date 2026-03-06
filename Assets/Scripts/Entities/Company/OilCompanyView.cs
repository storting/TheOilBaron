using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class OilCompanyView : MonoBehaviour
{
    [SerializeField] private Transform companyContainer;  
    [SerializeField] private OilCompanyItemView companyItemPrefab; 
    [SerializeField] private OilCompanyData[] availableCompany;
    private void Start()
    {
        // Создаём элементы один раз
        foreach (var company in availableCompany)
        {
            var item = Instantiate(companyItemPrefab, companyContainer);
            item.Initialize(company);
        }
    }
}
