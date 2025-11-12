using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Entity_Combat : MonoBehaviour
{
    public float damage;
    [Header("Target Detection")]
    [SerializeField] Transform Target;
    [SerializeField] float TargetRadius;
    [SerializeField] LayerMask WhatisTarget;
    

    public void PerformAttack()
    {
        GetDetectedColliders();
        foreach (Collider2D Target in GetDetectedColliders())
        {
           Entity_Health entity_Health = Target.GetComponent<Entity_Health>();
            if(entity_Health != null )
            {
            entity_Health.TakeDamage(damage, transform);
            }
        }
    }

    private Collider2D[] GetDetectedColliders()
    {
        return Physics2D.OverlapCircleAll(Target.position, TargetRadius,WhatisTarget);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(Target.position, TargetRadius);
    }
}
