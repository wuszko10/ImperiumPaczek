using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateConveyor : MonoBehaviour
{
    public GameObject ExtendConveyorPrefab;
    public GameObject basicConveyorPrefab;
    public Transform spawnPoint;
    private float removalDistance = 5f;
    private GameObject[] basicConveyors;

    //void OnCollisionEnter(Collision collision)
    //{
    //    GameObject newExtendConveyor = Instantiate(ExtendConveyorPrefab, spawnPoint.position, spawnPoint.rotation);
    //    Destroy(gameObject);
    // }

    void Update()
    {
        basicConveyors = GameObject.FindGameObjectsWithTag("BasicConveyor");
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (GameObject conveyor in basicConveyors)
        {
            float distance = Vector3.Distance(transform.position, conveyor.transform.position);
            
            // Jeœli odleg³oœæ jest mniejsza ni¿ okreœlona wartoœæ
            if (distance <= removalDistance)
            {
                Destroy(conveyor);
                Vector3 adjustedSpawnPosition = spawnPoint.position + spawnPoint.forward * 8f;
                GameObject newExtendConveyor = Instantiate(ExtendConveyorPrefab, adjustedSpawnPosition, spawnPoint.rotation);
                Destroy(gameObject);
            }
        }
    }

}
