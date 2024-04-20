using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineInteraction : MonoBehaviour
{

    public GameObject upgradedBox;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BoxWooden"))
        {
            Destroy(other.gameObject);

            if(spawnPoint != null)
            {
                Instantiate(upgradedBox, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}
