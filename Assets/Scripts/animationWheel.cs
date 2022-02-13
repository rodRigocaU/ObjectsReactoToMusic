using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationWheel : MonoBehaviour
{
    // Start is called before the first frame update
    int rotationAngle;
     void Start()
    {
       rotationAngle = 10;    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newRotation = new Vector3(-rotationAngle, -45,0);
        this.transform.eulerAngles = newRotation;
        rotationAngle += 5;
        if(rotationAngle > 360)
        {
            rotationAngle = 5;
        }
    }
}
