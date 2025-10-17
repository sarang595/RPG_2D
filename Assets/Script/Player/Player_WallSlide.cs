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
            //when key pressed change slide speed to normal
            player.SetVelocity(player.MoveInput.x, rb.linearVelocity.y);
        }
        else
        {
            //slow down the slide speed if no key is not pressed
            player.SetVelocity(player.MoveInput.x, rb.linearVelocity.y * player.WallSlideMultiplier);
        }
       
    }
   
}
   

