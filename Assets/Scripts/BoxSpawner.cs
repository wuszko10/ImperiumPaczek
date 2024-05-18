using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject BoxWooden; // Prefab pudełka drewnianego
    public Transform spawnPoint; // Punkt, w którym będą tworzone pudełka

    private float defaultSpawnInterval = 5f; // Domyślny interwał czasowy między tworzeniem pudełek
    private float fastSpawnInterval = 2f; // Interwał czasowy między tworzeniem pudełek po szybkim ulepszeniu
    private bool automaticSpawnEnabled = true; // Flaga włączająca automatyczne tworzenie pudełek
    private PointsManager pointsManager; // Referencja do skryptu zarządzającego punktami

    private void Start()
    {
        pointsManager = PointsManager.Instance; // Zdobądź referencję do PointsManager
        if (pointsManager == null)
        {
            Debug.LogError("PointsManager script not found in the scene!");
            return;
        }

        // Rozpocznij automatyczne tworzenie pudełek co określony interwał czasowy
        InvokeRepeating("SpawnBox", defaultSpawnInterval, defaultSpawnInterval);

        // Subskrybuj zdarzenie OnPoints10Reached
        pointsManager.OnPoints10Reached += OnPoints10Reached;
    }

    private void OnDestroy()
    {
        // Anuluj subskrypcję zdarzenia, aby uniknąć wycieków pamięci
        if (pointsManager != null)
        {
            pointsManager.OnPoints10Reached -= OnPoints10Reached;
        }
    }

    private void SpawnBox()
    {
        if (automaticSpawnEnabled && spawnPoint != null)
        {
            // Tworzymy pudełko w punkcie spawnu
            GameObject spawnedBox = Instantiate(BoxWooden, spawnPoint.position, spawnPoint.rotation);

            // Nadajemy pudełku drewnianemu odpowiedni tag
            spawnedBox.tag = "BoxWooden";
        }
    }

    // Metoda zmieniająca interwał czasowy tworzenia pudełek na 1 sekundę
    public void FastSpawnInterval()
    {
        CancelInvoke("SpawnBox"); // Anuluj poprzednie wywołanie metody SpawnBox

        // Rozpocznij automatyczne tworzenie pudełek co 1 sekundę
        InvokeRepeating("SpawnBox", fastSpawnInterval, fastSpawnInterval);
    }

    // Metoda wywoływana po zdobyciu 10 punktów
    private void OnPoints10Reached()
    {
        // Zmień interwał czasowy tworzenia pudełek na 1 sekundę
        FastSpawnInterval();
    }
}