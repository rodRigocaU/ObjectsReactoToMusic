using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCha : MonoBehaviour
{
    public float speed = 0.001f;
    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirec = new Vector3(xDirection, 0.0f, zDirection);

        transform.position += moveDirec * speed;


    }
}
