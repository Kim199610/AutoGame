using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    
    public void Damage()
    {
        enemy.Damage();
    }
}
