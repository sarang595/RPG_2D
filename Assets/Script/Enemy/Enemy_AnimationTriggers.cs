using UnityEngine;

public class Enemy_AnimationTriggers : Entity_AnimationTrigger
{
    private Enemy_Vfx enemyfx;
    private Enemy enemy;
    protected override void Awake()
    {
        base.Awake();
        enemy = GetComponentInParent<Enemy>();
        enemyfx = GetComponentInParent<Enemy_Vfx>();
    }

    private void enableCounterWindow()
    {
        enemyfx.EnableAttackAlert(true);
        enemy.EnableCounterWindow(true);
    }
    private void disableCounterWindow()
    {
        enemyfx.EnableAttackAlert(false);
        enemy.EnableCounterWindow(false);
    }

}
