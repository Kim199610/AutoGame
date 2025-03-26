using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState : PlayerBaseState
{
    public PlayerDieState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player._animator.SetTrigger(player.AnimationData.DieParameterHash);
    }
}
