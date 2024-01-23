using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Inven_Item : UI_Base
{
    float interval = 0.25f;
    float doubleClickedTime = -1.0f;
    bool isDoubleClicked = false;
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

        Get<GameObject>((int)GameObjects.ItemIcon).BindEvent((PointerEventData) => 
        { 
            Debug.Log(_name); 
            OnButtonClicked(); 
        });
    }

    public void SetInfo(Data.JsonWeapon weaponData)
    {
        _name = weaponData.item_name;
        _price = weaponData.price;
    }

    public void OnButtonClicked()
    {
        if ((Time.time - doubleClickedTime) < interval) //더블 클릭
        {
            isDoubleClicked = true;
            doubleClickedTime = -1.0f;

            Debug.Log("double click!");
            Destroy(this.gameObject);
        }
        else
        {
            isDoubleClicked = false;
            doubleClickedTime = Time.time;
        }
    }
}
 