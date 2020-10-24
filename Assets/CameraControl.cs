using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public float sensitivity;

    public Transform Body;

    public float yRotation;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float X = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float Y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        yRotation -= Y;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
        Body.Rotate(Vector3.up * X);
    }
}
