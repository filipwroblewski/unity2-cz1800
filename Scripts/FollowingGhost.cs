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

        // jezeli Player bedzie w zasiegu wzorku Enemy i Enemy nie jest za blisko Player
        if (true)
        {
            Debug.Log("Teraz ide");
        }
        
    }
}
