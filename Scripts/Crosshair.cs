using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] Texture2D crosshairImg;
    Rect position;
    [SerializeField] bool show = true;
    
    void Start()
    {
        float halfWidth = (Screen.width - crosshairImg.width) / 2;
        float halfHeight = (Screen.height - crosshairImg.height) / 2;

        position = new Rect(
                halfWidth,
                halfHeight,
                crosshairImg.width,
                crosshairImg.height
            );
    }

    void OnGUI()
    {
        if (show)
        {
            GUI.DrawTexture(position, crosshairImg);
        }
    }
}
