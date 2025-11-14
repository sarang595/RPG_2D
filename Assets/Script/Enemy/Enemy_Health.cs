using UnityEngine;

public class Enemy_Health : Entity_Health
{
    private Enemy enemy;
   protected override void Awake()
    {
        base.Awake();
        enemy = GetComponent<Enemy>();
    }

    public override void TakeDamage(float damage, Transform damageDealer)
    {
        base.TakeDamage(damage, damageDealer);

        if (IsDead)
        return;

        if(damageDealer.GetComponent<Player>() != null)
        {
            enemy.TryEnteringBattle(damageDealer); 
        }
     
    }
}
