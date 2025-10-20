using UnityEngine;

public class Player_Basic_Attack : Player_Ground_State
{
    public Player_Basic_Attack(Player player, StateMachine statemachine, string animBoolName) : base(player, statemachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
       
    }
    public override void Update()
    {
        base.Update();
        player.SetVelocity(player.AttackVelocity.x * player.FacingDirection, player.AttackVelocity.y);
        HandleStateExit(player.idleState);
    }
}
