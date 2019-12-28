using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] string horiInputName;
    [SerializeField] string vertInputName;
    [SerializeField] float movementSpeed;
    public PlayerCameraScript pCS;
    public Transform teleportTargetTransform;
    public Transform teleportTargetTransformStanding;
    CharacterController charController;


    private void Awake()
    {
        charController = GetComponent<CharacterController>();

    }

    private void Update()
    {
        PMovement();
        if (pCS.isSitting == true)
        {
            this.transform.position = teleportTargetTransform.transform.position;
        }
        if (pCS.exitSeat == true)
        {
            this.transform.position = teleportTargetTransformStanding.transform.position;
            pCS.exitSeat = false;
        }
    }

    void PMovement()
    {
        float vertInput = Input.GetAxis(vertInputName) * movementSpeed;
        float horiInput = Input.GetAxis(horiInputName) * movementSpeed;

        Vector3 fMovement = transform.forward * vertInput;
        Vector3 RightMovement = transform.right * horiInput;

        charController.SimpleMove(fMovement + RightMovement);
    }




}
