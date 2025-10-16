using UnityEngine;


public class Player_Idle : Player_Ground_State
{
    public Player_Idle(Player player, StateMachine statemachine, string animBoolName) : base(player, statemachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(0, player.rb.linearVelocity.y);
    }
    public override void Update()
    {
        base.Update();
        if(player.MoveInput.x!=0)
        {
         statemachine.ChangeState(player.moveState);
        
        }
       
    }

}
