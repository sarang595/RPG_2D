using System;
using System.Collections;
using UnityEngine;

public class Player : Entity
{
    public Player_Input input { get; private set; }

    public Vector2 MoveInput;
    public static event Action OnPlayerDeath;
    public Player_Idle idleState { get; private set; }
    public Player_Move moveState { get; private set; }
    public Player_Jump jumpState { get; private set; }
    public Player_Fall fallState { get; private set; }
    public Player_WallSlide wallSlideState { get; private set; }
    public Player_WallJump wallJumpState { get; private set; }
    public Player_Roll rollState { get; private set; }
    public Player_Basic_Attack basicAttackState { get; private set; }
    public Player_Dash_State dashState { get; private set; }
    public Player_Jump_Attack jumpAttackState { get; private set; }
    public Player_Death_State deathState { get; private set; }

    [Header("Attack Settings")]
    public Vector2[] AttackVelocity;
    public Vector2 JumpAttackVelocity;
    public float AttackVelocityDuration = .1f;
    public float ComboResetTime = 1;
    public float AttackTimer { get; set; }
    public float AttackCollDownTime = 1f;
    private Coroutine AttackQeuedCo;
    private bool playerFacingDirection = true;

    [Header("Roll Settings")]
    public float RollCollDownTime = 1f;
    public float RollTimer { get; set; }



    [Header("Dash Settings")]
    public float DashDuration = 0.5f;
    public float DashSpeed = 30f;

    [Header("Movement Settings")]
    public float Movespeed;
    public float JumpForce;
    public Vector2 WallJumpForce;
    [Range(0f, 1f)]
    public float AirforceMultiplier; //Multiplying with (player.Movespeed * player.AirforceMultiplier) in Aired State
    

    protected override void Awake()
    {
        base.Awake();
        defaultfacingRight = playerFacingDirection;
        input = new Player_Input();
        idleState = new Player_Idle(this, statemachine, "Idle");
        moveState = new Player_Move(this, statemachine, "Move");
        //Using Blend state in Animator for the transition from Jump to fall in Animator 
        jumpState = new Player_Jump(this, statemachine, "Jump");
        fallState = new Player_Fall(this, statemachine, "Jump");
        wallSlideState = new Player_WallSlide(this, statemachine, "WallSlide");
        wallJumpState = new Player_WallJump(this, statemachine, "Jump");
        rollState = new Player_Roll(this, statemachine, "Roll");
        basicAttackState = new Player_Basic_Attack(this, statemachine, "BasicAttack");
        dashState = new Player_Dash_State(this, statemachine, "Dash");
        jumpAttackState = new Player_Jump_Attack(this, statemachine, "JumpAttack");
        deathState = new Player_Death_State(this, statemachine, "Dead");
    }

    protected override void Start()
    {
        base.Start();
        statemachine.Initialize(idleState);
        RollTimer = RollCollDownTime;
    }
    public void EnterAttackStateWithDelay()
    {
        if (AttackQeuedCo != null)
        {
            StopCoroutine(AttackQeuedCo);
        }
        AttackQeuedCo = StartCoroutine(EnterAttackStateDelayCo());
    }
    public override void EntityDeath()
    {
        base.EntityDeath();
        OnPlayerDeath?.Invoke();
        statemachine.ChangeState(deathState);
    }

    private IEnumerator EnterAttackStateDelayCo()
    {
        yield return new WaitForEndOfFrame();
        statemachine.ChangeState(basicAttackState);
    }
    void OnEnable()
    {
        input.Player.Enable();
        input.Player.Movement.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        input.Player.Movement.canceled += ctx => MoveInput = (Vector2.zero);
    }
    void OnDisable()
    {
        input.Player.Disable();
    }
}

   
