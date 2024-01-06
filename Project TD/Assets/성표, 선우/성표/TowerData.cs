using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "Config/Tower Data", order = 1)]
public class TowerData : ScriptableObject
{
    [SerializeField] private float AttackPower;
    [SerializeField] private float AttackDelay;
    [SerializeField] private float Range;
    [SerializeField] private float HP;



    public float TAttackPower {
        get { return AttackPower;}
        set { if (value >= 0) AttackPower = value;} 
    }
    public float TAttackDelay
    {
        get { return AttackDelay; }
        set { if (value >= 0) AttackDelay = value; }
    }
    public float Trange
    {
        get { return Range; }
        set { if (value >= 0) Range = value; }
    }
    public float THP
    {
        get { return HP; }
        set { if (value >= 0) HP = value; }
    }
}
