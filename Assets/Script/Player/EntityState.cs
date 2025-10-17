using UnityEngine;

public abstract class EntityState 
{
    protected Player player; 
    protected StateMachine statemachine;
    protected string animBoolName;
    protected Animator anim;
    protected Rigidbody2D rb;
    protected Player_Input input;
    protected bool triggerCalled;

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
        // "yVelocity is the threshold value for the jump and fall transition in Blend state
        anim.SetFloat("yVelocity", rb.linearVelocity.y); 
    }
    public virtual void Exit()
    {
      anim.SetBool(animBoolName, false);
    }
    public void AnimationTigger()
    {
        triggerCalled = true;
    }
}
