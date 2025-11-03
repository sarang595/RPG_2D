using UnityEngine;

public class Enemy_Grounded : EnemyState
{
    public Enemy_Grounded(Enemy enemy, StateMachine statemachine, string animBoolName) : base(enemy, statemachine, animBoolName)
    {
    }
    public override void Update()
    {
        base.Update();
        if(enemy.PlayerDetected() )
        {
            
            statemachine.ChangeState(enemy.BattleState);
            
        }
        

    }
}
