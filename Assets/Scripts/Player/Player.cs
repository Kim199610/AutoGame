using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerStateMachine playerStateMachine;
    private void Awake()
    {
        playerStateMachine = new PlayerStateMachine(this);
    }
}
