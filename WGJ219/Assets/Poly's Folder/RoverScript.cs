using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoverScript : MonoBehaviour
{
    public Text commandInput;
    public InputField commandInputField;
    public TMP_Text activeCommandText;
    public Text currentTorqueText;
    public TextContainer test;
    public Rigidbody rb;
    public bool moveForwards;
    public bool moveBackwards;
    public bool turnRight;
    public bool turnLeft;
    public float turnTorque = 0;
    public float wheelTorque = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        turnTorque = 0;
        wheelTorque = 0;
    }

    public void AdjustTorque(float newTorque)
    {
        turnTorque = newTorque;
        wheelTorque = newTorque;
        float newTorqueToDisplay;
        newTorqueToDisplay = newTorque * 150;
        currentTorqueText.text = newTorqueToDisplay.ToString() ;
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
            activeCommandText.text = ("Stopping");
            moveForwards = false;
            moveBackwards = false;
            turnLeft = false;
            turnRight = false;
        }
        else if (commandInput.text.ToLower() == ("forwards"))
        {
            Debug.Log("Forward");
            activeCommandText.text = ("Moving Forwards");
            moveForwards = true;
            moveBackwards = false;
            turnRight = false;
            turnLeft = false;
        }
        else if (commandInput.text.ToLower() == ("backwards"))
        {
            Debug.Log("Backwards");
            activeCommandText.text = ("Moving Backwards");
            moveBackwards = true;
            moveForwards = false;
            turnRight = false;
            turnLeft = false;
        }
        else if (commandInput.text.ToLower() == ("turnright"))
        {
            activeCommandText.text = ("Turning Right");
            Debug.Log("Turning Right");
            turnRight = true;
            turnLeft = false;
            moveBackwards = false;
            moveForwards = false;
        }
        else if (commandInput.text.ToLower() == ("turnleft"))
        {
            Debug.Log("Turning Left");
            activeCommandText.text = ("Turning Left");
            turnLeft = true;
            turnRight = false;
            moveBackwards = false;
            moveForwards = false;
        }
        else
        {
            Debug.Log("Something went wrong");
        }
        commandInputField.Select();
        commandInputField.text = ("");
    }
    

}
