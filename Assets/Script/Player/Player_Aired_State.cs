using UnityEngine;

public class Player_Aired_State : EntityState
{
    public Player_Aired_State(Player player, StateMachine statemachine, string animBoolName) : base(player, statemachine, animBoolName)
    {
    }

    public override void Update()
    {
        base.Update();
        player.SetVelocity(player.MoveInput.x * (player.Movespeed * player.AirforceMultiplier), rb.linearVelocity.y);
    }
}
