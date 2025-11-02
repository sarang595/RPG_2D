using UnityEngine;

public class StateMachine 
{
 public EntityState CurrentState {  get; private set; }
   
  

  public void Initialize(EntityState StartState)
    {
        CurrentState = StartState;
        CurrentState.Enter();
    }
  public void ChangeState(EntityState NewState )
    {
        CurrentState.Exit();
        CurrentState = NewState;
        CurrentState.Enter();
    }
}
