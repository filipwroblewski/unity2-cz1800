using UnityEngine;

public class FollowingWithCollisions : MonoBehaviour
{
    [SerializeField] float range = 25.0f; // zasieg widzenai Enemy
    [SerializeField] float closestRange = 3.0f; // jak blisko moze podesjc Enemy do Player

    Transform enemy; // zmienna Enemy Transform
    CharacterController enemyController; // zmienna Enemy Character Controller
    Transform player; // zmienna Player Transform

    [SerializeField] float turnSpeed = 4.0f; // predkosc obrotu
    [SerializeField] float currentJumpHight = 0.0f; // aktualna wysokosc skoku
    [SerializeField] float movementSpeed = 2.0f; // predkosc ruchu Enemy

    [SerializeField] bool isGhost = true;

    void Start()
    {
        enemyController = GetComponent<CharacterController>(); // pobranie od Enemy komponentu Character Controller
        enemy = GetComponent<Transform>(); // pobranie komponentu Transform od Enemy
        
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.transform; // pobranie komponentu Transform od Player-a
    }

    void Update()
    {
        float distance = Vector3.Distance(enemy.position, player.position);

        // jezeli Player bedzie w zasiegu wzorku Enemy i Enemy nie jest za blisko Player
        if (distance < range && distance > closestRange) 
        {
            turn();
            checkIfGrounded();
            checkIfGhost();
        }
    }

    void turn()
    {
        //Vector3 playerPosition = new Vector3(player.position.x, enemy.position.y, player.position.z);
        Quaternion lookRotation = Quaternion.LookRotation(player.position - enemy.position);
        enemy.rotation = Quaternion.Slerp(enemy.rotation, lookRotation, turnSpeed * Time.deltaTime);
    }

    void checkIfGrounded()
    {
        // sprawdzenie czy postac jest na ziemi
        if (!enemyController.isGrounded)
            currentJumpHight = currentJumpHight + Physics.gravity.y * Time.deltaTime;
    }

    void checkIfGhost()
    {
        // poruszanie sie jako duch lub nie
        if (!isGhost) // isGhost == false -> isGhost != true -> !isGhost
        {
            Vector3 movementVector = new Vector3(enemy.forward.x, currentJumpHight, enemy.forward.z);
            enemyController.Move(movementVector * movementSpeed * Time.deltaTime);
        }
        else
            enemy.position += enemy.forward * movementSpeed * Time.deltaTime;
    }

}
