using UnityEngine;

public class nowySkryptNaPoruszanie : MonoBehaviour
{
    [SerializeField] float turnSpeed = 4.0f;
    [SerializeField] float movementSpeed = 2.0f;
    [SerializeField] float closestRange = 2.0f;
    [SerializeField] float range = 30.0f;

    Transform enemy;
    Transform player;

    Vector3 playerXYZ;

    Rigidbody rgbd;

    bool lookAtPlayer;
    [SerializeField] bool smoothTurn = true;

    void Start()
    {
        enemy = transform;
        rgbd = GetComponent<Rigidbody>();

        if (rgbd)
        {
            rgbd.freezeRotation = true;
        }
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerXYZ = new Vector3(player.position.x, enemy.position.y, player.position.z);

        lookAtPlayer = false;

        float distance = Vector3.Distance(enemy.position, playerXYZ);
        if (distance <= range && distance > closestRange && !isDead())
        {
            lookAtPlayer = true;
            enemy.position = Vector3.MoveTowards(enemy.position, playerXYZ, movementSpeed * Time.deltaTime);
        }else if (distance <= closestRange && !isDead())
        {
            lookAtPlayer = true;
        }

        lookAtMe();
    }

    void lookAtMe()
    {
        if(lookAtPlayer == true && !smoothTurn)
        {
            enemy.LookAt(playerXYZ);
        }else if(lookAtPlayer == true && smoothTurn)
        {
            Quaternion rotation = Quaternion.LookRotation(player.position - enemy.position);
            enemy.rotation = Quaternion.Slerp(enemy.rotation, rotation, turnSpeed * Time.deltaTime);
        }
    }

    bool isDead()
    {
        Health hp = gameObject.GetComponent<Health>();
        if(hp != null)
        {
            return hp.isAlive();
        }
        else
        {
            return false;
        }
    }
}
