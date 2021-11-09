using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EconomyScript : MonoBehaviour
{
    public static EconomyScript instance = null;

    [SerializeField]
    private int totalCurrency;
    [SerializeField]
    private TextMeshProUGUI currencyText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateCurrency();
    }

    public void AddCurrency(int ammount)
    {
        totalCurrency += ammount;
        UpdateCurrency();
    }

    public void ReduceCurrency(int ammount)
    {
        totalCurrency -= ammount;
        UpdateCurrency();
    }

    public bool CanAfford(int ammount)
    {
        if (totalCurrency - ammount >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateCurrency()
    {
        currencyText.text = "$" + totalCurrency.ToString();
    }
}
