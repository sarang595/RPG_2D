using UnityEngine;

public class StateMachine 
{
 public EntityState CurrentState {  get; private set; }
 private bool CanChangeState;
  

  public void Initialize(EntityState StartState)
    {
        CurrentState = StartState;
        CanChangeState = true;
        CurrentState.Enter();
    }
  public void ChangeState(EntityState NewState )
    {
        if (CanChangeState == false)
            return;

        CurrentState.Exit();
        CurrentState = NewState;
        CurrentState.Enter();
    }
    public void UpdateActiveState()
    {
        CurrentState.Update();
    }
    public void SwitchOffStateMachine()
    {
        CanChangeState = false;
    }
}
