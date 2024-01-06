using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using static PrefabsPath;

public abstract class  TowerController : MonoBehaviour, TowerInterface
{
    public TowerData towerData;
    public PrefabsPath prefabPaths;

    private HashSet<Monster> monstersInRange = new HashSet<Monster>();
    private Monster target;
    private float _attackTimer = 0f;

    protected float TAttack;
    protected float TAttackDelay;
    protected float TRange;
    protected float THP;

    protected abstract void TowerAttackType(GameObject tartget);

    protected void TowerAttack()
    {
        _attackTimer -= Time.deltaTime;
        if (_attackTimer <= 0f)
        {
            target = GetClosestMonster();
            if (target != null)
            {
                TowerAttackType(target.gameObject);
                _attackTimer = TAttackDelay;
            }
        }
    }

    //타워 스텟 데이터 테이블에서 가져오기
    protected virtual void Awake()
    {
        TAttack = towerData.TAttackPower;
        TAttackDelay = towerData.TAttackDelay;
        TRange = towerData.Trange;
        THP = towerData.THP;
    }

    public void OnMonsterEnter(Monster monster)
    {
        monstersInRange.Add(monster);
    }

    public void OnMonsterExit(Monster monster)
    {
        monstersInRange.Remove(monster);
        if (monster == target) target = null;
    }

    protected Monster GetClosestMonster()
    {
        Monster closestMonster = null;
        float closestDistance = float.MaxValue;

        foreach (Monster monster in monstersInRange)
        {
            float distance = (monster.transform.position - transform.position).sqrMagnitude;
            if (distance < closestDistance)
            {
                closestMonster = monster;
                closestDistance = distance;
            }
        }
        return closestMonster;
    }


    //오브젝트사이에 거리 구하는 함수
    public float GetDir(GameObject OB1, GameObject OB2)
    {
        float dir = Vector3.Distance(OB1.transform.position, OB2.transform.position);
        return dir;
    } 

    //***************************프리팹매니저***************************//
    //프리팹 경로 가져오기
    protected virtual string GetTowerPrefabPath(string prefabName)
    {
        return GetPrefabPath(prefabName, prefabPaths.towerPrefabs);
    }
    protected virtual string GetBulletPrefabPath(string prefabName)
    {
        return GetPrefabPath(prefabName, prefabPaths.bulletPrefab);
    }
    protected virtual string GetMonsterPrefabPath(string prefabName)
    {
        return GetPrefabPath(prefabName, prefabPaths.monsterPrefab);
    }

    //가져올 프리팹 경로 검사
    protected virtual string GetPrefabPath(string prefabName, PrefabPath[] prefabList)
    {
        var prefab = prefabList.FirstOrDefault(x => x.name == prefabName);
        if (prefab.Equals(default(PrefabPath)))
        {
            Debug.LogError("Cannot find matching prefab for " + prefabName);
            return null;
        }

        var prefabPath = prefab.prefabspath;
        if (string.IsNullOrWhiteSpace(prefabPath))
        {
            Debug.LogError("Cannot find matching prefab path for " + prefabName);
            return null;
        }

        return prefabPath;
    }


}
