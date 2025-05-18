using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed=200f;
    
    // Update is called once per frame
    void Update()
    {
        RotateUp();
    }

   public void  RotateUp()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
    public void  RotateDown()
    {
        transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
    }
    public void  RotateRight()
    {
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
    public void  RotateLeft()
    {
        transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
    }
}
