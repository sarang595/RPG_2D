using UnityEngine;

public class Player_Roll : Player_Ground_State
{
   
    public Player_Roll(Player player, StateMachine statemachine, string animBoolName) : base(player, statemachine, animBoolName)
    {
    }
    public override void Enter()
    {
       base.Enter();
      //Reset Roll Timer 
       player.RollTimer = player.RollCollDownTime;
      // Debug.Log("Roll started. Cooldown: " + player.RollCollDownTime);

    }
    public override void Update()
    {
        base.Update();
        HandleStateExit(player.idleState);
    }
   
}
