using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingWithCollisions : MonoBehaviour
{
    float range = 25.0f; // zasieg widzenai Enemy
    float closestRange = 2.0f; // jak blisko moze podesjc Enemy do Player

    Transform enemy; // zmienna Enemy Transform
    CharacterController enemyController; // zmienna Enemy Character Controller
    Transform player; // zmienna Player Transform

    float turnSpeed = 4.0f; // predkosc obrotu
    float currentJumpHight = 0.0f; // aktualna wysokosc skoku
    float movementSpeed = 2.0f; // predkosc ruchu Enemy

    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponent<CharacterController>(); // pobranie od Enemy komponentu Character Controller
        enemy = GetComponent<Transform>(); // pobranie komponentu Transform od Enemy
        
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.transform; // pobranie komponentu Transform od Player-a
    }

    // Update is called once per frame
    void Update()
    {
        // float, Vector3.Distance(pozycjaEnemy, pozycjaPlayer)
        float distance = Vector3.Distance(enemy.position, player.position);

        // jezeli Player bedzie w zasiegu wzorku Enemy i Enemy nie jest za blisko Player
        if (distance < range && distance > closestRange) 
        {
            Vector3 playerPosition = new Vector3(player.position.x, enemy.position.y, player.position.z);
            enemy.rotation = Quaternion.Slerp(enemy.rotation, Quaternion.LookRotation(player.position - enemy.position), turnSpeed * Time.deltaTime);
        }

        // sprawdzenie czy postac jest na ziemi
        if (!enemyController.isGrounded)
        {
            currentJumpHight = currentJumpHight + Physics.gravity.y * Time.deltaTime;
        }

        Vector3 movementVector = new Vector3(enemy.forward.x, currentJumpHight, enemy.forward.z);
        enemyController.Move(movementVector * movementSpeed * Time.deltaTime);
        

        Debug.Log(distance);
    }

}
