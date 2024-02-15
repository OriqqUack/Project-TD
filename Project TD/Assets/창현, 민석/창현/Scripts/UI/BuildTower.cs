using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BuildTower : SelectionManager
{
    public void OnClickEvent() 
    {
        GameObject currentTower = Managers.Game._currentTower;
        Vector3 groundPosition = currentTower.transform.position + new Vector3(0,10,0);
        Quaternion quaternion = Quaternion.identity;

        Managers.Resource.Instantiate("Tower", groundPosition, quaternion);
    }
}
