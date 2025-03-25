using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public bool isAttacking;
    public PlayerAttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(player.AnimationData.AttackParameterHash);
    }

    public override void Update()
    {
        base.Update();
        if (!IsInAttackRange() && !isAttacking)
        {
            playerStateMachine.ChangeState(playerStateMachine.MoveState);
        }
        else if (CanAttack())
        {
            StartAnimation(player.AnimationData.AttackParameterHash);
            isAttacking = true;
        }



    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Rotate(isAttacking);
    }
    
    bool CanAttack()
    {
        return (Vector3.Angle(targetDirection, player.transform.forward) <= 5f);
    }
    bool IsInAttackRange()
    {
        return (player.target.transform.position - player.transform.position).sqrMagnitude <= ((player.statHandler.AttackRange + 0.1f) * (player.statHandler.AttackRange + 0.1f));
    }
}
