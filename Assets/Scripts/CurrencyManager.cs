using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public int currency = 0; // Player's currency amount
    public TextMeshProUGUI currencyText; // Text component to display currency on the building

    void Start()
    {
        UpdateCurrencyText(); // Update the displayed currency text initially
    }

    // Method to increase currency when a box is sold
    public void AddCurrency(int amount)
    {
        currency += amount;
        UpdateCurrencyText(); // Update displayed text when currency changes
    }

    // Update the displayed currency text on the building
    void UpdateCurrencyText()
    {
        if (currencyText != null)
        {
            currencyText.text = "Currency: " + currency.ToString();
        }
    }
}
