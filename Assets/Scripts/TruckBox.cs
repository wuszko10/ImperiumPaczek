using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckBox : MonoBehaviour
{

    public GameObject TruckPrefab;
    public Transform spawnPoint;
    public int requiredPoints;
    public int requiredLevel;

    private PointsManager pointsManager;
    private LevelManager levelManager;
    private ToggleVisibility toggleVisibility;

    void Start()
    {
        pointsManager = FindObjectOfType<PointsManager>();
        levelManager = FindObjectOfType<LevelManager>();
        toggleVisibility = FindObjectOfType<ToggleVisibility>();
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
                pointsManager.SubtractPoints(requiredPoints);
                Destroy(gameObject);
            } 
            else
            {
                if (currentLevel < requiredLevel && currentPoints < requiredPoints)
                {
                    int neededPoints = requiredPoints - currentPoints;
                    toggleVisibility.ShowObject("Musisz osi�gn�� level 14 oraz masz za ma�o punkt�w. Potrzebujesz jeszcze " + neededPoints + ", aby kupi� obiekt");
                } else if (currentLevel < requiredLevel && currentPoints >= requiredPoints)
                {
                    toggleVisibility.ShowObject("Musisz osi�gn�� level " + requiredLevel + ", aby kupi� obiekt");
                }                
                else
                {
                    int neededPoints = requiredPoints - currentPoints;
                    toggleVisibility.ShowObject("Potrzebujesz jeszcze " + neededPoints + ", aby kupi� obiekt");
                }
                
            }
        }
    }
}
