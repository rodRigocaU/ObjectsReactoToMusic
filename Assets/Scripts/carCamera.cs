using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carCamera : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    public float translateSpeed;
    public float rotationSpeead;

    // Update is called once per frame
    private void FixedUpdate()
    {
        handleTranslation();
        handleRotation();
    }

  
    private void handleTranslation()
    {
        var targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
    }

    private void handleRotation()
{
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeead * Time.deltaTime);
    }


}
