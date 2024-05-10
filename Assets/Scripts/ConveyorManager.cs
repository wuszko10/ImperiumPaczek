using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorManager : MonoBehaviour
{
    private int basicConveyorCount = 0;
    private int maxConveyors = 6;

    public bool CanCreateConveyor()
    {
        return basicConveyorCount < maxConveyors;
    }

    public void IncreaseBasicConveyorCount()
    {
        basicConveyorCount++;
    }
}
