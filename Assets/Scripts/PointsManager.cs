using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public static PointsManager Instance; // Referencja do instancji, aby skrypt by� dost�pny globalnie
    public TMP_Text pointsText; // Referencja do komponentu TMP_Text, kt�ry b�dzie wy�wietla� punkty
    private int totalPoints = 0; // Ca�kowita liczba punkt�w

    // Zdarzenie wywo�ywane po zdobyciu 10 punkt�w
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
        UpdatePointsUI(); // Na pocz�tku aktualizujemy wy�wietlan� liczb� punkt�w
    }

    private void UpdatePointsUI()
    {
        // Aktualizacja tekstu wy�wietlaj�cego punkty
        pointsText.text = "Points: " + totalPoints;
    }

    public void AddPoints(int pointsToAdd)
    {
        // Dodawanie punkt�w
        totalPoints += pointsToAdd;
        UpdatePointsUI(); // Aktualizacja wy�wietlanego tekstu
        
        // Sprawd�, czy osi�gni�to 10 punkt�w
        if (totalPoints >= 10 && OnPoints10Reached != null)
        {
            OnPoints10Reached(); // Wywo�aj zdarzenie
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

