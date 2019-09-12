using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    List<GameObject> ropeContainer;

    [SerializeField] GameObject prefab, beginHandle, endHandle;
    [SerializeField] int lenght;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject current = Instantiate(prefab, transform);

        if (beginHandle == null)
            beginHandle = current;

        current.GetComponent<SpringJoint2D>().connectedBody = beginHandle.GetComponent<Rigidbody2D>();

        for(int i = 0; i < lenght; i++) {
            GameObject previous = current;
            current = Instantiate(prefab, transform);
            current.GetComponent<SpringJoint2D>().connectedBody = previous.GetComponent<Rigidbody2D>();
        }

        if (endHandle == null)
            endHandle = current;


        
        current.AddComponent<SpringJoint2D>().connectedBody = endHandle.GetComponent<Rigidbody2D>();
        current.GetComponents<SpringJoint2D>()[1].distance = current.GetComponents<SpringJoint2D>()[0].distance;
        current.GetComponents<SpringJoint2D>()[1].autoConfigureDistance = current.GetComponents<SpringJoint2D>()[0].autoConfigureDistance;
        current.GetComponents<SpringJoint2D>()[1].frequency = current.GetComponents<SpringJoint2D>()[0].frequency;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
