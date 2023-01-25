using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TractorController2 : MonoBehaviour
{

    public int cowsCollected { get; private set; } = 0;
    public Vector3 startPosition;
    public UnityEvent<TractorController2> onCowCollected2;
    public UnityEvent<TractorController2> onFinish;
    public UnityEvent<TractorController2> onRollOver;
    public UnityEvent<TractorController2> onReset;
    private float horizontalInput;
    private float verticalInput;
    private float steerAngle;
    private bool isBreaking;
    private bool isStopped = false;
    private int timeStopped = 0;
    private Vector3 lastPosition;


    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    public float maxSteeringAngle = 30f;
    public float motorForce = 50f;
    public float brakeForce = 0f;

    public void Start()
    {
        lastPosition = startPosition;
    }

    public void cowCollected()
    {
        cowsCollected++;
        onCowCollected2.Invoke(this);
        startPosition = transform.position;
    }

    public void finish()
    {
        onFinish.Invoke(this);
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        if (Mathf.RoundToInt(transform.position.x) == Mathf.RoundToInt(lastPosition.x) && Mathf.RoundToInt(transform.position.y) == Mathf.RoundToInt(lastPosition.y) && Mathf.RoundToInt(transform.position.z) == Mathf.RoundToInt(lastPosition.z))
        {
            timeStopped++;
        }
        else
        {
            isStopped = false;
            lastPosition = transform.position;
            timeStopped = 0;
            onReset.Invoke(this);
        }

        if (!isStopped && timeStopped > 250)
        {
            isStopped = true;
            onRollOver.Invoke(this);
        }

        if (isStopped && Input.GetKey(KeyCode.R))
        {
            transform.position = startPosition;
            transform.rotation = Quaternion.identity;
            onReset.Invoke(this);
        }
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1.0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1.0f;
        }
        else
        {
            verticalInput = 0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1.0f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1.0f;
        }
        else
        {
            horizontalInput = 0f;
        }
        isBreaking = Input.GetKey(KeyCode.C);
    }

    private void HandleSteering()
    {
        steerAngle = maxSteeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }

    private void HandleMotor()
    {
        rearLeftWheelCollider.motorTorque = verticalInput * motorForce;
        rearRightWheelCollider.motorTorque = verticalInput * motorForce;

        brakeForce = isBreaking ? 3000f : 0f;
        frontLeftWheelCollider.brakeTorque = brakeForce;
        frontRightWheelCollider.brakeTorque = brakeForce;
        rearLeftWheelCollider.brakeTorque = brakeForce;
        rearRightWheelCollider.brakeTorque = brakeForce;
    }

    private void UpdateWheels()
    {
        UpdateWheelPos(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPos(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPos(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPos(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateWheelPos(WheelCollider wheelCollider, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        trans.rotation = rot;
        trans.position = pos;
    }

    public void Reset()
    {
        cowsCollected = 0;
        transform.position = startPosition;
    }

}