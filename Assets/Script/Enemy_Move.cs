using UnityEngine;

public class Enemy_Move : Enemy_Grounded
{
    public Enemy_Move(Enemy enemy, StateMachine statemachine, string animBoolName) : base(enemy, statemachine, animBoolName)
    {
       
    }

    public override void Enter()
    {
        base.Enter();
        if (!enemy.Grounded || enemy.WallDetected)
        {
            enemy.flip();
        }
    }
    public override void Update()
    {
        base.Update();
        enemy.SetVelocity(enemy.MoveSpeed * enemy.FacingDirection, rb.linearVelocity.y);

        if (enemy.Grounded== false|| enemy.WallDetected == true)
        {
            statemachine.ChangeState(enemy.IdleState);
        }
    }   
    
}
