using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverManual : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 0.003f;
    [SerializeField] public float steerSpeed = 0.1f;

    [SerializeField] public float baseAcceleration = 0.001f;
    [SerializeField] public float acceleration = 0.001f;
    [SerializeField] public float decceleration = 0.001f;


    [SerializeField] public float maxSpeed = 5.1f;
    [SerializeField] public float minSpeed = -5.1f;

    float inputValue = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetInputValue();


        float steerAmount = Input.GetAxis("Horizontal") * -steerSpeed * Time.deltaTime;
        /* if (Input.GetAxis("Vertical") != 0)

            moveSpeed = moveSpeed + Input.GetAxis("Vertical");
        else if (Input.GetAxis("Vertical") == 0 && moveSpeed > 0)
            moveSpeed = moveSpeed - 100 * Time.deltaTime;
        else if (Input.GetAxis("Vertical") == 0 && moveSpeed < 0)
            moveSpeed = moveSpeed + 100 * Time.deltaTime; */

        
        Accelerate();

        Debug.Log(inputValue);


        float moveAmount = moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void Accelerate()
    {
        if ( inputValue != 0 && minSpeed <= moveSpeed && moveSpeed <= maxSpeed)
        {
            acceleration = baseAcceleration * inputValue;
            moveSpeed += acceleration *Time.deltaTime;
            

        }
        else if (inputValue == 0 && moveSpeed - decceleration > 0)
            moveSpeed -= decceleration;

        else if (inputValue == 0 && moveSpeed + decceleration < 0)
            moveSpeed += decceleration; 

        else
            moveSpeed = 0;
    }

    void SetInputValue()
    {
        if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Vertical") >= inputValue)
            inputValue = 1;

        else if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Vertical") <= inputValue)
            inputValue = -1;

        else
            inputValue = 0;

    }



}
