using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class powerUpScript : MonoBehaviour
{
    
    private Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        float r = Random.Range(0, 255);
        float g = Random.Range(0, 255);
        float b = Random.Range(0, 255);
        other.GetComponent<Renderer>().material.color = new Color(r, g, b);
        rb = other.GetComponent<Rigidbody>();
        gameObject.SetActive(false);
        Debug.Log("powerup!");
        Vector3 newForce = rb.velocity * 3;
        rb.AddForce(newForce, ForceMode.Impulse);
        
    }
}
