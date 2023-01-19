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
            if (true) // czy kursor jest widoczny
            {
                // schowaj kursor
            }
            else
            {
                // pokaz kursor
            }

            // if Locked
                // Confined
            // else
                // Locked
        }
    }
}
