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
        StartAnimation(playerStateMachine.Player.AnimationData.RunParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(playerStateMachine.Player.AnimationData.RunParameterHash);
    }

    public override void Update()
    {
        base.Update();

    }


}
