using UnityEngine;
using UnityEngine.Playables;

public abstract class EntityState 
{
    protected Player player; 
    protected StateMachine statemachine;
    protected string animBoolName;
    protected Animator anim;
    protected Rigidbody2D rb;
    protected Player_Input input;
    protected bool triggerCalled;
    protected float StateTimer;
  

    public EntityState(Player player,StateMachine statemachine,string animBoolName)
    {
        this.player = player;
        this.statemachine = statemachine;
        this.animBoolName = animBoolName;
        anim = player.Playeranim;
        rb = player.rb;
        input = player.input;
       
    }

    public virtual void Enter()
    {
      anim.SetBool(animBoolName,true);
      triggerCalled = false;
    }
    public virtual void Update()
    {
        StateTimer -= Time.deltaTime;
        // "yVelocity is the threshold value for the jump and fall transition in Blend state
        anim.SetFloat("yVelocity", rb.linearVelocity.y); 

        if(input.Player.Dash.WasPerformedThisFrame() && CanDash())
        {
            statemachine.ChangeState(player.dashState);
        }
    }
    public virtual void Exit()
    {
      anim.SetBool(animBoolName, false);
    }
    public void AnimationTrigger()
    {
        triggerCalled = true;
       
        
    }
    private bool CanDash()
    {
        if(player.WallDetected)
        {

            return false;
        }
        if(statemachine.CurrentState == player.dashState)
        {
            return false;
        }
        return true;
    }
    

}
