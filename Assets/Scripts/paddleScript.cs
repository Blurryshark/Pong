using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using Random = UnityEngine.Random;

public class paddleScript : MonoBehaviour
{
    public float unitsPerSecond = 3f;
    public float originalSize = 8f;
    public GameObject camera;
    private Transform camTransform;
    public float frequency = 25;
    
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();
         camTransform = camera.GetComponent<Transform>();
    }

    private void OnCollisionEnter(Collision other)
    {
        
        // if (other.gameObject.name == "Cube(Clone)")
        // {
        //     
        //     camShake();
        //     Debug.Log("impacted " + other.gameObject.name);
        //     AudioSource src = GetComponent<AudioSource>();
        //     src.Play();
        // }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.name == "LeftPaddle")
        {
            float horizontalValue = Input.GetAxis("Horizontal") * unitsPerSecond;
            Vector3 force = Vector3.right * horizontalValue;
            
            rb.AddForce(force, ForceMode.VelocityChange);

        }

        if (gameObject.name == "RightPaddle")
        {
            float horizontalValue = Input.GetAxis("Vertical") * unitsPerSecond;
            Vector3 force = Vector3.right * horizontalValue;
            
            rb.AddForce(force, ForceMode.VelocityChange);
        }

        
        // Transform t = GetComponent<Transform>();
        // t.position += Vector3.right * horizontalValue * unitsPerSecond * Time.deltaTime;

    }

    private void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.UpArrow) ||
            Input.GetKeyUp(KeyCode.DownArrow))
        {
            Vector3 zero = new Vector3(0,0,0);
            rb.velocity = zero;
            //Debug.Log("Key Up!");
            // Vector3 opposite = -rb.velocity;
            // rb.AddForce(opposite, ForceMode.VelocityChange);
        }
        
    }
    
}