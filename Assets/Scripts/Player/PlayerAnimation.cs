using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] BoxCollider comboOneHitCollider;
    [SerializeField] CapsuleCollider comboTwoHitCollider;
    [SerializeField] BoxCollider comboThreeHitCollider;
    int damage;

    List<Idamagable> idamagables;
    public void ComboOneAttack()
    {
        idamagables.Clear();
        damage = player.damage;
        comboOneHitCollider.enabled = true;
    }
    public void ComboTwoAttack()
    {
        idamagables.Clear();
        damage = player.damage;
        comboTwoHitCollider.enabled = true;
    }
    public void ComboThreeAttack()
    {
        idamagables.Clear();
        damage = (int)(player.damage * 1.5f);
        comboTwoHitCollider.enabled = true;
    }
    public void DisableCollider()
    {
        comboOneHitCollider.enabled=false;
        comboTwoHitCollider.enabled=false;
        comboThreeHitCollider.enabled=false;
    }
    public void AttackEnd()
    {
        player.playerStateMachine.AttackState.isAttacking = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Idamagable>(out Idamagable damagable) && !idamagables.Contains(damagable))
        {
            idamagables.Add(damagable);
            damagable.Damage(damage);
        }
    }

}
