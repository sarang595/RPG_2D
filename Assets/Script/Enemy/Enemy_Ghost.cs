using UnityEngine;

public class Enemy_Ghost : Enemy, ICounterable
{
    private bool ghostFacingRight = false;

  

    protected override void Awake()
    {
        base.Awake();
        IdleState = new Enemy_Idle(this, statemachine, "Idle");
        MoveState = new Enemy_Move(this, statemachine, "Move");
        AttackState = new Enemy_Attack(this, statemachine, "Attack");
        BattleState = new Enemy_Battle(this, statemachine, "Battle");
        DeadthState = new Enemy_Death(this, statemachine, "Idle");
        StunnedState = new Enemy_Stunned(this, statemachine, "Stunned");
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
    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.F))
        {

        HandleCounterAttack();
        }
    }
  
    public void HandleCounterAttack()
    {
        if (CanStunned == false)
            return;
        statemachine.ChangeState(StunnedState);
    }

}
