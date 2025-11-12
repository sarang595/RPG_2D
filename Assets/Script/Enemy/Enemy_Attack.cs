using UnityEngine;

public class Enemy_Attack : EnemyState
{
    public Enemy_Attack(Enemy enemy, StateMachine statemachine, string animBoolName) : base(enemy, statemachine, animBoolName)
    {
       
    }
    public override void Enter()
    {
        base.Enter();
     //   Debug.Log("Enter Attack");
    }
    public override void Update()
    {
        base.Update();
          //Debug.Log("triggerCalled" + triggerCalled);
        if(triggerCalled)
        {
        //  Debug.Log("triggered");
            statemachine.ChangeState(enemy.BattleState);
            //statemachine.ChangeState(enemy.IdleState);
        }
    }
}
