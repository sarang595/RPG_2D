using UnityEngine;

public class Player : MonoBehaviour
{
    public StateMachine statemachine { get; private set; }  
    public Rigidbody2D rb {  get; private set; }
    public Player_Input input { get; private set; }
    public Animator Playeranim { get; private set; }

    public Vector2 MoveInput;
    public Player_Idle idleState { get; private set; }
    public Player_Move moveState { get; private set; }

    [Header("Movement Settings")]
    public float Movespeed;
    private void Awake()
    {
        Playeranim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        statemachine = new StateMachine();
        input = new Player_Input();
        idleState = new Player_Idle(this,statemachine,"Idle");
        moveState = new Player_Move(this, statemachine, "Move");
    }
    private void OnEnable()
    {
        input.Player.Enable();
        input.Player.Movement.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        input.Player.Movement.canceled += ctx => MoveInput = (Vector2.zero);
    }
    private void OnDisable()
    {
        input.Player.Disable();
    }
    void Start()
    {
        statemachine.Initialize(idleState);
    }

   
    void Update()
    {
        statemachine.CurrentState.Update();
    }
    public void SetVelocity (float Xvelocity, float Yvelocity)
    {
        rb.linearVelocity = new Vector2 (Xvelocity,Yvelocity);
    }
}
