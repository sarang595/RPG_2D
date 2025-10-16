using UnityEngine;

public class Player_Ground_State : EntityState
{
    public Player_Ground_State(Player player, StateMachine statemachine, string animBoolName) : base(player, statemachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        if(input.Player.Jump.WasCompletedThisFrame())
        {
            statemachine.ChangeState(player.jumpState);
        }
    }
}
