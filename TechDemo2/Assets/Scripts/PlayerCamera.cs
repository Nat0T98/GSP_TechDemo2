using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float SensX;
    public float SensY;

    public Transform Orientation;

    private float XRot;
    private float YRot;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * SensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * SensY;

        YRot += mouseX;
        XRot -= mouseY;
        XRot = Mathf.Clamp(XRot, -90f, 90f);

        transform.rotation = Quaternion.Euler(XRot, YRot, 0);
        Orientation.rotation = Quaternion.Euler(0, YRot, 0);
    }
}
