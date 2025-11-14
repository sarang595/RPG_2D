using System;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Entity_Health : MonoBehaviour
{
    private Entity_Vfx entityVfx;
    private Entity entity;
    [SerializeField] protected float CurrentHp;
    [SerializeField] protected float MaxHp = 100;
    [SerializeField] protected bool IsDead;

    [Header("OnKnock Back Damage")]
    [SerializeField] Vector2 KnockPower;
    [SerializeField] float KnockDuration;
    [SerializeField] Vector2 HeavyKnockPower;
    [SerializeField] float HeavyKnockDuration;
    [SerializeField] float HeavyKnockBackThreshold;

    protected virtual void Awake()
    {
        entityVfx = GetComponent<Entity_Vfx>();
        entity = GetComponent<Entity>();
        CurrentHp = MaxHp;
    }
    public virtual void TakeDamage(float damage, Transform damageDealer)
    {
        if(IsDead) return;
        Vector2 KnockBackVelocity = CalculateKnockBack(damageDealer, damage);
        float KnockBackDuration = ReceiveHeavyKnockBackDuration(damage);
        entity?.ReceiveKnockBack(KnockBackVelocity, KnockBackDuration);
        entityVfx?.PlayVfx();
        ReduceHP(damage);
    }

    private void ReduceHP(float damage)
    {
        CurrentHp -= damage;
        if(CurrentHp <= 0)
        {
            Die();
        }
    }
    private Vector2 CalculateKnockBack(Transform damageDealer, float damage)
    {
        int direction = transform.position.x < damageDealer.position.x? -1 : 1;
        Vector2 Knockback = IsHeavyKnockBack(damage)? HeavyKnockPower : KnockPower;
        Knockback.x = Knockback.x * direction;
        return Knockback;
    }
    private bool IsHeavyKnockBack(float damage) => damage / MaxHp  > HeavyKnockBackThreshold;
    private float ReceiveHeavyKnockBackDuration(float damage) => IsHeavyKnockBack(damage) ? HeavyKnockDuration : KnockDuration;

    private void Die()
    {
        IsDead = true;
        entity.EntityDeath();
    }
}
