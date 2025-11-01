using UnityEngine;
using UnityEngine.UIElements;
[System.Serializable]
public class ParallaxLayer
{
    [SerializeField] private Transform Background;
    [SerializeField] private float ParallaxMultiplier;
    [SerializeField] private float ParallaxImageOffset;
    private float ImageFullWidth;
    private float ImageHalfWidth;

    public void CalculateImageWidth()
    {
        ImageFullWidth = Background.GetComponent<SpriteRenderer>().bounds.size.x;
        ImageHalfWidth = ImageFullWidth / 2;
    }
    public void Move(float DistanceToMove)
    {
        Background.position += Vector3.right * (DistanceToMove * ParallaxMultiplier);
    }

    public void LoopBackground(float CameraLeftEdge,  float CameraRightEdge)
    {
        float ImageLeftEdge = (Background.position.x - ImageHalfWidth) + ParallaxImageOffset;
        float ImageRightEdge = (Background.position.x + ImageHalfWidth) - ParallaxImageOffset;
        if(ImageRightEdge < CameraLeftEdge)
        {
            Background.position += Vector3.right * ImageFullWidth;
        }
        if(ImageLeftEdge > CameraRightEdge)
        {
            Background.position += Vector3.right * - ImageFullWidth;
        }


    }
}
