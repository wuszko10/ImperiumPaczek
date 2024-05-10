using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject upgradeButton; // Referencja do przycisku ULEPSZ w interfejsie u¿ytkownika

    void Start()
    {
        PointsManager.Instance.OnPoints10Reached += OnPoints10Reached;
    }

    void OnPoints10Reached()
    {
        // Wyœwietl komunikat na ekranie
        Debug.Log("BRAWO ZDOBY£EŒ 10 PUNKTÓW! MO¯ESZ ULEPSZYÆ MASZYNY!!");

        // W³¹cz przycisk ULEPSZ w interfejsie u¿ytkownika
        upgradeButton.SetActive(true);
    }
}
