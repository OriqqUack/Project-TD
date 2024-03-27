using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummoningAbility
{

    public void SummonMonster(GameObject summonerMonster) // 소환수의 정보를 매개변수로 지정
    {
                                 
        if (summonerMonster != null)
        {
            Transform spawnPoint = summonerMonster.transform; // 위치와 방향을 spawnPoint에 저장
            GameObject summonedMonster = Managers.Game.MonsterSpawn(Define.Monsters.Unknown, "ChestMonsterPBRDefault", spawnPoint);

        }
        else
        {
            Debug.LogWarning("Summon Prefab is not assigned!");
        }
    }

}
