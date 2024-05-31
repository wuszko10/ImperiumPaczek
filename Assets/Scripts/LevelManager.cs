using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance; // Referencja do instancji, aby skrypt by³ dostêpny globalnie
    public TMP_Text levelText; // Referencja do komponentu TMP_Text, który bêdzie wyœwietla³ punkty
    private int totalLevels = 1; // Ca³kowita liczba punktów

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple instances of PointsManager found!");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateLevelsUI();
    }

    private void UpdateLevelsUI()
    {
        levelText.text = "Level: " + totalLevels;
    }

    public void AddLevel()
    {
        totalLevels += 1;
        UpdateLevelsUI();
    }

    public int GetLevels()
    {
        return totalLevels;
    }

}
