using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingGhost : MonoBehaviour
{
    private Transform player;
    private Transform enemy;

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
        
    }
}
