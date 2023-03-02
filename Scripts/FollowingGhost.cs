using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingGhost : MonoBehaviour
{
    private Transform player;
    private Transform enemy;

    private float turnSpeed = 5.0f; // predkosc obrotu Enemy
    private float movementSpeed = 5.0f; // predkosc poruszania sie Enemy
    private float range = 25.0f; // zasieg widzenai Enemy
    private float closestRange = 2.0f; // jak blisko moze podesjc Enemy do Player

    // Start is called before the first frame update
    void Start()
    {
        enemy = transform;
        GameObject gameObject = GameObject.FindWithTag("Player");
        player = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // obliczenie dystansu od gracza
        float distance = Vector3.Distance(enemy.position, player.position);

        // v1
        if (distance < range && distance > closestRange) // jezeli Player bedzie w zasiegu wzorku Enemy i Enemy nie jest za blisko Player
        {
            enemy.rotation = Quaternion.Slerp(enemy.rotation, Quaternion.LookRotation(player.position - enemy.position), 4.0f * Time.deltaTime);
            enemy.position += enemy.forward * 2.0f * Time.deltaTime; 
        }
        
        
        // v2
        if (distance < range) // jezeli Player bedzie w zasiegu wzorku Enemy
        {
            if (distance > closestRange) // Enemy nie jest za blisko Player
            {
                enemy.rotation = Quaternion.Slerp(enemy.rotation, Quaternion.LookRotation(player.position - enemy.position), 4.0f * Time.deltaTime);
                enemy.position += enemy.forward * 2.0f * Time.deltaTime;
            }
        }
    }
}
