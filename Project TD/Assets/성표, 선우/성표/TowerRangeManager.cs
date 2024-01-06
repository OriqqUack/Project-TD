using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRangeManager : MonoBehaviour
{
    public TowerInterface tower;

    void OnTriggerEnter(Collider other)
    {
        Monster monster = other.gameObject.GetComponent<Monster>();
        if (monster != null) tower.OnMonsterEnter(monster);
    }

    private void OnTriggerExit(Collider other)
    {
        Monster monster = other.gameObject.GetComponent<Monster>();
        if (monster != null) tower.OnMonsterExit(monster);
    }
}
