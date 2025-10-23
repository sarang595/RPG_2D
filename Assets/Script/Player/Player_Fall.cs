using UnityEngine;

public class Player_Fall : Player_Aired_State
{
    public Player_Fall(Player player, StateMachine statemachine, string animBoolName) : base(player, statemachine, animBoolName)
    {
    }
    public override void Update()
    {
        base.Update();
      
        if (player.Grounded)
        {
            statemachine.ChangeState(player.idleState);
        }
        if (player.WallDetected)
        {
            //Debug.Log("wall Detected");
            statemachine.ChangeState(player.wallSlideState);
          
        }

    }
}
