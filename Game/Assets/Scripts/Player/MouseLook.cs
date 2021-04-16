using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour 
{
    public float mouseSensitivity = 100f;

    public transform playerBody;

    private void Start() 
    {

    }

    private void Update() 
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        playerBody.rotate(Vector3.up * mouseX);
    }

}
// To be continued