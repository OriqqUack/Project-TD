using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class Monster
{
    public int level;
    public int maxHp;
    public int attack;
    public float moveSpeed;
    public float attackSpeed;
    public float scanRange;
    public float attackRange;
}

[Serializable]
public class MonsterList
{
    public Dictionary<string, Monster> monsters;
}

public class MonsterJson : MonoBehaviour
{
    void Start()
    {
        Dictionary<string, Monster> monsterDic = new Dictionary<string, Monster>();

        //Monster slime = new Monster();
        //slime.level =;
        //slime.maxHp = 100;
        //slime.attack = 100;
        //slime.moveSpeed = 100;
        //slime.attackSpeed = 100;
        //slime.scanRange = 100;
        //slime.attackRange = 100;

        //Monster ork = new Monster();
        //ork.level = "Magic";
        //ork.maxHp = 30;
        //ork.attack = 30;
        //ork.moveSpeed = 30;
        //ork.attackSpeed = 30;
        //ork.scanRange = 30;
        //ork.attackRange = 30;

        //monsterDic["Sizard"] = slime;
        //monsterDic["Ork"] = ork;

        //MonsterList Monster = new MonsterList();
        //Monster.monsters = monsterDic;

        #region ToJson
        ////ToJson 부분
        //string jsonData = DictionaryJsonUtility.ToJson(monsterDic, true);

        //string path = Application.dataPath + "/Data";
        //if (!Directory.Exists(path))
        //{
        //    Directory.CreateDirectory(path);
        //}
        //File.WriteAllText(path + "/MonsterDataEx.json", jsonData);
        #endregion

        //FromJson 부분
        // Json 파일에서 데이터를 읽어옴
        //string fromJsonData = File.ReadAllText(path + "/MonsterData.json");

        //// MonsterList 클래스의 객체를 생성
        //MonsterList MonsterFromJson = new MonsterList();
        //// Json 데이터를 딕셔너리로 역직렬화하여 MonsterList의 monsters 필드에 저장
        //MonsterFromJson.monsters = DictionaryJsonUtility.FromJson<string, Monster>(fromJsonData);
        //// 역직렬화된 딕셔너리를 출력
        //print(MonsterFromJson.monsters);
    }
}
