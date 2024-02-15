using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnBehavior : MonoBehaviour
{
    public GameObject ball;

    public Transform spawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            int rand = Random.Range(0, 15);
            Vector3 spawnPosition = new Vector3(spawnLocation.position.x, spawnLocation.position.y, spawnLocation.position.z + rand);
            Instantiate(ball, spawnPosition, Quaternion.identity);
        }
    }
}
