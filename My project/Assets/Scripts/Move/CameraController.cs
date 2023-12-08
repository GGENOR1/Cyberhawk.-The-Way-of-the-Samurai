using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public Transform player;

    private float mouseX, mouseY;

    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
       // player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
