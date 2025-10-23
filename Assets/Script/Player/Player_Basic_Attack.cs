using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnityEngine;
public class Player_Basic_Attack : Player_Ground_State
{
    private float AttackVelocityTimer;
    private int ComboIndex = 1;
    private int MaxComboIndex = 3;
    private const int FirstComboIndex = 1;
    private float LastTimeAttacked;
    private bool ComboAttackQeued = false;
    private int playerAttackdir;


    public Player_Basic_Attack(Player player, StateMachine statemachine, string animBoolName) : base(player, statemachine, animBoolName)
    {
        if(MaxComboIndex != player.AttackVelocity.Length)
        {
            MaxComboIndex = player.AttackVelocity.Length;
        }
    }
    public override void Enter()
    {
        base.Enter();
        player.AttackTimer = player.AttackCollDownTime;
        ComboAttackQeued = false;
        ComboIndexReset();
        playerAttackdir = player.MoveInput.x != 0 ? ((int)player.MoveInput.x) : player.FacingDirection;
        GenerateAttackVelocity();
        anim.SetInteger("ComboIndex", ComboIndex);
 
    }
    public override void Update()
    {
        base.Update();
       
        HandleAttackVelocity();
        if(input.Player.BasicAttack.WasPerformedThisFrame())
        {
            QeueNextAttack();
        }
        if(triggerCalled)
        {
            HandleStateExit();
        }
     

    }
    public override  void Exit()
    {
        base.Exit();   
        LastTimeAttacked = Time.time;
        ComboIndex++;
    }

    private void QeueNextAttack()
    {
        if (ComboIndex < MaxComboIndex)
        {
            ComboAttackQeued = true;
        }
    }
    private void HandleStateExit()
    {
        if (ComboAttackQeued)
        {
            anim.SetBool(animBoolName, false);
            player.EnterAttackStateWithDelay();
        }
        else
        {
            anim.SetBool(animBoolName, false);
            statemachine.ChangeState(player.idleState);
        }
    }
    private void HandleAttackVelocity()
    {
        AttackVelocityTimer -= Time.deltaTime;
        if (AttackVelocityTimer < 0)
        {
            player.SetVelocity(0, rb.linearVelocity.y);
        }

    }
    private void GenerateAttackVelocity()
    {
        AttackVelocityTimer = player.AttackVelocityDuration;
        Vector2 AttackVelocity = player.AttackVelocity[ComboIndex - 1];
        player.SetVelocity(AttackVelocity.x * playerAttackdir, AttackVelocity.y);
    }
    private void ComboIndexReset()
    {
        
        if(ComboIndex > MaxComboIndex || Time.time > LastTimeAttacked + player.ComboResetTime )
        {
            ComboIndex = FirstComboIndex;
        }

    }
   





}
