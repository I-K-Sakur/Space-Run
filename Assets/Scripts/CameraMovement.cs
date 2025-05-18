using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float roatationSpeed = 5f;

    private float mouseX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * roatationSpeed;
        transform.Rotate(Vector3.up, roatationSpeed * Time.deltaTime);
    }
}
