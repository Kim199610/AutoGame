using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Animator _animator;
    EnemyStatHandler enemyStatHandler;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        enemyStatHandler = GetComponentInChildren<EnemyStatHandler>();
        enemyStatHandler.AddOnDieAction(OnDie);
    }
    void OnDie()
    {
        _animator.SetTrigger("Die");
        EnemyManager.instance.EnemyDie(this);
        Invoke("Die", 5f);
    }
    void Die()
    {
        gameObject.SetActive(false);
    }
}
