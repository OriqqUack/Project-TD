using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummoningAbility : MonoBehaviour
{
    public GameObject summonerMonster;

    public void SummonMonster(Vector3 position, Quaternion rotation)
    {
        if (summonerMonster != null)
        {
            position = summonerMonster.transform.position;
            rotation = summonerMonster.transform.rotation;
            GameObject summonedMonster = Managers.Game.MonsterSpawn(Define.Monsters.Unknown, "ChestMonsterPBRDefault", s);

        }
        else
        {
            Debug.LogWarning("Summon Prefab is not assigned!");
        }
    }

}
