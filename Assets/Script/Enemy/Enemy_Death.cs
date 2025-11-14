using UnityEngine;

public class Enemy_Death : EnemyState
{
    private Collider2D enemyCollider;
    private const float DeathPull = 12f;
    private const float DeathJump = 15f;
    public Enemy_Death(Enemy enemy, StateMachine statemachine, string animBoolName) : base(enemy, statemachine, animBoolName)
    {
        enemyCollider = enemy.GetComponent<Collider2D>();
    }
    public override void Enter()
    {
        base.Enter();
        anim.enabled = false;
        enemyCollider.enabled = false;
        rb.gravityScale = DeathPull;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, DeathJump);
        statemachine.SwitchOffStateMachine();
        
    }
}
