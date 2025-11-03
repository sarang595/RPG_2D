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

        float BattleAnimationMultiplier = enemy.BattleSpeed / enemy.MoveSpeed;
        anim.SetFloat("xVelocity", rb.linearVelocity.x);
        anim.SetFloat("AttackAnimationMultiplier", enemy.AttackAnimationMultiplier);
        anim.SetFloat("BattleAnimationMultiplier", BattleAnimationMultiplier);
        //if (Input.GetKey(KeyCode.F))
        //{
        //    statemachine.ChangeState(enemy.AttackState);
        //}
        //Debug.Log(rb.linearVelocity.x);
      //  Debug.Log(statemachine.CurrentState);
    }

}
