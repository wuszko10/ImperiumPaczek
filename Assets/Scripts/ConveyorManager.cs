using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorManager : MonoBehaviour
{
    private int basicConveyorCount = 0;
    private int upgradedConveyorCount = 0;
    private int maxConveyors = 6;

    public bool CanCreateConveyor()
    {
        return basicConveyorCount < maxConveyors;
    }

    public bool CanUpgradeConveyor()
    {
        return upgradedConveyorCount < maxConveyors;
    }

    public void IncreaseBasicConveyorCount()
    {
        basicConveyorCount++;
    }

    public int GetBasicConveyorCount()
    {
        return basicConveyorCount;
    }

    public void IncreaseUpgradedConveyorCount()
    {
        upgradedConveyorCount++;
    }

    public int GetUpgradedConveyorCount()
    {
        return upgradedConveyorCount;
    }
}
