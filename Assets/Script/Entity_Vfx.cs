using System.Collections;
using UnityEngine;

public class Entity_Vfx : MonoBehaviour
{
    private SpriteRenderer Sr;
    [SerializeField] Material Vfxmat;
    [SerializeField] float VfxDuration;
    private Material OriginalMat;
    private Coroutine OnDamageVfx;

    private void Start()
    {
        Sr = GetComponentInChildren<SpriteRenderer>();
        OriginalMat = Sr.material;
    }

    public void PlayVfx()
    {
        if(OnDamageVfx != null)
        {
            StopCoroutine (OnDamageVfx);
        }
        OnDamageVfx = StartCoroutine(DamageVfxco());
    }

    private IEnumerator DamageVfxco()
    {
        Sr.material = Vfxmat;
        yield return new WaitForSeconds(VfxDuration);
        Sr.material = OriginalMat;
    }
}
