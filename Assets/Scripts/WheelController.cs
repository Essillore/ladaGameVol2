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

    private float currentAcceleration = 0f;
    private float currentBrakingForce = 0f;

    private void FixedUpdate()
    {
        //get forward/reverse acceleration from the vertical axis (W and S keys)
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
        

    
    

        //Apply acceleration to front wheels
        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        // Apply braking force to all wheels

   //     frontRight.breakTorque = currentBrakingForce;
   //     frontLeft.brakeTorque = currentBrakingForce;
   //     backRight.brakeTorgue = currentBrakingForce;
   //     backLeft.brakeTorque = currentBrakingForce;
    }

}
