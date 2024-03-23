using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteStateMove : State
{
    public override void DoAction(Define.State state)
    {
        StartCoroutine("Move");
    }

    IEnumerator Move()
    {
        while (true)
        {
            float _hAxis = Input.GetAxisRaw("Horizontal");
            float _vAxis = Input.GetAxisRaw("Vertical");
            Vector3 dir = new Vector3(_hAxis, 0, _vAxis);

            _rb.velocity = dir * _stat.MoveSpeed;

            bool _isMoving = MovingCheck(_hAxis, _vAxis);
            if (!_isMoving)
                break;
            yield return null;
        }


        GetComponent<MyAction>().SetActionType(Define.State.Idle);
    }
}
