using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ballDaemon : MonoBehaviour
{
    public Rigidbody rb;
    public Transform t;
    public Vector3 currVelocity;
    public float bounceSpeedVariable = 3f;

    public float startingForceMultiply = 3;
    // Start is called before the first frame update
    void Start()
    {
        // // rb = GetComponent <Rigidbody>();
        // // t = GetComponent<Transform>();
        //
        // float randomPos = Random.Range(0,15) ;
        //
        // Vector3 position = t.position;
        // Vector3 startingVelocity = new Vector3(0, 0, -1 * startingForceMultiply );
        //
        // t.position = new Vector3(position.x - randomPos, position.y, position.z);
        // rb.velocity = startingVelocity;
    }

    
    // Update is called once per frame
    void Update()
    {
        currVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision other)
    {
        //float varRotate = paddleScript.paddleRef(other.transform.position, "RightPaddle");
        if (other.gameObject.name == "LeftPaddle" || other.gameObject.name == "RightPaddle")
        {
            float varRotate = (transform.position.x - other.transform.position.x) / 4;
            if (varRotate > 1)
            {
                varRotate = 1;
            }
            else if (varRotate < 0)
            {
                varRotate = varRotate * 1;
            }

            //Debug.Log(varRotate);
            Vector3 newVelocity = new Vector3(0, currVelocity.y, -currVelocity.z) * bounceSpeedVariable;
            //Debug.Log("rotating by " + varRotate * -40 + "!");
            if (other.gameObject.name == "LeftPaddle")
            {
                Vector3 newVec = Quaternion.AngleAxis(varRotate * -40, Vector3.up) * newVelocity;
                rb.velocity = newVec;
                return;
            }
            else
            {
                Vector3 newVec = Quaternion.AngleAxis(varRotate * 40, Vector3.up) * newVelocity;
                rb.velocity = newVec;
                return;
            }
            
            
            //rb.velocity = newVelocity;
        }
        else
        {
            Vector3 newVelocity = new Vector3(-currVelocity.x, currVelocity.y, currVelocity.z);
            rb.velocity = newVelocity;
        }
        
    }
}
