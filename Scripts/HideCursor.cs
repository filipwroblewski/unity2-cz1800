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
        int a = 1;
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Cursor.visible)
            {
                Debug.Log("widac kursor");
            }
        }
        else if (a == 2)
        {
            Debug.Log("a jest rowne 2");
        }
        else
        {
            Debug.Log("a nie jest rowne 1");
        }
    }
}
