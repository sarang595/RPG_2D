using UnityEngine;

public class Player_Roll : Player_Ground_State
{
    private Vector2 originalOffset;
    private Vector2 originalSize;
    private const int RollStateSizeDelta = 1;
    private const float RollStateOffsetDelta= 0.24f;
    public Player_Roll(Player player, StateMachine statemachine, string animBoolName) : base(player, statemachine, animBoolName)
    {
    }
    public override void Enter()
    {
       base.Enter();
       // Change Collider Size
        originalOffset = collider.offset;
        originalSize = collider.size;
        collider.offset = new Vector2(originalOffset.x, originalOffset.y/ RollStateOffsetDelta);
        collider.size = new Vector2(originalSize.x, originalSize.y - RollStateSizeDelta);
      //Reset Roll Timer 
        player.RollTimer = player.RollCollDownTime;
      // Debug.Log("Roll started. Cooldown: " + player.RollCollDownTime);

    }
    public override void Update()
    {
        base.Update();
        if(triggerCalled)
        {
            statemachine.ChangeState(player.idleState);
        }
       
    }
    public override void Exit()
    {
        base.Exit();
        // Reset Collider Size
        collider.offset = originalOffset;
        collider.size = originalSize;
    }

}
