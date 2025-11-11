using UnityEngine;
using UnityEngine.Playables;

public abstract class PlayerState : EntityState
{
    protected Player player;  
    protected Player_Input input;

    protected PlayerState(Player player, StateMachine statemachine, string animBoolName) : base(statemachine, animBoolName)
    {
        this.player = player;
        anim = player.anim;
        rb = player.rb;
        collider = player.Collider2D;
        input = player.input;
    }

   
    public override void Update()
    {
        base.Update();

        //"yVelocity is the threshold value for the jump and fall transition in Blend state
         anim.SetFloat("yVelocity", rb.linearVelocity.y);

        if (input.Player.Dash.WasPerformedThisFrame() && CanDash())
        {
            statemachine.ChangeState(player.dashState);
        }
    }
  
    private bool CanDash()
    {
        if(player.WallDetected)
        {

            return false;
        }
        if(statemachine.CurrentState == player.dashState)
        {
            return false;
        }
        return true;
    }
    

}
