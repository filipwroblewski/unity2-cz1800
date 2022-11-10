using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Skok: " + Input.GetButton("Jump"));
        Debug.Log("Lewo/Prawo: " + Input.GetAxis("Horizontal"));
        Debug.Log("Przod/Tyl: " + Input.GetAxis("Vertical"));

        Debug.Log("Czy na ziemi? " + characterController.isGrounded);
    }
}
