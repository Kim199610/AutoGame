using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : IState
{
    protected Player player;
    protected PlayerStateMachine playerStateMachine;
    protected Vector3 targetDirection;

    
    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        this.playerStateMachine = playerStateMachine;
        player = playerStateMachine.Player;
        player.statHandler.AddOnDieAction(Die);
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
        SetTargetDirection();
    }
    protected void StartAnimation(int animationHash)
    {
        player._animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        player._animator.SetBool(animationHash, false);
    }
    protected void SetTargetDirection()
    {
        targetDirection = (player.target.transform.position - player.transform.position);
        targetDirection = new Vector3(targetDirection.x,0,targetDirection.z).normalized;
    }
    protected virtual void Rotate(bool isAttacking = false)
    {
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, targetRotation, (isAttacking? 0.3f : 1f) * player.statHandler.rotateSpeed * Time.deltaTime);
        }
    }
    protected void Die()
    {
        playerStateMachine.ChangeState(playerStateMachine.DieState);
    }
}
