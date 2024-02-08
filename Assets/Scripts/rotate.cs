using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float spinSpeed = 3;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate (new Vector3 (0, 30, 0) * (Time.deltaTime * spinSpeed));
    }

    private void OnCollisionEnter(Collision other)
    {
        spinSpeed *= 2;
    }
}
