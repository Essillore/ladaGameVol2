using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDriver : MonoBehaviour
{
    private CarDriver carDriver;

    private void Awake()
    {
        carDriver = GetComponent<CarDriver>();
    }
   
    void Start()
    {
        
    }

    private void Update()
    {
        float forwardAmount = 1;
        float turnAmount = 1f;

        carDriver.SetInputs(forwardAmount, turnAmount);
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    public void SetInputs(float forwardAmount, float turnAmount)

    {

    }

    public void ClearTurnSpeed()
    {

    }

   // public float GetSpeed()
 
    public void SetSpeedMax(float speedMax)
    {

    }
    public void SetTurnSpeedMax(float turnSpeedMax)
    {

    }

    public void SetTurnSpeedAcceleration(float turnSpeedAcceleration)
        {

        }
    public void StopCompletely()
    {

    }
}
