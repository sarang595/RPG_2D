using UnityEngine;

public class Enemy_Vfx : Entity_Vfx
{
    [Header("Counter Attack Window")]
    [SerializeField] private GameObject AttackAlert;

    public void EnableAttackAlert(bool enable)
    {
        AttackAlert?.SetActive(enable);
    }
}
