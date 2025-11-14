using UnityEngine;

public class Player_Death_State : PlayerState
{
    public Player_Death_State(Player player, StateMachine statemachine, string animBoolName) : base(player, statemachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        input.Disable();
        rb.simulated=false;
    }
}
