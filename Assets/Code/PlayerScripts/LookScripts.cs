using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookScripts : MonoBehaviour
{
    //Public Variables
    public bool isMouseLocked;
    public bool isFieldOfViewEnabled;
    public float cameraFovMin;
    public float cameraFovMax;
    public float fovIncrement;
    public float cameraRotateXMin;
    public float cameraRotateXMax;
    public float mouseSmoothing;
    public GameObject cameraObject;
    public bool walking = false;
    public bool running = false;

    //Private Variables
    private float mouseX;
    private float mouseY;
    private float rotateX;
    private float mouseScroll;
    private Transform parent;
    private float fov;
    private Camera camera;
    private float camPosition1;

    //unity routines
    private void Awake()
    {
        camera = Camera.main;
        parent = transform.parent;
        if (camera != null)
        {
            fov = camera.fieldOfView;
        }

        MouseLock();
    }

    private void Update()
    {
        MouseInputs();
        RotatePlayerY();
        CameraRotateX();
        CameraZoom();
    }

    //inputs
    private void MouseInputs()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSmoothing;
        mouseY = Input.GetAxis("Mouse Y") * mouseSmoothing;
        mouseScroll = Input.GetAxis("Mouse ScrollWheel");
    }

    //Sub Stuff
    private void RotatePlayerY()
    {
        parent.Rotate(Vector3.up * mouseX);
    }

    private void CameraRotateX()
    {
        rotateX += mouseY;
        rotateX = Mathf.Clamp(rotateX, cameraRotateXMin, cameraRotateXMax);
        camera.transform.localRotation = Quaternion.Euler(-rotateX, 0f, 0f);
    }

    private void MouseLock()
    {
        if (isMouseLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }

        Cursor.lockState = CursorLockMode.None;
    }

    private void CameraZoom()
    {
        if (isFieldOfViewEnabled)
        {
            if (mouseScroll > 0f)
            {
                {
                    if(fov + fovIncrement >= cameraFovMin && fov + fovIncrement <= cameraFovMax)
                    {
                        fov += fovIncrement;
                        camera.fieldOfView = fov;
                    }
                }
            }
            
            if (mouseScroll < 0f)
            {
                {
                    if (fov + fovIncrement >= cameraFovMin && fov + fovIncrement <= cameraFovMax)
                    {
                        fov -= fovIncrement;
                        camera.fieldOfView = fov;
                    }
                }
            }
        }
    }
}
