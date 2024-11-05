using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandObjSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float startTime;
    public float timer;
    public float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        timer = startTime;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
