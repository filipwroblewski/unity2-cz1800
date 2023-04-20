using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] Texture2D crosshairImg;
    Rect position;
    
    void Start()
    {
        position = new Rect(
            Screen.width / 2,
            Screen.height / 2,
            crosshairImg.width,
            crosshairImg.height);
    }

    void OnGUI()
    {
        GUI.DrawTexture(position, crosshairImg);
    }
}
