using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBoxes : MonoBehaviour
{
    public int pointsToAddWooden = 1; // Ilo�� punkt�w do dodania za zniszczenie pude�ka drewnianego
    public int pointsToAddUpgraded = 2; // Ilo�� punkt�w do dodania za zniszczenie ulepszonego pude�ka

    void OnTriggerEnter(Collider other)
    {
        // Sprawdzamy, czy obiekt, kt�ry wszed� w stref� kolizji, ma tag "BoxWooden"
        if (other.CompareTag("BoxWooden"))
        {
            // Je�li ma tag "BoxWooden", dodajemy odpowiedni� ilo�� punkt�w
            PointsManager.Instance.AddPoints(pointsToAddWooden);

            // Niszczymy pude�ko drewniane
            Destroy(other.gameObject);
        }
        // Sprawdzamy, czy obiekt, kt�ry wszed� w stref� kolizji, ma tag "UpgradedBox"
        else if (other.CompareTag("upgradedBox"))
        {
            // Je�li ma tag "UpgradedBox", dodajemy odpowiedni� ilo�� punkt�w
            PointsManager.Instance.AddPoints(pointsToAddUpgraded);

            // Niszczymy ulepszone pude�ko
            Destroy(other.gameObject);
        }
    }
}
