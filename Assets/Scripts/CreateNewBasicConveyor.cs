using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewBasicConveyor : MonoBehaviour
{
    public GameObject BasicConveyorPrefab;
    public GameObject UpdateConveyorPrefab;
    public Transform spawnPoint;
    private float newYOffset = 12f;
    private ConveyorManager conveyorManager;

    void Start()
    {
        conveyorManager = FindObjectOfType<ConveyorManager>();
    }

    void OnCollisionEnter(Collision collision)
    {

        if (conveyorManager != null && conveyorManager.CanCreateConveyor())
        {
            GameObject newBasicConveyor = Instantiate(BasicConveyorPrefab, spawnPoint.position, spawnPoint.rotation);
            Vector3 leftOffset = transform.right * 2f;
            GameObject newUpdateConveyor = Instantiate(UpdateConveyorPrefab, transform.position + leftOffset, transform.rotation);

            conveyorManager.IncreaseBasicConveyorCount();

            if (conveyorManager.CanCreateConveyor())
            {
                Vector3 newCreateConveyorPosition = transform.position + Vector3.forward * newYOffset;
                GameObject newCreateConveyor = Instantiate(gameObject, newCreateConveyorPosition, transform.rotation);
                
            }

            Destroy(gameObject);
        }
    }
}
