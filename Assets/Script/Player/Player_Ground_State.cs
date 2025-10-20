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
        // Roll Coll Down Time calculation
        if (player.RollTimer > 0)
        {
            player.RollTimer -= Time.deltaTime;
        }

        if (input.Player.Jump.WasCompletedThisFrame())
        {
            statemachine.ChangeState(player.jumpState);
        }
       if(input.Player.Roll.WasCompletedThisFrame() && player.RollTimer <=0)
        {
         
            statemachine.ChangeState(player.rollState);
        
        }
       if(input.Player.BasicAttack.WasCompletedThisFrame())
        {
            statemachine.ChangeState(player.basicAttackState);
        }
    }
}
