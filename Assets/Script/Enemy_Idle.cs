using UnityEngine;

public class Enemy_Idle : EnemyState
{
    public Enemy_Idle(Enemy enemy, StateMachine statemachine, string animBoolName) : base(enemy, statemachine, animBoolName)
    {
     
    }
    public override void Enter()
    {
        base.Enter();
        StateTimer = enemy.IdleTimer;
        //Debug.Log(enemy.WallDetected);
        //Debug.Log(enemy.Grounded);
    }
    public override void Update()
    {
        base.Update();
        
        if (StateTimer <=0)
        {
            statemachine.ChangeState(enemy.MoveState);

        }
    }
}

