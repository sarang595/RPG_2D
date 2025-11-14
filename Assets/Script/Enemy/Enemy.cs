
using UnityEngine;

using System.Collections;


public class Enemy : Entity
{
    public Enemy_Idle IdleState;
    public  Enemy_Move MoveState;
    public Enemy_Attack AttackState;
    public Enemy_Battle BattleState;
    public Enemy_Death DeadthState;

    [Header("Movement Settings")]
    public float IdleTimer;
    public float MoveSpeed;

    [Header("Battle Settings")]
    public float BattleSpeed;
    public float AttackRange;
    public float AttackAnimationMultiplier;
    public float BattleTimeDuration = 5f;
    public float minRetreatDistance = 1.5f;
    public Vector2 Retreat;
    private Coroutine VerticalthersholdCo;


    [Header("Player Detection")]
    [SerializeField] private float PlayerCheckDistance;
    [SerializeField] private Transform playerChecker;
    [SerializeField] private LayerMask playerLayer;
    public Transform player { get; private set; }

    public void TryEnteringBattle(Transform player)
    {
        if (statemachine.CurrentState == BattleState || statemachine.CurrentState == AttackState)
        {
            return;
        }
        this.player = player;
        statemachine.ChangeState(BattleState);

    }
    public Transform GetPlayerReference()
    {
        if (player == null)
        {
            player = PlayerDetected().transform;
        }
        return player;
    }
    public override void EntityDeath()
    {
        base.EntityDeath();
        statemachine.ChangeState(DeadthState);
    }

    public RaycastHit2D PlayerDetected()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right * FacingDirection, PlayerCheckDistance, playerLayer | groundLayer);
        if (hit.collider == null || hit.collider.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            return default;
        }
        return hit;
    }
    public void IdleStateRecieverco(float duration)
    {
        if(VerticalthersholdCo!=null)
        {
            StopCoroutine(VerticalthersholdCo);
            VerticalthersholdCo = StartCoroutine(HoldIdleState(duration));
        }

    }
    private IEnumerator HoldIdleState(float duration)
    {
        yield return new WaitForSeconds(duration);
        statemachine.ChangeState(IdleState);
    }


    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawLine(playerChecker.position, new Vector3(playerChecker.position.x + PlayerCheckDistance * FacingDirection, playerChecker.position.y));
        //Gizmos.color = Color.red;
        //Gizmos.DrawLine(playerChecker.position, new Vector3(playerChecker.position.x + AttackRange * FacingDirection, playerChecker.position.y));
    }
    
    
}
