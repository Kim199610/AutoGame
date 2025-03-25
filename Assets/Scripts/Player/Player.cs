using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine playerStateMachine;
    public Animator _animator;
    public CharacterController Controller {  get; private set; }
    [field: SerializeField] public AnimationData AnimationData { get; private set; }
    public Enemy target;
    public PlayerStatHandler statHandler;

    public bool isDie = false;
    private void Awake()
    {
        AnimationData.Initialize();
        Controller = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
        statHandler = GetComponent<PlayerStatHandler>();
        playerStateMachine = new PlayerStateMachine(this);
        statHandler.AddOnDieAction(OnDie);
        
    }
    private void Start()
    {
        GameManager.Instance.player = this;
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
                    if(target == null || !enemys[i].Contains(target))
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
    void OnDie()
    {
        isDie = true;
        Controller.enabled = false;
        Invoke("Die", 5f);
    }
    void Die()
    {
        gameObject.SetActive(false);
    }
}
