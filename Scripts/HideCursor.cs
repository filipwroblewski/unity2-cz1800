using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Confined
        Cursor.visible = false; // true
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Cursor.visible) // czy kursor jest widoczny
            {
                Debug.Log("schowaj kursor");
                Cursor.visible = false;
            }
            else
            {
                Debug.Log("pokaz kursor");
                Cursor.visible = true;
            }

            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Debug.Log("kursor Locked");
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Debug.Log("kursor Confined");
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
