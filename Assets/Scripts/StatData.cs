using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Stat", menuName = "Characters/Stat")]
public class StatData : ScriptableObject
{
    public int attack;
    public float attackRange;
    public float attackSpeed;
    public float moveSpeed;
    public int maxHP;
    public int expGive;
    public int goldGive;
}
