using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject BoxWooden; // Prefab pude�ka drewnianego
    public Transform spawnPoint; // Punkt, w kt�rym b�d� tworzone pude�ka

    private float defaultSpawnInterval = 5f; // Domy�lny interwa� czasowy mi�dzy tworzeniem pude�ek
    private float fastSpawnInterval = 2f; // Interwa� czasowy mi�dzy tworzeniem pude�ek po szybkim ulepszeniu
    private bool automaticSpawnEnabled = true; // Flaga w��czaj�ca automatyczne tworzenie pude�ek
    private PointsManager pointsManager; // Referencja do skryptu zarz�dzaj�cego punktami

    private void Start()
    {
        pointsManager = PointsManager.Instance; // Zdob�d� referencj� do PointsManager
        if (pointsManager == null)
        {
            Debug.LogError("PointsManager script not found in the scene!");
            return;
        }

        // Rozpocznij automatyczne tworzenie pude�ek co okre�lony interwa� czasowy
        InvokeRepeating("SpawnBox", defaultSpawnInterval, defaultSpawnInterval);

        // Subskrybuj zdarzenie OnPoints10Reached
        pointsManager.OnPoints10Reached += OnPoints10Reached;
    }

    private void OnDestroy()
    {
        // Anuluj subskrypcj� zdarzenia, aby unikn�� wyciek�w pami�ci
        if (pointsManager != null)
        {
            pointsManager.OnPoints10Reached -= OnPoints10Reached;
        }
    }

    private void SpawnBox()
    {
        if (automaticSpawnEnabled && spawnPoint != null)
        {
            // Tworzymy pude�ko w punkcie spawnu
            GameObject spawnedBox = Instantiate(BoxWooden, spawnPoint.position, spawnPoint.rotation);

            // Nadajemy pude�ku drewnianemu odpowiedni tag
            spawnedBox.tag = "BoxWooden";
        }
    }

    // Metoda zmieniaj�ca interwa� czasowy tworzenia pude�ek na 1 sekund�
    public void FastSpawnInterval()
    {
        CancelInvoke("SpawnBox"); // Anuluj poprzednie wywo�anie metody SpawnBox

        // Rozpocznij automatyczne tworzenie pude�ek co 1 sekund�
        InvokeRepeating("SpawnBox", fastSpawnInterval, fastSpawnInterval);
    }

    // Metoda wywo�ywana po zdobyciu 10 punkt�w
    private void OnPoints10Reached()
    {
        // Zmie� interwa� czasowy tworzenia pude�ek na 1 sekund�
        FastSpawnInterval();
    }
}