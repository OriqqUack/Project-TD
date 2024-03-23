using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager   // 상태 체크
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;
    public Action<Define.State> Key = null;

    bool _pressed = false;
    float _pressedTime = 0;

    public void OnUpdate()
    {
        
    }

    public void Clear()
    {
        KeyAction = null;
        MouseAction = null;
        Key = null;
    }
}
