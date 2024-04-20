using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject BoxWooden;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnBox();
        }
    }

    void SpawnBox()
    {
        if (spawnPoint != null)
        {
            Instantiate(BoxWooden, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
