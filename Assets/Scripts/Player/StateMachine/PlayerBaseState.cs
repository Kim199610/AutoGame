using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : MonoBehaviour, IState
{
    protected PlayerStateMachine playerStateMachine;

    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        this.playerStateMachine = playerStateMachine;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void HandleInput()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Update()
    {

    }
    protected void StartAnimation(int animationHash)
    {
        playerStateMachine.Player.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        playerStateMachine.Player.Animator.SetBool(animationHash, false);
    }
}
