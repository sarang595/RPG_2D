using UnityEngine;
[System.Serializable]
public class ParallaxLayer
{
    [SerializeField] private Transform Background;
    [SerializeField] private float ParallaxMultiplier;
    
    public void Move(float DistanceToMove)
    {
        Background.position += Vector3.right * (DistanceToMove * ParallaxMultiplier);
    }

}
