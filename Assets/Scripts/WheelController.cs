using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    public float acceleration = 500f;
    public float brakingForce = 300f;
    public float horizontalForce = 10f;

    private float currentAcceleration = 0f;
    private float currentBrakingForce = 0f;

    private Rigidbody rb;

    private void Start()
    {
        SetupWheelCollider(frontRight);
        SetupWheelCollider(frontLeft);
        SetupWheelCollider(backRight);
        SetupWheelCollider(backLeft);

        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.9f, 0);
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    private void SetupWheelCollider(WheelCollider wheel)
    {
        wheel.suspensionDistance = 0.2f;

        // Setup friction
        WheelFrictionCurve forwardFriction = wheel.forwardFriction;
        forwardFriction.stiffness = 0.5f;  
        wheel.forwardFriction = forwardFriction;

        WheelFrictionCurve sidewaysFriction = wheel.sidewaysFriction;
        sidewaysFriction.stiffness = 0.5f;  
        wheel.sidewaysFriction = sidewaysFriction;

        // Setup suspension spring
        JointSpring suspensionSpring = wheel.suspensionSpring;
        suspensionSpring.spring = 10000;  
        suspensionSpring.damper = 3000;  
        wheel.suspensionSpring = suspensionSpring;
    }

    private void FixedUpdate()
    {
        // Get forward/reverse acceleration from the vertical axis (W and S keys)
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        // If we're pressing space, give currentBrakingForce a value
        if (Input.GetKey(KeyCode.Space))
        {
            currentBrakingForce = brakingForce;
        }
        else
        {
            currentBrakingForce = 0f;
        }

        // Apply acceleration to front wheels
        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        // Apply braking force to all wheels
        frontRight.brakeTorque = currentBrakingForce;
        frontLeft.brakeTorque = currentBrakingForce;
        backRight.brakeTorque = currentBrakingForce;
        backLeft.brakeTorque = currentBrakingForce;

        // Apply horizontal force for left/right movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 horizontalForceVector = transform.right * horizontalInput * horizontalForce;
        rb.AddForce(horizontalForceVector, ForceMode.Acceleration);
    }
}