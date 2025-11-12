using System;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Entity_Health : MonoBehaviour
{
    private Entity_Vfx entityVfx;
    [SerializeField] protected float MaxHp = 100;
    [SerializeField] protected bool IsDead;

    protected virtual void Awake()
    {
        entityVfx = GetComponent<Entity_Vfx>();
    }
    public virtual void TakeDamage(float damage, Transform damageDealer)
    {
        if(IsDead) return;
        if (entityVfx!=null)
        {
            entityVfx.PlayVfx(); 
        }
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
