using UnityEngine;

public class Player_Move : Player_Ground_State
{
    public Player_Move(Player player, StateMachine statemachine, string animBoolName) : base(player, statemachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        if(player.MoveInput.x==0 || player.WallDetected)
        {
            statemachine.ChangeState(player.idleState);
        }
        player.SetVelocity(player.MoveInput.x * player.Movespeed, player.rb.linearVelocity.y);
    }
}
