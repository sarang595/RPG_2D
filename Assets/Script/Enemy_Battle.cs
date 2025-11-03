using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Battle : EnemyState
{
    public Transform player;
    private float lastTimewasInBattle;
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
        }
        if(!WithingAttackRange() && enemy.WallDetected)
        {
            statemachine.ChangeState(enemy.IdleState);
        }
       
        if (WithingAttackRange() && enemy.PlayerDetected())
        {
            statemachine.ChangeState(enemy.AttackState);

        }
        if(RetreatEnemy())
        {
            enemy.SetVelocity(enemy.BattleRetreatvelocity.x * -DirectionToPlayer(), enemy.BattleRetreatvelocity.y);
            enemy.handleFlip(DirectionToPlayer());

        }

        else

        // Enemy have to move towards player
        enemy.SetVelocity(enemy.BattleSpeed * DirectionToPlayer(), rb.linearVelocity.y);
     
   
    }

    private void updateBattleTimer() => lastTimewasInBattle = Time.time;
    private bool BattleTimeisOver() => Time.time > lastTimewasInBattle + enemy.BattleTimeDuration;
    private bool WithingAttackRange() => DistanceToPlayer() <= enemy.AttackRange;
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
        if(player == null)
        {
            return 0;
        }
       return player.position.x > enemy.transform.position.x ? 1 : -1;
    }
   

}
