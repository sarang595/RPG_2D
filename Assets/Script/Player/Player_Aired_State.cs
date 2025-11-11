using UnityEngine;

public class Player_Aired_State : PlayerState
{
    public Player_Aired_State(Player player, StateMachine statemachine, string animBoolName) : base(player, statemachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();
        //Give the ability to flip the player and control the velocity in air
        player.SetVelocity(player.MoveInput.x * (player.Movespeed * player.AirforceMultiplier), rb.linearVelocity.y); 
        if(input.Player.BasicAttack.WasPerformedThisFrame())
        {
            statemachine.ChangeState(player.jumpAttackState);
        }
    }
}
