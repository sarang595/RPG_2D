using UnityEngine;

public class Entity_Combat : MonoBehaviour
{ 
    [SerializeField] Transform Target;
    [SerializeField] float TargetRadius;
    [SerializeField] LayerMask WhatisTarget;

    public void PerformAttack()
    {
        GetDetectedColliders();
        foreach (Collider2D collider in GetDetectedColliders())
        {
            Debug.Log("Attacking" + collider.name);
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
