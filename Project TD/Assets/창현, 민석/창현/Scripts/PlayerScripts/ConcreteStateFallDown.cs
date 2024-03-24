using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteStateFallDown : State
{
    int coolTime = 2;
    public override void DoAction(Define.State state)
    {
        CoroutineRunningCheck();
        _coroutine = StartCoroutine(FallDown());
    }

    IEnumerator FallDown()
    {
        _rb.velocity = Vector3.zero;

        yield return new WaitForSeconds(coolTime);
        GetComponent<MyAction>().SetActionType(Define.State.Idle);
    }
}
