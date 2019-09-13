using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] GameObject prefab, beginHandle, endHandle;
    [SerializeField] int lenght;
    
    void Start()
    {
        GameObject current = Instantiate(prefab, transform);

        if (beginHandle == null)
            beginHandle = current;

        current.GetComponent<DistanceJoint2D>().connectedBody = beginHandle.GetComponent<Rigidbody2D>();

        for(int i = 0; i < lenght; i++) {
            GameObject previous = current;
            current = Instantiate(prefab, transform);
            current.GetComponent<DistanceJoint2D>().connectedBody = previous.GetComponent<Rigidbody2D>();
        }

        if (endHandle == null)
            endHandle = current;

        endHandle.AddComponent<DistanceJoint2D>().connectedBody = current.GetComponent<Rigidbody2D>();
        endHandle.GetComponent<DistanceJoint2D>().distance = current.GetComponent<DistanceJoint2D>().distance;
        endHandle.GetComponent<DistanceJoint2D>().autoConfigureDistance = current.GetComponent<DistanceJoint2D>().autoConfigureDistance;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.allCameras[0].ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                GameObject hookup = hit.collider.gameObject.GetComponent<DistanceJoint2D>().connectedBody?.gameObject;

                if (hookup != null)
                {
                    hookup.AddComponent<Hookup>();
                    hookup.GetComponent<Collider2D>().isTrigger = true;
                    hookup.GetComponent<BoxCollider2D>().size *= 3;
                    hookup.gameObject.name = "Hookup";
                }

                Destroy(hit.collider.gameObject);
            }
        }
    }
}
