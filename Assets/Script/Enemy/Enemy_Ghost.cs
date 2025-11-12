using UnityEngine;

public class Enemy_Ghost : Enemy
{
    private bool ghostFacingRight = false;
 
    protected override void Awake()
    {
        base.Awake();
        IdleState = new Enemy_Idle(this, statemachine, "Idle");
        MoveState = new Enemy_Move(this, statemachine, "Move");
        AttackState = new Enemy_Attack(this, statemachine, "Attack");
        BattleState = new Enemy_Battle(this, statemachine, "Battle");
    }
    protected override void Start()
    {
        base.Start();
        defaultfacingRight = ghostFacingRight;
        if (!defaultfacingRight)
        {
            flip();
        }
        statemachine.Initialize(IdleState);
    }
    

}
