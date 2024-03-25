using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDead : MonoBehaviour, IDead
{
    [SerializeField]
    MonsterStat _stat;

    public void OnDead(Stat attacker)
    {
        Managers.Game.MonsterDespawn(gameObject);
        Debug.Log("Monster Dead");
    }
}
