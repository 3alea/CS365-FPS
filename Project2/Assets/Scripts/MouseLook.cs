using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 500F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationX = 0F;
    float rotationY = 0F;

    Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.localRotation;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        rotationY += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        rotationX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);
        Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
        
        transform.localRotation = originalRotation * xQuaternion * yQuaternion;
    }


}