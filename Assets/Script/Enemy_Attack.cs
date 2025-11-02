using UnityEngine;

public class Enemy_Attack : EnemyState
{
    public Enemy_Attack(Enemy enemy, StateMachine statemachine, string animBoolName) : base(enemy, statemachine, animBoolName)
    {
       
    }
    public override void Update()
    {
        base.Update();
        if(triggerCalled)
        {
            statemachine.ChangeState(enemy.BattleState);
        }
    }
}
