using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Animator _animator;
    public CharacterController Controller;
    public EnemyStatHandler enemyStatHandler;
    public EnemyStateMachine enemyStateMachine;
    public Player player;
    [field: SerializeField] public AnimationData AnimationData { get; private set; }

    private void Awake()
    {
        AnimationData.Initialize();

        
        _animator = GetComponentInChildren<Animator>();
        Controller = GetComponent<CharacterController>();
        enemyStatHandler = GetComponent<EnemyStatHandler>();
        enemyStateMachine = new EnemyStateMachine(this);
        enemyStatHandler.AddOnDieAction(OnDie);
    }
    private void Start()
    {
        enemyStateMachine.ChangeState(enemyStateMachine.IdleState);
        player = GameManager.Instance.player;
    }
    void OnDie()
    {
        Controller.enabled = false;
        EnemyManager.instance.EnemyDie(this);
        Invoke("Die", 5f);
    }
    void Die()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        enemyStateMachine.HandleInput();
        enemyStateMachine.Update();
    }
    private void FixedUpdate()
    {
        enemyStateMachine.PhysicsUpdate();
    }
    public void Damage()
    {
        player.statHandler.Damage(enemyStatHandler.Attack);
    }
}
