using UnityEngine;

public class Player_Roll : Player_Ground_State
{
   
    public Player_Roll(Player player, StateMachine statemachine, string animBoolName) : base(player, statemachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
       
    }
    public override void Update()
    {
        base.Update();
        
        HandleStateExit();
    }
    private void HandleStateExit()
    {
        if (triggerCalled)
        statemachine.ChangeState(player.idleState);
    }
}
