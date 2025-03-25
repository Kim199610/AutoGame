using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStatHandler : MonoBehaviour,Idamagable
{
    [SerializeField]protected StatData _data;
    public virtual int Attack {  get; private set; }
    public virtual float AttackSpeed { get; private set; }
    public virtual float AttackRange { get; private set; }
    public virtual float MoveSpeed {  get; private set; }
    public int MaxHP {  get; private set; }
    protected int curHP;

    public Action onDie;
    
    public virtual int CurHP
    {
        get { return curHP; }
        set
        {
            if (curHP == 0) return;
            curHP = Mathf.Clamp(value, 0, MaxHP);
            if (curHP == 0)
            {
                onDie();
            }
        }
    }
    protected int level;
    public virtual int Level
    {
        get {  return level; }
        set
        {
            Attack += attackPerLevel * (value - level);
            MaxHP += maxHPPerLevel * (value - level);
            MaxExp += maxExpPerLevel * (value - level);

            level = value;
        }
    }
    protected int exp;
    public virtual int Exp
    {
        get { return exp; }
        set
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
    }
    protected int expGive;
    protected int goldGive;
    public virtual int MaxExp { get; private set; }


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
        Debug.Log($"{gameObject}¿¡ {damage}µ¥¹ÌÁö ³²ÀºÃ¼·Â{CurHP}");
    }
    public virtual void AddOnDieAction(Action action)
    {
        onDie += action;
    }

    void GiveReward()
    {
        GameManager.Instance.player.statHandler.Exp += expGive;
        GameManager.Instance.gold += goldGive;
        Debug.Log($"{expGive}°æÇèÄ¡È¹µæ {goldGive}°ñµåÈ¹µæ");
    }
}
