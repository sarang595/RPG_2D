using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public StateMachine statemachine { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public Player_Input input { get; private set; }
    public Animator Playeranim { get; private set; }

    public Vector2 MoveInput;
    public Player_Idle idleState { get; private set; }
    public Player_Move moveState { get; private set; }
    public Player_Jump jumpState { get; private set; }
    public Player_Fall fallState { get; private set; }
    public Player_WallSlide wallSlideState { get; private set; }
    public Player_WallJump wallJumpState { get; private set; }
    public Player_Roll rollState { get; private set; }
    public Player_Basic_Attack basicAttackState { get; private set; }
    public Player_Dash_State dashState { get; private set; }
    public Player_Jump_Attack jumpAttackState {  get; private set; }

    [Header("Attack Settings")]
    public Vector2[] AttackVelocity;
    public Vector2 JumpAttackVelocity;
    public float AttackVelocityDuration = .1f;
    public float ComboResetTime = 1;
    public float AttackTimer { get;  set; }
    public float AttackCollDownTime = 1f;

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
    private bool facingRight = true;
   
   
    public int FacingDirection { get; private set; } = 1; // Using this to detect walldetection
    [Range(0f, 1f)]
    public float AirforceMultiplier; //Multiplying with (player.Movespeed * player.AirforceMultiplier) in Aired State

    [Header("Collision Detection")]
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] public bool Grounded;
    [SerializeField] public bool WallDetected;
    public Transform PrimayWallCheck;
    public Transform SeondaryWallCheck;
    [Range(0f, 1f)]
    public float WallSlideMultiplier; //Multiplying with (player.MoveInput.x, rb.linearVelocity.y * player.WallSlideMultiplier) in wall slide state to control sliding speed
    public float GroundCollisionDistance;
    public float WallCollisionDistance;
    private Coroutine AttackQeuedCo;
    void Awake()
    {
        Playeranim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        statemachine = new StateMachine();
        input = new Player_Input();
        idleState = new Player_Idle(this,statemachine,"Idle");
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
    void Start()
    {
        statemachine.Initialize(idleState);
        RollTimer = RollCollDownTime;
    }
    void Update()
    {
        collisionDetection();
        statemachine.CurrentState.Update();
    }
    public void EnterAttackStateWithDelay()
    {
        if(AttackQeuedCo!=null)
        {
            StopCoroutine(AttackQeuedCo);
        }
        AttackQeuedCo = StartCoroutine(EnterAttackStateDelayCo());
    }
   

    private IEnumerator EnterAttackStateDelayCo()
    {
        yield return new WaitForEndOfFrame();
        statemachine.ChangeState(basicAttackState);
    }
    public void CallAnimationTrigger()
    {
        statemachine.CurrentState.AnimationTrigger();
    }
    public void SetVelocity (float Xvelocity, float Yvelocity)
    {
        rb.linearVelocity = new Vector2 (Xvelocity,Yvelocity);
        handleFlip();
    }
    void handleFlip()
    {
        if ((MoveInput.x > 0 && !facingRight) || (MoveInput.x < 0 && facingRight))
        flip();
    }
    public void flip()
    {
        facingRight = !facingRight;
        Vector3 CurrentScale = transform.localScale;
        CurrentScale.x = Mathf.Abs(CurrentScale.x) * (facingRight ? 1 : -1);
        transform.localScale = CurrentScale;
        FacingDirection = FacingDirection * -1;
    }

   void collisionDetection()
    {
        Grounded = Physics2D.Raycast(transform.position, Vector2.down, GroundCollisionDistance, GroundLayer);
        WallDetected = Physics2D.Raycast(PrimayWallCheck.position, Vector2.right * FacingDirection, WallCollisionDistance, GroundLayer) &&
                       Physics2D.Raycast(SeondaryWallCheck.position, Vector2.right * FacingDirection, WallCollisionDistance, GroundLayer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -GroundCollisionDistance, 0));
        Gizmos.DrawLine(PrimayWallCheck.position, PrimayWallCheck.position + new Vector3 (WallCollisionDistance*FacingDirection,0));
        Gizmos.DrawLine(SeondaryWallCheck.position, SeondaryWallCheck.position + new Vector3(WallCollisionDistance * FacingDirection, 0));
    }
}

   
