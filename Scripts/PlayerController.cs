using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;

    float ruchPrzodTyl;
    float ruchLewoPrawo;
    Vector3 ruch;

    public float predkoscPoruszania = 5.0f;
    public float predkoscBiegania = 2.0f;
    public float aktualnaWysokoscSkoku = 0.0f;
    public float wysokoscSkoku = 5.0f;

    float myszPrawoLewo;

    public float czuloscMyszki = 3.0f;
    public float myszGoraDol = 0.0f;
    public float myszZakresGoraDol = 90.0f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        klawiatura();
        mysz();
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

    void mysz()
    {
        // Debug.Log("Ruch prawo i lewo: " + Input.GetAxis("Mouse X"));
        // Debug.Log("Ruch gora i dol: " + Input.GetAxis("Mouse Y"));
        myszPrawoLewo = Input.GetAxis("Mouse X") * czuloscMyszki;
        transform.Rotate(0, myszPrawoLewo, 0);

        myszGoraDol -= Input.GetAxis("Mouse Y") * czuloscMyszki;
        myszGoraDol = Mathf.Clamp(myszGoraDol, -myszZakresGoraDol, myszZakresGoraDol);

        Camera.main.transform.localRotation = Quaternion.Euler(myszGoraDol, 0, 0);
    }
}

