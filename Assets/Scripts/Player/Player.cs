using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine playerStateMachine;
    public Animator Animator { get; private set; }
    public CharacterController Controller {  get; private set; }
    [field: SerializeField] public AnimationData AnimationData { get; private set; }
    public Enemy target;


    public float moveSpeed;
    public float rotateSpeed;
    public float attackRange;
    public int damage;

    private void Awake()
    {
        AnimationData.Initialize();

        playerStateMachine = new PlayerStateMachine(this);
        Controller = GetComponent<CharacterController>();
        Animator = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        //playerStateMachine.ChangeState(playerStateMachine.IdleState);
        playerStateMachine.ChangeState(playerStateMachine.MoveState);
    }
    private void Update()
    {
        SetTarget();
        playerStateMachine.HandleInput();
        playerStateMachine.Update();
    }
    private void FixedUpdate()
    {
        playerStateMachine.PhysicsUpdate();
    }

    void SetTarget()
    {
        List<List<Enemy>> enemys = EnemyManager.instance.enemys;
        for (int i = 0;i<enemys.Count; i++)
        {
            if(enemys[i].Count > 0)
            {
                for(int j = 0; j < enemys[i].Count; j++)
                {
                    if(target == null)
                    {
                        target = enemys[i][j];
                    }
                    else if((target.transform.position - transform.position).sqrMagnitude > (enemys[i][j].transform.position - transform.position).sqrMagnitude)
                    {
                        target = enemys[i][j];
                    }
                }
                return;
            }
        }
    }
}
