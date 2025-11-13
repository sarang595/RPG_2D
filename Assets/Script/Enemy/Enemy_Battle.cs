using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy_Battle : EnemyState
{
    
    public Transform player;
    private float lastTimewasInBattle;
    private const float verticalThreshold =3; // To avoid retreat when player "y" pos changing
    private const float IdleStateholdDuration = 0.5f;
    public Enemy_Battle(Enemy enemy, StateMachine statemachine, string animBoolName) : base(enemy, statemachine, animBoolName)
    {

    }
    public override void Enter()
    {
        base.Enter();
        updateBattleTimer();
        if (player == null)
        {
            player = enemy.GetPlayerReference(); ;
        }
       

    if (EnemyRetreat())
        {
            rb.linearVelocity = new Vector2(enemy.Retreat.x * -DirectionToPlayer(), enemy.Retreat.y);
            enemy.handleFlip(DirectionToPlayer());

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
    

        if (WithingAttackRange() && enemy.PlayerDetected())
        {

            statemachine.ChangeState(enemy.AttackState);
            return;
        }

        //// Handle retreat BEFORE normal movement
        if (EnemyRetreat())
        {
        
            // Enemy moves away from player if the player is too close 
            rb.linearVelocity = new Vector2(enemy.Retreat.x * -DirectionToPlayer(), enemy.Retreat.y);
            enemy.handleFlip(DirectionToPlayer());
            statemachine.ChangeState(enemy.AttackState);
            return;
        }

        if (verticalDistance() > verticalThreshold)
        {
            // Enemy stands still or idle waiting to avoid rapid change of state from attack to idle
           
            enemy.IdleStateRecieverco(IdleStateholdDuration);
            return;

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
    private bool EnemyRetreat() => DistanceToPlayer() < enemy.minRetreatDistance;
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


