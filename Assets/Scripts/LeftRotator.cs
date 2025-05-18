using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRotator : MonoBehaviour
{
    private RotatorRotation rotatorRotation;
    // Start is called before the first frame update
    void Start()
    {
        rotatorRotation = GetComponent<RotatorRotation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rotatorRotation != null)
        {
            rotatorRotation.RotateUp();
        }
    }
}
