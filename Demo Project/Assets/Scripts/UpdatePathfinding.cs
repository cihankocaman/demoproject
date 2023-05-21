using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePathfinding : SingletonCreator<UpdatePathfinding>
{
    private void OnEnable()
    {
        Placement.UpdatePathfinder += SetPathfinding;
        BuildingBase.UpdatePathfinder += SetPathfinding;
    }
    private void OnDisable()
    {
        Placement.UpdatePathfinder -= SetPathfinding;
        BuildingBase.UpdatePathfinder -= SetPathfinding;
    }
    void SetPathfinding()
    {
        AstarPath.active.Scan();
    }
}
