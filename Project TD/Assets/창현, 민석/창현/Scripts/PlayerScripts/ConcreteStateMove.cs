using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteStateMove : State
{
    float InputX;
    float InputZ;

    float fallDownPer = 0.001f;
    public override void DoAction(Define.State state)
    {
        CoroutineRunningCheck();
        _coroutine = StartCoroutine("Move");
    }

    IEnumerator Move()
    {
        while (true)
        {
            InputX = Input.GetAxisRaw("Horizontal");
            InputZ = Input.GetAxisRaw("Vertical");
            Vector3 dir = new Vector3(InputX, 0, InputZ);

            //넘어지기 체크
            if (IsFallDown())
            {
                _rb.velocity = Vector3.zero;
                yield return new WaitForSeconds(0.1f);
                GetComponent<MyAction>().SetActionType(Define.State.FallDown);
                break;
            }

            bool _isMoving = MovingCheck(InputX, InputZ);
            if (!_isMoving)
            {
                _rb.velocity = Vector3.zero;
                GetComponent<MyAction>().SetActionType(Define.State.Idle);
                break;
            }

            _rb.velocity = dir * _stat.MoveSpeed;
            yield return null;
        }
        
    }

    private bool IsFallDown()
    {
        float randomNumber = Random.value;
        Debug.Log(randomNumber);
        if (randomNumber < fallDownPer)
            return true;
        return false;
    }
}
