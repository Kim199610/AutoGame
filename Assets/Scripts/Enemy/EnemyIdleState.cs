using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public EnemyIdleState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        StartAnimation(enemy.AnimationData.IdleParameterHash);
    }
    public override void Exit()
    {
        base.Exit();
        StopAnimation(enemy.AnimationData.IdleParameterHash);
    }
    public override void Update()
    {
        base.Update();
        if ((player.transform.position - enemy.transform.position).sqrMagnitude <= enemy.enemyStatHandler.DetectingRange * enemy.enemyStatHandler.DetectingRange && !player.isDie)
        {
            enemyStateMachine.ChangeState(enemyStateMachine.MoveState);
        }
    }
}
