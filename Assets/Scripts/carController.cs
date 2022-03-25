using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;
    private bool flagBreak = false;
    private bool delay = false;
    private float lastAngle;
    private int contador = 0;
    private float timer = 0.0f;
    private float timer2 = 0.0f;
    private bool i_Fall = false;
    private bool i_crash = false;
    private GameObject car;
 

    private float positionXC;
    private float positionYC;
    private float positionZC;


    private Transform auxWheel;
    private Transform auxWheel2;
    private Transform auxWheel3;
    private Transform auxWheel4;

    public WheelCollider frontLeftWheelCollider1;
    public WheelCollider frontRightWheelCollider2;
    public WheelCollider rearLeftWheelCollider3;
    public WheelCollider rearRightWheelCollider4;


    public float motorForce;
    public float breakForce;
    public float maxSteerAngle;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;

    public Transform frontLeftWheelTransform;
    public Transform frontRightWheeTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    private void FixedUpdate()
    {
        
        timer2 += Time.deltaTime;
        int secondsTimer2 = (int)(timer2 % 60);
        if(secondsTimer2 == 10)
        {

            car = GameObject.FindGameObjectWithTag("Car");
            positionXC = car.transform.position.x;
            positionYC = car.transform.position.y;
            positionZC = car.transform.position.z;

            Debug.Log("PASO 10 ");
            timer2 = 0;
        }

        if (flagBreak)
        {
           timer += Time.deltaTime;
            contador = (int)(timer % 60);
            //Debug.Log("Este es el timer" + timer + " SEG: " + contador);
           if(contador == 4)
            {
                flagBreak = false;
                timer = 0;
                motorForce = 850;
            }
        }
        bool not_fall = !i_Fall;
        bool not_crash = !i_crash;
        if(not_fall && not_crash)
        {
            GetInput();
            HandleMotor();
            HandleSteering();
            UpdateWheels();
        }
        else if(i_Fall && not_crash)
        {
            Debug.Log("Entre");
            i_Fall = false;
            Vector3 pos;
            pos = new Vector3(positionXC, positionYC + 3, positionZC);
            car.transform.position = pos;

            car.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }
        else if(not_fall && i_crash)
        {
            Debug.Log("CHOQUE");
            i_crash = false;
            Vector3 pos;
            pos = new Vector3(-127.5339f, 4.31f, 32.63526f);
            car.transform.position = pos;

            car.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }

    }


    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
       
        if(!delay)
        {
            lastAngle = horizontalInput;
        }
        delay = true;
        
        print(lastAngle);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
        if(flagBreak)
        {
            isBreaking = true;
        }
        Debug.Log("Breaking " + isBreaking);
    }

    private void HandleMotor()
    {
        Debug.Log(motorForce);
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
       
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        /*if(!delay)
        {
            currentSteerAngle = maxSteerAngle * horizontalInput;
        }
        else if(lastAngle > 0 && horizontalInput > 0)
        {
            currentSteerAngle = maxSteerAngle * horizontalInput;
        }
        else if(lastAngle < 0 && horizontalInput < 0)
        {
            currentSteerAngle = maxSteerAngle * horizontalInput;
        }
        else
        {
            horizontalInput = lastAngle;
            currentSteerAngle = maxSteerAngle * horizontalInput;
        }*/
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "reduce" && flagBreak == false)
        {
            print("COLLIDER");
            motorForce = 100;
            flagBreak = true;
        }
        else if(other.tag == "LimitofTheMap")
        {
            Debug.Log("LIMIT REACH");
            i_Fall = true;
        }
        else if(other.tag == "FinalWall")
        {
            Debug.Log("PARED DEL FINAL");
            i_crash = true;
        }
    }
}
