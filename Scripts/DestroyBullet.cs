using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    [SerializeField] float duration = 5f;

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;

        if (duration < 0)
        {
            Destroy(gameObject);
        }
    }
}
