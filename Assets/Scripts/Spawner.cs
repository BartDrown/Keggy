using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject barrel;
    [SerializeField]
    float spawnTime = 3f;
    
    void Start()
    {
        InvokeRepeating("SpawnBarrel", spawnTime, spawnTime);
    }

    void Update()
    {
    }
    void SpawnBarrel()
    {
        GameObject.Instantiate(barrel, transform.position, transform.rotation, gameObject.transform);
    }
}
