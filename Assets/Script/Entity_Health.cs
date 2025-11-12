using System;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Entity_Health : MonoBehaviour
{
    [SerializeField] protected float MaxHp = 100;
    [SerializeField] protected bool IsDead;

    public virtual void TakeDamage(float damage, Transform damageDealer)
    {
        if(IsDead) return;
        ReduceHP(damage);
    }

    private void ReduceHP(float damage)
    {
        MaxHp -= damage;
        if(MaxHp < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        IsDead = true;
    }
}
