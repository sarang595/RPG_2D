using UnityEngine;

public class EnemyState : EntityState
{
    protected Enemy enemy;
    public EnemyState(Enemy enemy, StateMachine statemachine, string animBoolName) : base(statemachine, animBoolName)
    {
        this.enemy = enemy;
        anim = enemy.anim;
        rb = enemy.rb;
    }
    public override void Update()
    {
        base.Update();
        anim.SetFloat("xVelocity", rb.linearVelocity.x);
    }

}
