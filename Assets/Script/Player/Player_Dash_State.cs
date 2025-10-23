using UnityEngine;

public class Player_Dash_State : EntityState
{
    private float OriginalGravityScale;
    private float DashDir;
    public Player_Dash_State(Player player, StateMachine statemachine, string animBoolName) : base(player, statemachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        DashDir = player.FacingDirection;
        StateTimer = player.DashDuration;
        OriginalGravityScale = rb.gravityScale;
        rb.gravityScale = 0;
       
    }
    public override void Update()
    {
        base.Update();
        CancelDashNeeded();
        player.SetVelocity(player.DashSpeed * DashDir, 0);

        if (StateTimer < 0)
        {
            if(player.Grounded)
            {

            statemachine.ChangeState(player.idleState);
            }
            else
            {
                statemachine.ChangeState(player.fallState);
            }
        }
       
    }
    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0, 0);
        rb.gravityScale = OriginalGravityScale;
    }
    public void CancelDashNeeded()
    {
        if(player.WallDetected)
        {
            if(player.Grounded)
            {
                statemachine.ChangeState(player.idleState);
            }
            else
            {
                statemachine.ChangeState(player.wallSlideState);
            }
        }
    }
}
