using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Camera maincamera;
    private float LastCameraPosX;
    private float CameraHalfWidth;
    private float CameraRightEdge;
    private float CameraLeftEdge;
    [SerializeField] private ParallaxLayer[] BackgroundLayer;

    private void Awake()
    {
        maincamera = Camera.main;
        LastCameraPosX = maincamera.transform.position.x;
        CameraHalfWidth = maincamera.orthographicSize * maincamera.aspect;
        ImageWidthCalculation();
    }
    private void FixedUpdate()
    {
        ParallaxCalculation();

    }

    private void ParallaxCalculation()
    {
        float CurrentCameraPosX = maincamera.transform.position.x;
        float DistanceToMove = CurrentCameraPosX - LastCameraPosX;
        LastCameraPosX = CurrentCameraPosX;
        CameraRightEdge = CameraHalfWidth + CurrentCameraPosX;
        CameraLeftEdge = -CameraHalfWidth + CurrentCameraPosX;
        foreach (ParallaxLayer layer in BackgroundLayer)
        {
            layer.Move(DistanceToMove);
            layer.LoopBackground(CameraLeftEdge, CameraRightEdge);
        }
    }

    private void ImageWidthCalculation()
    {
        foreach ( ParallaxLayer layer in BackgroundLayer )
        {
            layer.CalculateImageWidth();
        }
    }

}
