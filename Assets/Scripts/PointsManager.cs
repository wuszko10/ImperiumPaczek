using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public static PointsManager Instance; // Referencja do instancji, aby skrypt by³ dostêpny globalnie
    public TMP_Text pointsText; // Referencja do komponentu TMP_Text, który bêdzie wyœwietla³ punkty
    private int totalPoints = 0; // Ca³kowita liczba punktów

    // Zdarzenie wywo³ywane po zdobyciu 10 punktów
    public event System.Action OnPoints10Reached;

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

    private void Start()
    {
        UpdatePointsUI(); // Na pocz¹tku aktualizujemy wyœwietlan¹ liczbê punktów
    }

    private void UpdatePointsUI()
    {
        // Aktualizacja tekstu wyœwietlaj¹cego punkty
        pointsText.text = "Points: " + totalPoints;
    }

    public void AddPoints(int pointsToAdd)
    {
        // Dodawanie punktów
        totalPoints += pointsToAdd;
        UpdatePointsUI(); // Aktualizacja wyœwietlanego tekstu
        
        // SprawdŸ, czy osi¹gniêto 10 punktów
        if (totalPoints >= 10 && OnPoints10Reached != null)
        {
            OnPoints10Reached(); // Wywo³aj zdarzenie
        }
    }
    
    public int GetPoints()
    {
        return totalPoints;
    }

    public void SubtractPoints(int points)
    {
        totalPoints -= points;
        UpdatePointsUI();
    }
}

