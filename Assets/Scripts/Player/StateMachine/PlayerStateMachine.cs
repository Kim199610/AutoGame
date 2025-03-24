using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }
    public Transform MainCameraTransform { get; set; }
    public PlayerIdleState IdleState { get; set; }
    public PlayerGoNextState GoNextState { get; set; }
    public PlayerSearchState SearchState { get; set; }
    public PlayerAttackState AttackState { get; set; }

    public PlayerStateMachine(Player player)
    {
        this.Player = player;

        MainCameraTransform = Camera.main.transform;


    }
}
