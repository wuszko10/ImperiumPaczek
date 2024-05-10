using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineInteraction : MonoBehaviour
{
    public GameObject upgradedBoxPrefab;
    public Transform spawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BoxWooden"))
        {
            Destroy(other.gameObject);

            if (spawnPoint != null)
            {
                // Tworzymy ulepszone pude³ko
                GameObject upgradedBox = Instantiate(upgradedBoxPrefab, spawnPoint.position, spawnPoint.rotation);

                // Nadajemy ulepszonemu pude³ku odpowiedni tag
                upgradedBox.tag = "upgradedBox";
            }
        }
    }
}
