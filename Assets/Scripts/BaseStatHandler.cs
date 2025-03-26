using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStatHandler : MonoBehaviour,Idamagable
{
    [SerializeField]protected StatData _data;
    protected int attack;
    public virtual int Attack
    {
        get { return attack; }
        set { attack = value; }
    }
    protected float attackSpeed;
    public virtual float AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = value; }
    }
    public virtual float AttackRange { get; private set; }
    protected float moveSpeed;
    public virtual float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }
    protected int maxHP;
    public virtual int MaxHP
    {
        get { return maxHP; }
        set { maxHP = value; }
    }
    protected int curHP;
    public virtual int CurHP
    {
        get { return curHP; }
        set
        {
            CurHPChange(value);
        }
    }
    protected int level = 1;
    public virtual int Level
    {
        get {  return level; }
        set
        {
            LevelUp(value);
        }
    }
    protected int exp;
    public virtual int Exp
    {
        get { return exp; }
        set
        {
            GainExp(value);
        }
    }
    protected int expGive;
    protected int goldGive;
    public virtual int MaxExp { get; private set; }

    public Action onDie;

    [SerializeField] protected int attackPerLevel;
    [SerializeField] protected int maxHPPerLevel;
    [SerializeField] protected int maxExpPerLevel;
    public float rotateSpeed = 180f;

    protected virtual void Awake()
    {
        Attack = _data.attack;
        AttackSpeed = _data.attackSpeed;
        AttackRange = _data.attackRange;
        MoveSpeed = _data.moveSpeed;
        MaxHP = _data.maxHP;
        expGive = _data.expGive;
        goldGive = _data.goldGive;

        AddOnDieAction(GiveReward);
    }
    protected virtual void Start()
    {
        curHP = MaxHP;
    }
    public virtual void ChangeHP(int value)
    {
        CurHP += value;
    }
    public virtual void Damage(int damage)
    {
        
        ChangeHP(-damage);
        Debug.Log($"{gameObject}ø° {damage}µ•πÃ¡ˆ ≥≤¿∫√º∑¬{CurHP}");
    }
    public virtual void AddOnDieAction(Action action)
    {
        onDie += action;
    }
    protected virtual void LevelUp(int value)
    {
        Attack += attackPerLevel * (value - level);
        MaxHP += maxHPPerLevel * (value - level);
        MaxExp += maxExpPerLevel * (value - level);

        level = value;
    }
    protected virtual void GainExp(int value)
    {
        if (value >= MaxExp)
        {
            value = value - MaxExp;
            Level++;
            Exp = value;
        }
        else
        {
            exp = value;
        }
    }
    protected virtual void CurHPChange(int value)
    {
        if (curHP == 0) return;
        curHP = Mathf.Clamp(value, 0, MaxHP);
        if (curHP == 0)
        {
            onDie();
        }
    }
    void GiveReward()
    {
        GameManager.Instance.player.statHandler.Exp += expGive;
        GameManager.Instance.Gold += goldGive;
        Debug.Log($"{expGive}∞Ê«Ëƒ°»πµÊ {goldGive}∞ÒµÂ»πµÊ");
    }
}
