using UnityEngine;

public class Enemy_Battle : EnemyState
{
    public Enemy_Battle(Enemy enemy, StateMachine statemachine, string animBoolName) : base(enemy, statemachine, animBoolName)
    {
     
    }
    public override void Update()
    {
        base.Update();
       
    }
}
