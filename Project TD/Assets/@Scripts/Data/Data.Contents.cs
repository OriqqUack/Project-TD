using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{ 
#region Stat
	[Serializable]
	public class Stat
	{
		public int level;
		public int maxHp;
		public int attack;
		public int totalExp;
	}

	[Serializable]
	public class StatData : ILoader<int, Stat>
	{
		public List<Stat> stats = new List<Stat>();

		public Dictionary<int, Stat> MakeDict()
		{
			Dictionary<int, Stat> dict = new Dictionary<int, Stat>();
			foreach (Stat stat in stats)
				dict.Add(stat.level, stat);
			return dict;
		}
	}
    #endregion

    #region shop
    [Serializable]
    public class JsonItem : RawData
    {
        public string item_name;
        public string item_description;
        public int kind_of_money;
        public int price;
        public int item_type;
    }

    public class JsonWeapon : JsonItem
    {
        public float attack_power;
        public float critical_attack_power;
        public float critical_chance;
        public float speed_of_attack;
        public int item_grade;
        public int weapon_type;
    }


    public class JsonShopWeaponGradePercentage : RawData
    {
        public int grade;
        public string grade_name;
        public float percentage;
    }


    [Serializable]
    public class ShopItemData : ILoader<string, JsonItem>
    {
        public List<JsonItem> stats = new List<JsonItem>();

        public Dictionary<string, JsonItem> MakeDict()
        {
            Dictionary<string, JsonItem> dict = new Dictionary<string, JsonItem>();
            foreach (JsonItem stat in stats)
                dict.Add(stat.raw, stat);
            return dict;
        }
    }

    [Serializable]
    public class ShopWeaponData : ILoader<string, JsonWeapon>
    {
        public List<JsonWeapon> stats = new List<JsonWeapon>();

        public Dictionary<string, JsonWeapon> MakeDict()
        {
            Dictionary<string, JsonWeapon> dict = new Dictionary<string, JsonWeapon>();
            foreach (JsonWeapon stat in stats)
                dict.Add(stat.raw, stat);
            return dict;
        }
    }

    [Serializable]
    public class WeaponPerData : ILoader<string, JsonShopWeaponGradePercentage>
    {
        public List<JsonShopWeaponGradePercentage> stats = new List<JsonShopWeaponGradePercentage>();

        public Dictionary<string, JsonShopWeaponGradePercentage> MakeDict()
        {
            Dictionary<string, JsonShopWeaponGradePercentage> dict = new Dictionary<string, JsonShopWeaponGradePercentage>();
            foreach (JsonShopWeaponGradePercentage stat in stats)
                dict.Add(stat.raw, stat);
            return dict;
        }
    }
    #endregion
}