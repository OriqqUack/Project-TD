using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}


public class DataManager
{
    public Dictionary<int, Data.Stat> StatDict { get; private set; } = new Dictionary<int, Data.Stat>();
    public Dictionary<string, Data.MonsterStat> MonsterDict { get; private set; } = new Dictionary<string, Data.MonsterStat>();
    public void Init()
    {
        StatDict = LoadJson<Data.StatData, int, Data.Stat>("StatData").MakeDict();
        MonsterDict = LoadJson<Data.MonsterData, string, MonsterStat>("MonsterData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
        Loader data = JsonUtility.FromJson<Loader>(textAsset.text);
        return data;
    }
    //Dictionary<Key, Value> LoadDict<Key, Value>(string path)
    //{
    //    TextAsset fromJsonData = Managers.Resource.Load<TextAsset>($"Data/{path}");
    //    return DictionaryJsonUtility.FromJson<Key, Value>(fromJsonData.text);
    //}
}
