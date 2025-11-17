using UnityEngine;

public class Enemy_Stunned : EnemyState
{
   
    public Enemy_Stunned(Enemy enemy, StateMachine statemachine, string animBoolName) : base(enemy, statemachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        StateTimer = enemy.StunnedDuration;
        rb.linearVelocity = new Vector2(enemy.StunnedVelocity.x * - enemy.FacingDirection, enemy.StunnedVelocity.y);

    }
    public override void Update()
    {
        base.Update();
        if(StateTimer <0)
        {
            statemachine.ChangeState(enemy.IdleState);
        }
    }
}
