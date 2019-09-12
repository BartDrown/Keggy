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

        current.AddComponent<DistanceJoint2D>().connectedBody = endHandle.GetComponent<Rigidbody2D>();
        current.GetComponents<DistanceJoint2D>()[1].distance = current.GetComponents<DistanceJoint2D>()[0].distance;
    }
}
