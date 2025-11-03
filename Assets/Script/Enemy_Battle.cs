using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Battle : EnemyState
{
    public Transform player;
    private float lastTimewasInBattle;
    private const float verticalThreshold = 1; // To avoid retreat when player "y" pos changing
    public Enemy_Battle(Enemy enemy, StateMachine statemachine, string animBoolName) : base(enemy, statemachine, animBoolName)
    {
     
    }
    public override void Enter()
    {
        base.Enter();
        if (player == null)
        {
            player = enemy.PlayerDetected().transform;
        }
    }
    public override void Update()
    {
        base.Update();
        if (enemy.PlayerDetected())
        {
            updateBattleTimer();
        }

        if (BattleTimeisOver())
        {
            statemachine.ChangeState(enemy.IdleState);
            return;
        }

        // If player is too high above, do nothing or handle differently
       
        if (verticalDistance() > verticalThreshold) 
        {
            enemy.SetVelocity(0, rb.linearVelocity.y); // Enemy stands still or idle
            return;
        }

        if (WithingAttackRange() && enemy.PlayerDetected())
        {
            statemachine.ChangeState(enemy.AttackState);
            return;
        }

        if (RetreatEnemy())
        {
            enemy.SetVelocity(enemy.BattleRetreatvelocity.x * -DirectionToPlayer(), rb.linearVelocity.y);
            enemy.handleFlip(DirectionToPlayer());
        }
        else
        {
            // Enemy moves towards player only if not retreating
            enemy.SetVelocity(enemy.BattleSpeed * DirectionToPlayer(), rb.linearVelocity.y);
            enemy.handleFlip(DirectionToPlayer());
        }


    }

    private void updateBattleTimer() => lastTimewasInBattle = Time.time;
    private bool BattleTimeisOver() => Time.time > lastTimewasInBattle + enemy.BattleTimeDuration;
    private bool WithingAttackRange() => DistanceToPlayer() <= enemy.AttackRange;
    private float verticalDistance() => player.position.y - enemy.transform.position.y;
    private bool RetreatEnemy() => DistanceToPlayer() <= enemy.BattleRetreatDistance;
    private float DistanceToPlayer()
    {
        if (player == null)
            return float.MaxValue;
        else
            return Mathf.Abs(player.position.x - enemy.transform.position.x);
    }
    public int DirectionToPlayer()
    {
        if (player == null) return 0;

        float horizontalDistance = player.position.x - enemy.transform.position.x;
        float threshold = 0.1f; 

        if (Mathf.Abs(horizontalDistance) < threshold)
            return 0;

        return horizontalDistance > 0 ? 1 : -1;
    }
   

}
