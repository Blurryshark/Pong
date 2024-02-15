using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wall : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Cube(Clone)")
        {
            Debug.Log("impact");
            AudioSource src = GetComponent<AudioSource>();
                    src.Play();
        }
    }
}
