using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public interface TowerInterface
{
    public void OnMonsterEnter(Monster monster);
    public void OnMonsterExit(Monster monster);
}
