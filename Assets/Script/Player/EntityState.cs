using UnityEngine;

public abstract class EntityState 
{
    protected Player player;
    protected StateMachine statemachine;
    protected string animBoolName;
    protected Animator anim;
    protected Rigidbody2D rb;
    protected Player_Input input;

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
    }
    public virtual void Update()
    {

    }
    public virtual void Exit()
    {
        anim.SetBool(animBoolName, false);
    }
}
