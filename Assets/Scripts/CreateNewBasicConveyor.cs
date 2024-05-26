using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewBasicConveyor : MonoBehaviour
{
    public GameObject BasicConveyorPrefab;
    public GameObject UpgradeConveyorBoxPrefab;
    public Transform spawnPoint;
    private float newYOffset = 12f;
    private ConveyorManager conveyorManager;
    private PointsManager pointsManager;

    // Globalna zmienna zdefiniowana przez u�ytkownika
    public int baseRequiredPoints;

    void Start()
    {
        conveyorManager = FindObjectOfType<ConveyorManager>();
        pointsManager = FindObjectOfType<PointsManager>(); // Za��my, �e jest taki skrypt
    }

    void OnCollisionEnter(Collision collision)
    {
        if (pointsManager != null)
        {
            int basicConveyorCount = conveyorManager.GetBasicConveyorCount();
            int requiredPoints = baseRequiredPoints * (basicConveyorCount + 1);

            int currentPoints = pointsManager.GetPoints(); // U�ycie metody GetPoints()

            if (currentPoints >= requiredPoints)
            {

                if (conveyorManager != null && conveyorManager.CanCreateConveyor())
                {
                    GameObject newBasicConveyor = Instantiate(BasicConveyorPrefab, spawnPoint.position, spawnPoint.rotation);
                    Vector3 leftOffset = transform.right * 2f;
                    GameObject newUpdateConveyorBox = Instantiate(UpgradeConveyorBoxPrefab, transform.position + leftOffset, transform.rotation);

                    conveyorManager.IncreaseBasicConveyorCount();

                    if (conveyorManager.CanCreateConveyor())
                    {
                        Vector3 newCreateConveyorPosition = transform.position + Vector3.forward * newYOffset;
                        GameObject newCreateConveyor = Instantiate(gameObject, newCreateConveyorPosition, transform.rotation);

                    }

                    pointsManager.SubtractPoints(requiredPoints);

                    Destroy(gameObject);
                }
            }
            else
            {
                int neededPoints = requiredPoints - currentPoints;
                Debug.Log("Za mało punktów. Potrzebujesz jeszcze " + neededPoints + " pkt aby kupić tę maszynę");
            }
        }
    }
}