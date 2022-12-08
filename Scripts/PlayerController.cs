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
        ruchPrzodTyl = Input.GetAxis("Vertical") * predkoscPoruszania;
        ruchLewoPrawo = Input.GetAxis("Horizontal") * predkoscPoruszania;

        // Do poprawienia: Postac nie porusza sie po klikniecu shift na poczatku gry
        // Sprint
        if (Input.GetKeyDown("left shift"))
        {
            predkoscPoruszania = ruchPrzodTyl * predkoscBiegania;
        }
        else if (Input.GetKeyUp("left shift"))
        {
            predkoscPoruszania = ruchPrzodTyl / predkoscBiegania;
        }

        // and &&, or ||
        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            aktualnaWysokoscSkoku = wysokoscSkoku;
        }else if (!characterController.isGrounded)
        {
            aktualnaWysokoscSkoku += Physics.gravity.y * Time.deltaTime; // aktualnaWysokoscSkoku = Physics.gravity.y * Time.deltaTime + aktualnaWysokoscSkoku;
        }

        ruch = new Vector3(ruchLewoPrawo, aktualnaWysokoscSkoku, ruchPrzodTyl);
        ruch = transform.rotation * ruch;

        characterController.Move(ruch * Time.deltaTime);
    }
}
