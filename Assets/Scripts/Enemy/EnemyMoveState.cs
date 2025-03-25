using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyBaseState
{
    public EnemyMoveState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        StartAnimation(enemy.AnimationData.RunParameterHash);
    }
    public override void Exit()
    {
        base.Exit();
        StopAnimation(enemy.AnimationData.RunParameterHash);
    }

    public override void Update()
    {
        base.Update();
        if (IsInAttackRange())
        {
            enemyStateMachine.ChangeState(enemyStateMachine.AttackState);
            return;
        }
    }
    public override void PhysicsUpdate()
    {
        move();
        Rotate();
    }

    void move()
    {
        float moveSpeed = enemy.enemyStatHandler.MoveSpeed;
        enemy.Controller.Move(targetDirection * moveSpeed * Time.deltaTime);
    }


    bool IsInAttackRange()
    {
        return (player.transform.position - enemy.transform.position).sqrMagnitude <= (enemy.enemyStatHandler.AttackRange * enemy.enemyStatHandler.AttackRange);
    }
}
