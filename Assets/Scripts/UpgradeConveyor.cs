using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeConveyor : MonoBehaviour
{
    public GameObject ExtendConveyorPrefab;
    public GameObject basicConveyorPrefab;
    public Transform spawnPoint;
    private float removalDistance = 5f;
    private GameObject[] basicConveyors;

    private ConveyorManager conveyorManager;
    private PointsManager pointsManager;
    private LevelManager levelManager;

    public int baseRequiredPoints;

    void Start()
    {
        conveyorManager = FindObjectOfType<ConveyorManager>();
        pointsManager = FindObjectOfType<PointsManager>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        basicConveyors = GameObject.FindGameObjectsWithTag("BasicConveyor");
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (GameObject conveyor in basicConveyors)
        {
            float distance = Vector3.Distance(transform.position, conveyor.transform.position);
            
            if (distance <= removalDistance)
            {
                if (pointsManager != null)
                {   
                    int upgradedConveyorCount = conveyorManager.GetUpgradedConveyorCount();
                    int requiredPoints = baseRequiredPoints * (upgradedConveyorCount + 1);
            
                    int currentPoints = pointsManager.GetPoints();


                    if (conveyorManager != null && conveyorManager.CanUpgradeConveyor() && currentPoints >= requiredPoints)
                    {                    
                        Destroy(conveyor);
                        Vector3 adjustedSpawnPosition = spawnPoint.position + spawnPoint.forward * 8f;
                        GameObject newExtendConveyor = Instantiate(ExtendConveyorPrefab, adjustedSpawnPosition, spawnPoint.rotation);
                        conveyorManager.IncreaseUpgradedConveyorCount();
                        pointsManager.SubtractPoints(requiredPoints);
                        levelManager.AddLevel();
                        Destroy(gameObject);
                    }
                    else
                    {
                        int neededPoints = requiredPoints - currentPoints;
                        Debug.Log("Za ma³o punktów. Potrzebujesz jeszcze " + neededPoints + " pkt aby ulepszyæ tê maszynê");
                    }
                }
            }            

        }
    }
}