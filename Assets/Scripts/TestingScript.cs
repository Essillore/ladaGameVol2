using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    public float movementSpeed;
    public GameObject car; 
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = Time.deltaTime * 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(movementSpeed, 0, 0));
    }
}
