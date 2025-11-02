using UnityEngine;

public abstract class EntityState
{
   
    protected StateMachine statemachine;
    protected string animBoolName;
    protected Animator anim;
    protected Rigidbody2D rb;
    protected CapsuleCollider2D collider;
    protected bool triggerCalled;
    protected float StateTimer;


    public EntityState( StateMachine statemachine, string animBoolName)
    {
       
        this.statemachine = statemachine;
        this.animBoolName = animBoolName; 

    }

    public virtual void Enter()
    {
        anim.SetBool(animBoolName, true);
        triggerCalled = false;
    }
    public virtual void Update()
    {
        StateTimer -= Time.deltaTime;
        
    }
    public virtual void Exit()
    {
        anim.SetBool(animBoolName, false);
    }
    public void AnimationTrigger()
    {
        triggerCalled = true;

    }
  


}
