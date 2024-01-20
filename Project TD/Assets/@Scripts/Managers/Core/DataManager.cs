using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    public Dictionary<int, Data.Stat> StatDict { get; private set; } = new Dictionary<int, Data.Stat>();
    public Dictionary<string, Data.JsonItem> ShopItemData { get; private set; } = new Dictionary<string, Data.JsonItem>();
    public Dictionary<string, Data.JsonWeapon> ShopWeaponData { get; private set; } = new Dictionary<string, Data.JsonWeapon>();
    public Dictionary<string, Data.JsonShopWeaponGradePercentage> ShopWeaponPer { get; private set; } = new Dictionary<string, Data.JsonShopWeaponGradePercentage>();


    public void Init()
    {
        StatDict = LoadJson<Data.StatData, int, Data.Stat>("StatData").MakeDict();
        ShopItemData = LoadJson<Data.ShopItemData, string, Data.JsonItem>("item_weapon").MakeDict();
        ShopWeaponData = LoadJson<Data.ShopWeaponData, string, Data.JsonWeapon>("item_weapon").MakeDict();
        ShopWeaponPer = LoadJson<Data.WeaponPerData, string, Data.JsonShopWeaponGradePercentage>("shop_weapon_grade_percentage").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
		TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
	}
}
