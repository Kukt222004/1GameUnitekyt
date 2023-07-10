using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float rotorSpeed = 70.0f, speed =70f, zoomSpeed = 10f;

    private float _mult = 1f;

    public void Update()
    {
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

    }
}
