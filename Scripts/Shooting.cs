using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    float range = 100.0f;
    float delay = 1.0f;
    float dmg = 50.0f;

    float counter = 0.0f;
    
    // Update is called once per frame
    void Update()
    {
        if (counter < delay)
        {
            counter += Time.deltaTime;
        }

        if (Input.GetMouseButton(0) && counter >= delay)
        {
            counter = 0.0f;

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitInfo;

            // sprawdzenie co zostalo trafione i czy jest w naszym range
            if(Physics.Raycast(ray, out hitInfo, range))
            {
                // TODO: wczytanie pkt zrowia enemy
                

                GameObject go = hitInfo.collider.gameObject;
                Debug.Log($"Trafione: { go.name }");
                // TODO: wypisanie pkt zdrowia

                hit(go);

            }
        }
        
    }

    private void hit(GameObject go)
    {
        Health hp = go.GetComponent<Health>();

        // warunek jesli pkt. zdrowia sa to zadaj dmg
        if (hp != null)
        {
            hp.dmgDealt(50);
        }

    }
}
