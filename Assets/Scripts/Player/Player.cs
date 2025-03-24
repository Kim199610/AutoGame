using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerStateMachine playerStateMachine;
    public Animator Animator { get; private set; }
    public CharacterController Controller {  get; private set; }
    [field: SerializeField] public AnimationData AnimationData { get; private set; }
    private void Awake()
    {
        playerStateMachine = new PlayerStateMachine(this);
        Animator = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        playerStateMachine.ChangeState(playerStateMachine.IdleState);
    }
}
