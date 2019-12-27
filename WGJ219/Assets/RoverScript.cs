using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoverScript : MonoBehaviour
{
    public Text commandInput;
    public TextContainer test;
    public Rigidbody rb;
    public bool moveForwards;
    public bool moveBackwards;
    public bool turnRight;
    public bool turnLeft;
    public float turnTorque;
    public float wheelTorque;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(moveForwards)
        {
            rb.AddForce(transform.forward * wheelTorque);
        }
        if (moveBackwards)
        {
            rb.AddForce(-transform.forward * wheelTorque);
        }
        if (turnLeft)
        {
            rb.AddTorque(transform.up * -turnTorque);
        }
        if (turnRight)
        {
            rb.AddTorque(transform.up * turnTorque);
        }
    }


    public void EnterCommand()
    {
        Debug.Log(commandInput.text.ToLower());
        if (commandInput.text.ToLower() == ("stop"))
        {
            Debug.Log("Stop");
            moveForwards = false;
            moveBackwards = false;
            turnLeft = false;
            turnRight = false;
        }
        else if (commandInput.text.ToLower() == ("forwards"))
        {
            Debug.Log("Forward");
            moveForwards = true;
            moveBackwards = false;
        }
        else if (commandInput.text.ToLower() == ("backwards"))
        {
            Debug.Log("Backwards");
            moveBackwards = true;
            moveForwards = false;
        }
        else if (commandInput.text.ToLower() == ("turnright"))
        {
            turnRight = true;
            turnLeft = false;
            Debug.Log("Turning Right");
        }
        else if (commandInput.text.ToLower() == ("turnleft"))
        {
            Debug.Log("Turning left");
            turnLeft = true;
            turnRight = false;
        }
        else
        {
            Debug.Log("Something went wrong");
        }
    }
    

}
