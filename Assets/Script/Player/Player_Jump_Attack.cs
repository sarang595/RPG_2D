using UnityEngine;

public class Player_Jump_Attack : Player_Aired_State 
{
    private bool groundtouched;
    public Player_Jump_Attack(Player player, StateMachine statemachine, string animBoolName) : base(player, statemachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        groundtouched = false;
        player.SetVelocity(player.JumpAttackVelocity.x * player.FacingDirection, player.JumpAttackVelocity.y);
    }

    public override void Update()
    {
        base.Update();
        if(player.Grounded && groundtouched ==false)
        {
        groundtouched = true;
        anim.SetTrigger("JumpAttackTrigger");
        player.SetVelocity(0,rb.linearVelocity.y);

         }
        if(triggerCalled && player.Grounded)
        {
            statemachine.ChangeState(player.idleState);
        }
    }
}
