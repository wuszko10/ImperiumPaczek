using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public int currency = 0;
    public TextMeshProUGUI currencyText;

    void Start()
    {
        UpdateCurrencyText();
    }

    public void AddCurrency(int amount)
    {
        currency += amount;
        UpdateCurrencyText();
    }

    void UpdateCurrencyText()
    {
        if (currencyText != null)
        {
            currencyText.text = "Currency: " + currency.ToString();
        }
    }
}
