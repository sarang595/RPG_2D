using System;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Entity_Health : MonoBehaviour
{
    private Entity_Vfx entityVfx;
    private Entity entity;
    [SerializeField] protected float MaxHp = 100;
    [SerializeField] protected bool IsDead;

    [Header("OnKnock Back Damage")]
    [SerializeField] Vector2 KnockPower;
    [SerializeField] float KnockDuration;

    protected virtual void Awake()
    {
        entityVfx = GetComponent<Entity_Vfx>();
        entity = GetComponent<Entity>();
    }
    public virtual void TakeDamage(float damage, Transform damageDealer)
    {
        if(IsDead) return;
        if(entity!=null)
        {
            entity.ReceiveKnockBack(CalculateKnockBack(damageDealer), KnockDuration);
        }
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
    private Vector2 CalculateKnockBack(Transform damageDealer)
    {
        int direction = transform.position.x < damageDealer.position.x? -1 : 1;
        Vector2 Knockback = KnockPower;
        Knockback.x = Knockback.x * direction;
        return Knockback;
    }

    private void Die()
    {
        IsDead = true;
    }
}
