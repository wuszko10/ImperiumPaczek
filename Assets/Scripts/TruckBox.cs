using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckBox : MonoBehaviour
{

    public GameObject TruckPrefab;
    public GameObject ExitPrefab;
    public Transform spawnPoint;
    public Transform exitSpawnPoint;
    public int requiredPoints;
    public int requiredLevel;

    private PointsManager pointsManager;
    private LevelManager levelManager;

    void Start()
    {
        pointsManager = FindObjectOfType<PointsManager>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (pointsManager != null)
        {
            int currentPoints = pointsManager.GetPoints();
            int currentLevel = levelManager.GetLevels();

            if (currentLevel == requiredLevel && currentPoints >= requiredPoints)
            {
                Vector3 adjustedSpawnPosition = spawnPoint.position + spawnPoint.forward * 8f;
                GameObject newExtendConveyor = Instantiate(TruckPrefab, adjustedSpawnPosition, spawnPoint.rotation);
                GameObject newExit = Instantiate(ExitPrefab, exitSpawnPoint.position, exitSpawnPoint.rotation);
                pointsManager.SubtractPoints(requiredPoints);
                Destroy(gameObject);
            } 
            else
            {
                if (currentLevel < requiredLevel && currentPoints < requiredPoints)
                {
                    int neededPoints = requiredPoints - currentPoints;
                    Debug.Log("Musisz osi�gn�� level 14 oraz ma za ma�o punkt�w. Potrzebujesz jeszcze " + neededPoints + ", aby kupi� obiekt");
                } else if (currentLevel < requiredLevel && currentPoints >= requiredPoints)
                {
                    Debug.Log("Musisz osi�gn�� level " + requiredLevel + ", aby kupi� obiekt");
                }                
                else
                {
                    int neededPoints = requiredPoints - currentPoints;
                    Debug.Log("Potrzebujesz jeszcze " + neededPoints + ", aby kupi� obiekt");
                }
                
            }
        }
    }
}
