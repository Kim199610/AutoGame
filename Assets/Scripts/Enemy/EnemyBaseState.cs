using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : IState
{
    protected Enemy enemy;
    protected EnemyStateMachine enemyStateMachine;
    protected Vector3 targetDirection;
    protected Player player;

    public EnemyBaseState(EnemyStateMachine enemyStateMachine)
    {
        this.enemyStateMachine = enemyStateMachine;
        enemy = enemyStateMachine.Enemy;
        player = EnemyManager.instance.player;
        enemy.enemyStatHandler.AddOnDieAction(Die);
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
        enemy._animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        enemy._animator.SetBool(animationHash, false);
    }
    protected void SetTargetDirection()
    {
        targetDirection = (player.transform.position - enemy.transform.position);
        targetDirection = new Vector3(targetDirection.x, 0, targetDirection.z).normalized;
    }
    protected virtual void Rotate(bool isAttacking = false)
    {
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            enemy.transform.rotation = Quaternion.RotateTowards(enemy.transform.rotation, targetRotation, (isAttacking ? 0.3f : 1f) * player.statHandler.rotateSpeed * Time.deltaTime);
        }
    }
    protected void Die()
    {
        enemyStateMachine.ChangeState(enemyStateMachine.DieState);
    }
}
