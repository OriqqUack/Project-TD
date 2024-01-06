using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public abstract class OriginTower : TowerController
{

    protected Transform _firePoint;
    protected GameObject _bullet;

    void init()
    {
       
    }

    protected override void TowerAttackType(GameObject tartget)
    {
        
    }

    protected override void Awake()
    {
        base.Awake();
    }
}
