using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class Enemy : Entity
{
    public Enemy_Idle IdleState;
    public  Enemy_Move MoveState;
    public Enemy_Attack AttackState;
    public Enemy_Battle BattleState;

    [Header("Movement Settings")]
    public float IdleTimer;
    public float MoveSpeed;

    [Header("Battle Settings")]
    [SerializeField] private float PlayerCheckDistance;
    [SerializeField] private Transform playerChecker;
    [SerializeField] private LayerMask playerLayer;

    
    public RaycastHit2D PlayerDetection()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right*FacingDirection, PlayerCheckDistance, playerLayer | groundLayer );
        if (hit.collider == null || hit.collider.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            return default;
        }
        return hit;
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(playerChecker.position, new Vector3(playerChecker.position.x + PlayerCheckDistance * FacingDirection, playerChecker.position.y));

    }
    


}
