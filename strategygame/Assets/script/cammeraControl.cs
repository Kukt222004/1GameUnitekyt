using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float rotorSpeed = 70.0f, speed =70f, zoomSpeed = 10f;
    private float _mult = 1f;
    //float xRotation =0f;
    float camSens = 0.15f;
    private Vector3 lastMouse = new Vector3(255, 255, 255); 
    
    public void Update()
    {
        if (Input.GetMouseButton(1))
        {
            lastMouse = Input.mousePosition - lastMouse;
            lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
            lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
            transform.eulerAngles = lastMouse;
            lastMouse = Input.mousePosition;
        }
        _mult = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;

        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(hor, 0, ver) * Time.deltaTime * _mult * speed, Space.Self);

        float rotate = 0f;
        {
            if (Input.GetKey(KeyCode.Q))
                rotate = -1f;
            else if (Input.GetKey(KeyCode.E))
                rotate = 1f;
            transform.Rotate(Vector3.up * rotorSpeed * Time.deltaTime * rotate * _mult , Space.Self);
        }
        /*
        float mouseX = Input.GetAxis("Mouse X") * speed * _mult * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * speed * _mult * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation =Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);     */                                                                     
    }
}
