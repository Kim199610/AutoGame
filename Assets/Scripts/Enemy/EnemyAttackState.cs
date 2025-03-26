using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public EnemyAttackState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(enemy.AnimationData.AttackParameterHash);
    }

    public override void Update()
    {
        base.Update();
        if (!IsInAttackRange())
        {
            enemyStateMachine.ChangeState(enemyStateMachine.MoveState);
        }
        else if (CanAttack())
        {
            StartAnimation(player.AnimationData.AttackParameterHash);
        }
        if(player.isDie)
        {
            enemyStateMachine.ChangeState(enemyStateMachine.IdleState);
        }



    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Rotate();
    }

    bool CanAttack()
    {
        return (Vector3.Angle(targetDirection, enemy.transform.forward) <= 5f);
    }
    bool IsInAttackRange()
    {
        return (player.target.transform.position - player.transform.position).sqrMagnitude <= ((player.statHandler.AttackRange + 0.1f) * (player.statHandler.AttackRange + 0.1f));
    }
}
