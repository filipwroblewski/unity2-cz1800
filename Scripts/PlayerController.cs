using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;

    float ruchPrzodTyl;
    float ruchLewoPrawo;
    Vector3 ruch;

    float predkoscPoruszania = 5.0f;
    float predkoscBiegania = 2.0f;
    float aktualnaWysokoscSkoku = 0.0f;
    float wysokoscSkoku = 5.0f;

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

        ruchPrzodTyl = Input.GetAxis("Vertical") * predkoscPoruszania;
        ruchLewoPrawo = Input.GetAxis("Horizontal") * predkoscPoruszania;

        // Sprint
        if (Input.GetKeyDown("left shift"))
        {
            // predkoscPoruszania = ruchPrzodTyl * predkoscBiegania;
            predkoscPoruszania = ruchPrzodTyl * predkoscBiegania;
        }
        else if (Input.GetKeyUp("left shift"))
        {
            predkoscPoruszania = ruchPrzodTyl / predkoscBiegania;
        }

        // characterController.isGrounded
        // and &&, or ||
        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            aktualnaWysokoscSkoku = wysokoscSkoku;
        }else if (!characterController.isGrounded)
        {
            Debug.Log("Postac w powietrzu");
        }

        ruch = new Vector3(ruchLewoPrawo, aktualnaWysokoscSkoku, ruchPrzodTyl);
        ruch = transform.rotation * ruch;

        characterController.Move(ruch * Time.deltaTime);

        
        
        
        


        //Debug.Log(ruch);
    }
}
