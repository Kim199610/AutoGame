using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class AnimationData 
{
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string runParameterName = "Run";
    [SerializeField] private string attackParameterName = "Attack";
    [SerializeField] private string skill1ParameterName = "Skill1";
    [SerializeField] private string skill2ParameterName = "Skill2";

    public int IdleParameterHash { get; private set; }
    public int RunParameterHash { get; private set; }
    public int AttackParameterHash { get; private set; }
    public int Skill1ParameterHash { get; private set; }
    public int Skill2ParameterHash { get; private set; }
    public void Initialize()
    {
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        RunParameterHash = Animator.StringToHash(runParameterName);
        AttackParameterHash = Animator.StringToHash(attackParameterName);
        Skill1ParameterHash = Animator.StringToHash(skill1ParameterName);
        Skill2ParameterHash = Animator.StringToHash(skill2ParameterName);
    }
}
