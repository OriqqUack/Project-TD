using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}
//public interface ILoader2<Key, Value>
//{
//    Dictionary<Key, Value> MakeMonsterDict();
//}

public class DataManager
{
    public Dictionary<int, Data.Stat> StatDict { get; private set; } = new Dictionary<int, Data.Stat>();
    public Dictionary<string, Data.MonsterStat> MonsterStat { get; private set; } = new Dictionary<string, Data.MonsterStat>();

    public void Init()
    {
        StatDict = LoadJson<Data.StatData, int, Data.Stat>("StatData").MakeDict();
        MonsterStat = LoadJson<Data.MonsterData, string, Data.MonsterStat>("MonsterData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
		TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
        Loader data = JsonUtility.FromJson<Loader>(textAsset.text);
        return JsonUtility.FromJson<Loader>(textAsset.text);
	}
    //Loader LoadJson2<Loader, Key, Value>(string path) where Loader : ILoader2<Key, Value>
    //{
    //    TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
    //    MonsterData data = JsonUtility.FromJson<MonsterData>(textAsset.text);
    //    return JsonUtility.FromJson<Loader>(textAsset.text);
    //}
}
