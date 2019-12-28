using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraScript : MonoBehaviour
{
    [SerializeField] private string mouseXName, mouseYName;
    [SerializeField] private float mouseSens;
    public bool cursorLocked;
    public float dist;
    public Transform chair;
    public bool isNearChair;
    public GameObject player;
    public bool isSitting;
    public bool exitSeat;
    public GameObject seatText;
    public GameObject seatExitText;


    [SerializeField] Transform pBody;

    float xAxisClamp;

    void Awake()
    {
        LockCursor();
        xAxisClamp = 0;
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        cursorLocked = false;
        mouseSens = 0;
    }
    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cursorLocked = true;
        mouseSens = 150;
    }

    public string playerLookAtTag;
    private void Update()
    {
        dist = Vector3.Distance(chair.position, transform.position);
        CamRotate();
        if (Input.GetMouseButtonDown(1) && cursorLocked == true)
        {
            UnlockCursor();
        }
        else if (Input.GetMouseButtonDown(1) && cursorLocked == false)
        {
            LockCursor();
        }

        //Chair Interactions
        RaycastHit playerLookAt;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out playerLookAt, Mathf.Infinity))
        {
            playerLookAtTag = playerLookAt.transform.tag;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * playerLookAt.distance, Color.green);
        }

        //Chair Interactions
        if (playerLookAt.transform.name == ("Chair") && dist <= 2.5f && !isSitting)
        {
            isNearChair = true;
            seatText.active = true;
            seatExitText.active = false;
        }
        else if (playerLookAt.transform.name == ("Chair") && dist <= 2.5f && isSitting)
        {
            isNearChair = true;
            seatText.active = false;
            seatExitText.active = true;
        }
        else
        {
            isNearChair = false;
            seatText.active = false;
            seatExitText.active = false;
        }
        if (Input.GetKeyDown(KeyCode.F) && isNearChair && !isSitting)
        {
            isSitting = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && isNearChair && isSitting)
        {
            isSitting = false;
            exitSeat = true;
        }
    }
    // Update is called once per frame
    void CamRotate()
    {
        float mouseX = Input.GetAxis(mouseXName) * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYName) * mouseSens * Time.deltaTime;

        xAxisClamp += mouseY;

        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0f;
            ClampXAxisValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0f;
            ClampXAxisValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        pBody.Rotate(Vector3.up * mouseX);
    }

    void ClampXAxisValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
