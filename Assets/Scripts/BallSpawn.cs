using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject powerupPrefab;
    public Transform ballSpawnTransform;
    
    public Vector3 currVelocity;
    public float bounceSpeedVariable = 3f;

    public float startingForceMultiply = 3;
    // Start is called before the first frame update
    public void Start()
    {
        float randomPos = Random.Range(0, 12);
        float randomPos1 = Random.Range(0, 12);
        Vector3 position = new Vector3(ballSpawnTransform.position.x - randomPos, ballSpawnTransform.position.y, ballSpawnTransform.position.z);
        Vector3 position1 = new Vector3(ballSpawnTransform.position.x - randomPos1, ballSpawnTransform.position.y, ballSpawnTransform.position.z + 2);

        Object newBall = Instantiate(ballPrefab, position, Quaternion.identity);
        Object newUp = Instantiate(powerupPrefab, position1, Quaternion.identity);

        Vector3 startingVelocity = new Vector3(0, 0, -1 * startingForceMultiply);
        newBall.GetComponent<Rigidbody>().velocity = startingVelocity;
    }
}
