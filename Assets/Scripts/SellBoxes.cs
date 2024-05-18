using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBoxes : MonoBehaviour
{
    public int pointsToAddWooden = 1; // Ilość punktów do dodania za zniszczenie pudełka drewnianego
    public int pointsToAddUpgraded = 2; // Ilość punktów do dodania za zniszczenie ulepszonego pudełka

    void OnTriggerEnter(Collider other)
    {
        // Sprawdzamy, czy obiekt, który wszedł w strefę kolizji, ma tag "BoxWooden"
        if (other.CompareTag("BoxWooden"))
        {
            // Jeśli ma tag "BoxWooden", dodajemy odpowiednią ilość punktów
            PointsManager.Instance.AddPoints(pointsToAddWooden);

            // Niszczymy pudełko drewniane
            Destroy(other.gameObject);
        }
        // Sprawdzamy, czy obiekt, który wszedł w strefę kolizji, ma tag "UpgradedBox"
        else if (other.CompareTag("upgradedBox"))
        {
            // Jeśli ma tag "UpgradedBox", dodajemy odpowiednią ilość punktów
            PointsManager.Instance.AddPoints(pointsToAddUpgraded);

            // Niszczymy ulepszone pudełko
            Destroy(other.gameObject);
        }
    }
}