using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAlert : MonoBehaviour
{
    public bool colliderAlerted = false;
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            colliderAlerted = true;
        }
    }
}
