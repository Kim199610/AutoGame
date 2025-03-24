using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    
    public PlayerMoveState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        StartAnimation(player.AnimationData.RunParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(player.AnimationData.RunParameterHash);
    }

    public override void Update()
    {
        base.Update();
        if (IsInAttackRange())
        {
            playerStateMachine.ChangeState(playerStateMachine.AttackState);
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
        float moveSpeed = player.moveSpeed;
        player.Controller.Move(targetDirection * moveSpeed * Time.deltaTime);
    }
    

    bool IsInAttackRange()
    {
        return (player.target.transform.position - player.transform.position).sqrMagnitude <= (player.attackRange * player.attackRange);
    }
}
