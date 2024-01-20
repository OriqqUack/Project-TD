using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inven_Item : UI_Base
{
    enum GameObjects
    {
        ItemIcon,
        ItemNameText,
    }

    string _name;
    int _price;

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<Text>().text = _name;

        Get<GameObject>((int)GameObjects.ItemIcon).BindEvent((PointerEventData) => { Managers.Game.SpendGold(_price); });
    }

    public void SetInfo(Data.JsonWeapon weaponData)
    {
        _name = weaponData.item_name;
        _price = weaponData.price;
    }
}
 