using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitEnter : MonoBehaviour
{

    GameEndTrigger gameEndTrigger;

    void Start()
    {
        gameEndTrigger = FindObjectOfType<GameEndTrigger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameEndTrigger.ShowPopup(other);
    }
}
