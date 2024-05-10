using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject upgradeButton; // Referencja do przycisku ULEPSZ w interfejsie u�ytkownika

    void Start()
    {
        PointsManager.Instance.OnPoints10Reached += OnPoints10Reached;
    }

    void OnPoints10Reached()
    {
        // Wy�wietl komunikat na ekranie
        Debug.Log("BRAWO ZDOBY�E� 10 PUNKT�W! MO�ESZ ULEPSZY� MASZYNY!!");

        // W��cz przycisk ULEPSZ w interfejsie u�ytkownika
        upgradeButton.SetActive(true);
    }
}
