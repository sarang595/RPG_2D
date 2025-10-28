using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Camera maincamera;
    private float LastCameraPosX;
    [SerializeField] private ParallaxLayer[] BackgroundLayer;

    private void Awake()
    {
        maincamera = Camera.main;
        LastCameraPosX = maincamera.transform.position.x;
    }
    private void FixedUpdate()
    {
        float CurrentCameraPosX = maincamera.transform.position.x;
        float DistanceToMove = CurrentCameraPosX - LastCameraPosX;
        LastCameraPosX = CurrentCameraPosX;
        foreach ( ParallaxLayer layer in BackgroundLayer )
        {
            layer.Move(DistanceToMove);
        }
        
    }


}
