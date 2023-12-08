using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    public Transform Target;
    public float Distance = 5f;
    public float RotationSpeed = 3f;
    private float CurrentRotationX = 0f;
    private float CurrentRotationY = 0f;

    void Update()
    {
        float HorizontalInput = Input.GetAxis("Mouse X") * RotationSpeed;
        float VerticalInput = Input.GetAxis("Mouse Y") * RotationSpeed;
        CurrentRotationX -= VerticalInput;
        CurrentRotationX = Mathf.Clamp(CurrentRotationX, -80f, 80f);
        CurrentRotationY += HorizontalInput;
        Quaternion targetRotation = Quaternion.Euler(CurrentRotationX, CurrentRotationY, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        Vector3 dir = new Vector3(0, 0, -Distance);
        Quaternion rotation = Quaternion.Euler(CurrentRotationX, CurrentRotationY, 0);
        transform.position = Target.position + rotation * dir;
    }
}