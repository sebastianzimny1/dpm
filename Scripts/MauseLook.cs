using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MauseLook : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public Transform player;

    public float lookUpMax = 50;
    public float lookUpMin = -50;

    private float rotateX;
    private float rotateY;
    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {     
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        rotateY = Mathf.Clamp(pitch, lookUpMin, lookUpMax);
        transform.eulerAngles = new Vector3(rotateY, yaw, 0.0f);
    }
}
