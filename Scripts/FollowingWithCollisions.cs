using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingWithCollisions : MonoBehaviour
{
    private float range = 25.0f; // zasieg widzenai Enemy
    private float closestRange = 2.0f; // jak blisko moze podesjc Enemy do Player

    Transform enemy; // zmienna Enemy Transform
    CharacterController enemyController; // zmienna Enemy Character Controller
    Transform player; // zmienna Player Transform

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

        if (distance < range && distance > closestRange) // jezeli Player bedzie w zasiegu wzorku Enemy i Enemy nie jest za blisko Player
        {
            
        }

        Debug.Log(distance);
    }

}
