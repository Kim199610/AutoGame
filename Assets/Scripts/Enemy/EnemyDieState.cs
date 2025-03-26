using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieState : EnemyBaseState
{
    public EnemyDieState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        enemy._animator.SetTrigger("Die");

    }
}
