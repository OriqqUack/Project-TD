using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTest : BaseController
{
    [SerializeField]
    Transform groundCheck;

    private int groundLayer = 1 << (int)Define.Layer.Ground;
    private Rigidbody _rb;
    private PlayerStat _stat;

    public override void Init()
    {
        _rb = GetComponent<Rigidbody>();
    }

    #region StatePattern
    /// <summary>
    /// BaseController에서 상속받은 행동패턴을 자식 클래스에서 구현.
    /// </summary>
    protected override void UpdateDie()
    {
        base.UpdateDie();
    }

    protected override void UpdateIdle()
    {
        MovingCheck();
    }

    protected override void UpdateMoving()
    {
        MovingCheck();
    }

    protected override void UpdateFallDown()
    {
        base.UpdateFallDown();
    }

    protected override void UpdateSkill()
    {
        base.UpdateSkill();
    }

    private void MovingCheck()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");
        Vector3 gravity = Vector3.down * Mathf.Abs(_rb.velocity.y);

        Vector3 dir = new Vector3(hAxis, 0, vAxis);
        if (dir.magnitude < 0.1f || (hAxis == 0 && vAxis == 0))
        {
            _rb.velocity = Vector3.zero;
            State = Define.State.Idle;
        }
        else
        {
            _rb.velocity = dir * _stat.MoveSpeed + gravity;
            State = Define.State.Moving;
        }
    }

    public bool IsGrounded()
    {
        Vector3 boxSize = new Vector3(transform.lossyScale.x, 0.4f, transform.lossyScale.z);
        return Physics.CheckBox(groundCheck.position, boxSize, Quaternion.identity, groundLayer);
    }
    #endregion
}
