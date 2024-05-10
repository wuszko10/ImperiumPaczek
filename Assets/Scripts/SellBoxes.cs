using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBoxes : MonoBehaviour
{
    public int pointsToAddWooden = 1; // Iloœæ punktów do dodania za zniszczenie pude³ka drewnianego
    public int pointsToAddUpgraded = 2; // Iloœæ punktów do dodania za zniszczenie ulepszonego pude³ka

    void OnTriggerEnter(Collider other)
    {
        // Sprawdzamy, czy obiekt, który wszed³ w strefê kolizji, ma tag "BoxWooden"
        if (other.CompareTag("BoxWooden"))
        {
            // Jeœli ma tag "BoxWooden", dodajemy odpowiedni¹ iloœæ punktów
            PointsManager.Instance.AddPoints(pointsToAddWooden);

            // Niszczymy pude³ko drewniane
            Destroy(other.gameObject);
        }
        // Sprawdzamy, czy obiekt, który wszed³ w strefê kolizji, ma tag "UpgradedBox"
        else if (other.CompareTag("upgradedBox"))
        {
            // Jeœli ma tag "UpgradedBox", dodajemy odpowiedni¹ iloœæ punktów
            PointsManager.Instance.AddPoints(pointsToAddUpgraded);

            // Niszczymy ulepszone pude³ko
            Destroy(other.gameObject);
        }
    }
}
