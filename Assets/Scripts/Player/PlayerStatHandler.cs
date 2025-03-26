using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatHandler : BaseStatHandler
{
    public override int Attack
    {
        get { return attack; }
        set 
        { 
            attack = value; 
            statUI.UpdateAttack(attack);
        }
    }
    public override float AttackSpeed
    {
        get { return attackSpeed; }
        set
        {
            attackSpeed = value;
            statUI.UpdateAttackSpeed(attackSpeed);
        }
    }
    public override float MoveSpeed
    {
        get { return moveSpeed; }
        set
        {
            moveSpeed = value;
            statUI.UpdateSpeed(moveSpeed);
        }
    }
    public override int MaxHP
    {
        get { return maxHP; }
        set
        {
            maxHP = value;
            statUI.UpdateMaxHP(maxHP);
        }
    }
    protected override void Awake()
    {
        base.Awake();
        statUI = UIManager.Instance.statUI;
    }
    protected override void Start()
    {
        base.Start();
        statUI.UpdateAttack(attack);
        statUI.UpdateAttackSpeed(attackSpeed);
        statUI.UpdateSpeed(moveSpeed);
        statUI.UpdateMaxHP(maxHP);
    }
    [SerializeField] StatUI statUI;
    public void UpdateAtStart(GameUI gameUI)
    {
        gameUI.UpdateHP(CurHP / ((float)MaxHP));
        gameUI.UpdateLevel(Level);
        gameUI.UpdateExp(((float)Exp) / MaxExp);
    }
    protected override void CurHPChange(int value)
    {
        base.CurHPChange(value);
        GameManager.Instance.gameUI.UpdateHP(CurHP/((float)MaxHP));
    }
    protected override void LevelUp(int value)
    {
        base.LevelUp(value);
        GameManager.Instance.gameUI.UpdateLevel(Level);
    }
    protected override void GainExp(int value)
    {
        base.GainExp(value);
        GameManager.Instance.gameUI.UpdateExp(((float)Exp)/MaxExp);
    }
}
