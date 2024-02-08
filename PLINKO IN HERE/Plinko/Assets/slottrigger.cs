using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class slottrigger : MonoBehaviour
{
    public int slotNum;
    public int points;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.name} entered slot {slotNum} and scored {points} points");
        other.gameObject.SetActive(false);
    }
}
