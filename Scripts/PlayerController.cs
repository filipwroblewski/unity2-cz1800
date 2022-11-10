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
        klawiatura();
    }

    void klawiatura()
    {
        /*Debug.Log("Skok: " + Input.GetButton("Jump"));
        Debug.Log("Lewo/Prawo: " + Input.GetAxis("Horizontal"));
        Debug.Log("Przod/Tyl: " + Input.GetAxis("Vertical"));

        Debug.Log("Czy na ziemi? " + characterController.isGrounded);*/

        float ruchPrzodTyl = Input.GetAxis("Vertical");
        float ruchLewoPrawo = Input.GetAxis("Horizontal");

        Vector3 ruch = new Vector3(ruchLewoPrawo, 0, ruchPrzodTyl);
        ruch = transform.position;
        characterController.Move(ruch * Time.deltaTime);

        //Debug.Log(ruch);
    }
}
