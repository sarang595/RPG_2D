using UnityEngine;

public class Player_Ground_State : PlayerState
{
    public Player_Ground_State(Player player, StateMachine statemachine, string animBoolName) : base(player, statemachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();

    }
    public override void Update()
    {
        base.Update();
        GroundStateCollDownTimer();
        if (rb.linearVelocity.y < 0 && !player.Grounded)
        {
            statemachine.ChangeState(player.fallState);
        }
        if (input.Player.Jump.WasCompletedThisFrame())
        {
            statemachine.ChangeState(player.jumpState);
        }
       if(input.Player.Roll.WasCompletedThisFrame() && player.RollTimer <=0)
        {
         
            statemachine.ChangeState(player.rollState);       
        }
       if(input.Player.BasicAttack.WasCompletedThisFrame() && player.AttackTimer <=0)
        {
            statemachine.ChangeState(player.basicAttackState);

        }
    }
    private void GroundStateCollDownTimer()
    {
        // Roll && Attack Coll Down Time calculation
        if ((player.RollTimer > 0) || (player.AttackTimer > 0))
        {
            player.RollTimer -= Time.deltaTime;
            player.AttackTimer -= Time.deltaTime;
        }
    }
}
