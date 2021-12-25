using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdCamera : MonoBehaviour
{
    public Transform lookAt;
    public Transform camTrasnform;

    private Camera cam;
    private float distanceB = 6.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensivityX = 4.0f;
    private float sensivityY = 1.0f;


    private void Start()
    {
        camTrasnform = transform;
        cam = Camera.main;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
    }

    public void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 3, -distanceB);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTrasnform.position = lookAt.position + rotation * dir;
        camTrasnform.LookAt(lookAt.position);
    }

}
