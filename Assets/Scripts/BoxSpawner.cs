using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject BoxWooden; // Prefab pude³ka drewnianego
    public Transform spawnPoint; // Punkt, w którym bêd¹ tworzone pude³ka

    private float defaultSpawnInterval = 5f; // Domyœlny interwa³ czasowy miêdzy tworzeniem pude³ek
    private float fastSpawnInterval = 2f; // Interwa³ czasowy miêdzy tworzeniem pude³ek po szybkim ulepszeniu
    private bool automaticSpawnEnabled = true; // Flaga w³¹czaj¹ca automatyczne tworzenie pude³ek
    private PointsManager pointsManager; // Referencja do skryptu zarz¹dzaj¹cego punktami

    private void Start()
    {
        pointsManager = PointsManager.Instance; // Zdob¹dŸ referencjê do PointsManager
        if (pointsManager == null)
        {
            Debug.LogError("PointsManager script not found in the scene!");
            return;
        }

        // Rozpocznij automatyczne tworzenie pude³ek co okreœlony interwa³ czasowy
        InvokeRepeating("SpawnBox", defaultSpawnInterval, defaultSpawnInterval);

        // Subskrybuj zdarzenie OnPoints10Reached
        pointsManager.OnPoints10Reached += OnPoints10Reached;
    }

    private void OnDestroy()
    {
        // Anuluj subskrypcjê zdarzenia, aby unikn¹æ wycieków pamiêci
        if (pointsManager != null)
        {
            pointsManager.OnPoints10Reached -= OnPoints10Reached;
        }
    }

    private void SpawnBox()
    {
        if (automaticSpawnEnabled && spawnPoint != null)
        {
            // Tworzymy pude³ko w punkcie spawnu
            GameObject spawnedBox = Instantiate(BoxWooden, spawnPoint.position, spawnPoint.rotation);

            // Nadajemy pude³ku drewnianemu odpowiedni tag
            spawnedBox.tag = "BoxWooden";
        }
    }

    // Metoda zmieniaj¹ca interwa³ czasowy tworzenia pude³ek na 1 sekundê
    public void FastSpawnInterval()
    {
        CancelInvoke("SpawnBox"); // Anuluj poprzednie wywo³anie metody SpawnBox

        // Rozpocznij automatyczne tworzenie pude³ek co 1 sekundê
        InvokeRepeating("SpawnBox", fastSpawnInterval, fastSpawnInterval);
    }

    // Metoda wywo³ywana po zdobyciu 10 punktów
    private void OnPoints10Reached()
    {
        // Zmieñ interwa³ czasowy tworzenia pude³ek na 1 sekundê
        FastSpawnInterval();
    }
}