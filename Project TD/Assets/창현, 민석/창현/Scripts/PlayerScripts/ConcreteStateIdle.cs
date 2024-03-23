using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteStateIdle : State
{
    public override void DoAction(Define.State state)
    {
        StartCoroutine("MovingCheck");
    }

    IEnumerator MovingCheck()
    {
        while (true)
        {
            float _hAxis = Input.GetAxisRaw("Horizontal");
            float _vAxis = Input.GetAxisRaw("Vertical");

            bool _isMoving = MovingCheck(_hAxis, _vAxis);
            if (_isMoving)
                break;
            yield return null;
        }

        GetComponent<MyAction>().SetActionType(Define.State.Moving);
    }

    
}

