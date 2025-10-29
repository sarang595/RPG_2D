using UnityEngine;

public class Player_WallJump : EntityState
{
    public Player_WallJump(Player player, StateMachine statemachine, string animBoolName) : base(player, statemachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
       //player jump diagonal direction against the facing direction
        player.SetVelocity(player.WallJumpForce.x * -player.FacingDirection, player.WallJumpForce.y);
        player.flip();
    }
    public override void Update()
    {
        base.Update();
        if(rb.linearVelocity.y <0)
        {
            statemachine.ChangeState(player.fallState);
        }
        if(player.WallDetected)
        {
            statemachine.ChangeState(player.wallSlideState);
        }
        if (input.Player.BasicAttack.WasPerformedThisFrame())
        {
            statemachine.ChangeState(player.jumpAttackState);
        }
    }
}
