using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;

    float ruchPrzodTyl;
    float ruchLewoPrawo;
    Vector3 ruch;

    public float predkoscPoruszania = 5.0f;
    public float predkoscBiegania = 3.0f;
    public float aktualnaWysokoscSkoku = 0.0f;
    public float wysokoscSkoku = 5.0f;

    float myszPrawoLewo;

    public float czuloscMyszki = 3.0f;
    public float myszGoraDol = 0.0f;
    public float myszZakresGoraDol = 90.0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        klawiatura();
        mysz();
    }

    void klawiatura()
    {
        ruchPrzodTyl = Input.GetAxis("Vertical") * predkoscPoruszania;
        ruchLewoPrawo = Input.GetAxis("Horizontal") * predkoscPoruszania;

        // Sprint
        if (Input.GetKeyDown("left shift"))
        {
            predkoscPoruszania += predkoscBiegania;
        }
        else if (Input.GetKeyUp("left shift"))
        {
            predkoscPoruszania -= predkoscBiegania;
        }

        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            aktualnaWysokoscSkoku = wysokoscSkoku;
        }else if (!characterController.isGrounded)
        {
            aktualnaWysokoscSkoku += Physics.gravity.y * Time.deltaTime;
        }

        ruch = new Vector3(ruchLewoPrawo, aktualnaWysokoscSkoku, ruchPrzodTyl);
        ruch = transform.rotation * ruch;

        characterController.Move(ruch * Time.deltaTime);
    }

    void mysz()
    {
        myszPrawoLewo = Input.GetAxis("Mouse X") * czuloscMyszki;
        transform.Rotate(0, myszPrawoLewo, 0);

        myszGoraDol -= Input.GetAxis("Mouse Y") * czuloscMyszki;
        myszGoraDol = Mathf.Clamp(myszGoraDol, -myszZakresGoraDol, myszZakresGoraDol);

        Camera.main.transform.localRotation = Quaternion.Euler(myszGoraDol, 0, 0);
    }
}
