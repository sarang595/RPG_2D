using UnityEngine;

public class Chest : MonoBehaviour, IDamageable
{
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    private Entity_Vfx vfx => GetComponent<Entity_Vfx>();
    private Animator anim => GetComponentInChildren<Animator>();
    [SerializeField] private Vector2 ChestKnockBack;
    public void TakeDamage(float damage, Transform Damageable)
    {
        vfx.PlayVfx();
        anim.SetBool("ChestOpen", true);
        rb.linearVelocity = ChestKnockBack;
        rb.angularVelocity = Random.Range(-200, 200);
    }
}
