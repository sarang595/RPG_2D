using UnityEngine;

public class Player_Jump : Player_Aired_State
{
    public Player_Jump(Player player, StateMachine statemachine, string animBoolName) : base(player, statemachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(rb.linearVelocity.x, player.JumpForce);
    }
    public override void Update()
    {
        base.Update();
        if(rb.linearVelocity.y < 0)
        {
            statemachine.ChangeState(player.fallState);
        }
     
    }
}
