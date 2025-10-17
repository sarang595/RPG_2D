using System.Collections;
using UnityEngine;

public class Player_WallSlide : EntityState
{
    public Player_WallSlide(Player player, StateMachine statemachine, string animBoolName) : base(player, statemachine, animBoolName)
    {
    }
    public override void Update()
    {
        base.Update();
        handleWallSlide();
        if(input.Player.Jump.WasPerformedThisFrame())
        {
            //Debug.Log("Wall Jump Pressed");
          statemachine.ChangeState(player.wallJumpState);
        }
        if (!player.WallDetected && !player.Grounded)
        {
         statemachine.ChangeState(player.fallState);
        }
        if (player.Grounded)
        {
         statemachine.ChangeState(player.idleState);
        }
    }
    private void handleWallSlide()
    {
        if(player.MoveInput.y <0)
        {
            //Debug.Log("Keypressed");
            player.SetVelocity(player.MoveInput.x, rb.linearVelocity.y);
        }
        else
        {
            player.SetVelocity(player.MoveInput.x, rb.linearVelocity.y * player.WallSlideMultiplier);
        }
       
    }
   
}
   

