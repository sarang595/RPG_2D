using UnityEngine;

public  class Entity : MonoBehaviour
{
    public StateMachine statemachine { get; private set; }
    public Rigidbody2D rb { get; private set; }
  
    public Animator anim { get; private set; }
    public CapsuleCollider2D Collider2D { get; set; }

    

    private bool facingRight = true;
    protected bool defaultfacingRight { get; set; } = true;


    public int FacingDirection { get; private set; } = 1; // Using this to detect walldetection
  

    [Header("Collision Detection")]
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public bool Grounded;
    [SerializeField] public bool WallDetected;
    public Transform GroundCheck;
    public Transform PrimayWallCheck;
    public Transform SecondaryWallCheck;
    [Range(0f, 1f)]
    public float WallSlideMultiplier; //Multiplying with (player.MoveInput.x, rb.linearVelocity.y * player.WallSlideMultiplier) in wall slide state to control sliding speed
    public float GroundCollisionDistance;
    public float WallCollisionDistance;
    
    protected virtual void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        statemachine = new StateMachine();
        Collider2D = GetComponent<CapsuleCollider2D>();
       
    }
    
    protected virtual void Start()
    {
       
    }
    void Update()
    {
        collisionDetection();
        statemachine.CurrentState.Update();
    }
    
    public void CallAnimationTrigger()
    {
        statemachine.CurrentState.AnimationTrigger();
    }
    public void SetVelocity(float Xvelocity, float Yvelocity)
    {
        rb.linearVelocity = new Vector2(Xvelocity, Yvelocity);
        handleFlip(Xvelocity);
    }
   public void handleFlip(float XVelocity)
    {
        if ((XVelocity > 0 && !facingRight) || (XVelocity < 0 && facingRight))
            flip();
    }
    public void flip()
    {
        //Debug.Log("flipping");
        facingRight = !facingRight;
        Vector3 CurrentScale = transform.localScale;
        int Orientation = defaultfacingRight ? 1 : -1; // Since Enemy Sprite is facing left default turning sprite right here
        CurrentScale.x = Mathf.Abs(CurrentScale.x) * Orientation * (facingRight ? 1 : -1);
        transform.localScale = CurrentScale;
        FacingDirection = FacingDirection * -1;

    }

    void collisionDetection()
    {
        Grounded = Physics2D.Raycast(GroundCheck.position, Vector2.down, GroundCollisionDistance, groundLayer);
        if (SecondaryWallCheck != null)
        {
            WallDetected = Physics2D.Raycast(PrimayWallCheck.position, Vector2.right * FacingDirection, WallCollisionDistance, groundLayer) &&
                           Physics2D.Raycast(SecondaryWallCheck.position, Vector2.right * FacingDirection, WallCollisionDistance, groundLayer);
        }
        else
            WallDetected = Physics2D.Raycast(PrimayWallCheck.position, Vector2.right * FacingDirection, WallCollisionDistance, groundLayer);

    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(GroundCheck.position, GroundCheck.position + new Vector3(0, -GroundCollisionDistance, 0));
        Gizmos.DrawLine(PrimayWallCheck.position, PrimayWallCheck.position + new Vector3(WallCollisionDistance * FacingDirection, 0));
        if (SecondaryWallCheck != null)
        Gizmos.DrawLine(SecondaryWallCheck.position, SecondaryWallCheck.position + new Vector3(WallCollisionDistance * FacingDirection, 0));
    }
}
