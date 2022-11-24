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

        ruch = new Vector3(ruchLewoPrawo, 0, ruchPrzodTyl);
        ruch = transform.rotation * ruch;

        characterController.Move(ruch * Time.deltaTime);

        if (Input.GetKeyDown("left shift"))
        {
            Debug.Log("Chodzenie -> Bieganie");
        }
        else if (Input.GetKeyUp("left shift"))
        {
            Debug.Log("Bieganie -> Chodzenie");
        }
        
        
        


        //Debug.Log(ruch);
    }
}
