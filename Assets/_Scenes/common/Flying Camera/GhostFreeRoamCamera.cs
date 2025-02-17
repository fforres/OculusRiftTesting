﻿using UnityEngine;

[RequireComponent(typeof(Camera))]
public class GhostFreeRoamCamera : MonoBehaviour
{
    public float initialSpeed = 10f;
    public float increaseSpeed = 1.25f;

    public bool allowMovement = true;
    public bool allowRotation = true;

    public KeyCode forwardButton = KeyCode.W;
    public KeyCode backwardButton = KeyCode.S;
    public KeyCode rightButton = KeyCode.D;
	public KeyCode leftButton = KeyCode.A;
	public KeyCode upwardsButton = KeyCode.Space;
	public KeyCode downwardsButton = KeyCode.C;

    public float cursorSensitivity = 0.025f;
    public bool cursorToggleAllowed = true;
    public KeyCode cursorToggleButton = KeyCode.Escape;
	public KeyCode runKey = KeyCode.LeftShift;

    private float currentSpeed = 0f;
    private bool moving = false;
    private bool togglePressed = false;
	private int speedMultiplier = 1;
	private int speedMultiplierCurrent = 1;

    private void OnEnable()
    {
        if (cursorToggleAllowed)
        {
            Screen.lockCursor = true;
            Cursor.visible = false;
        }
    }

    private void Update()
    {



        if (allowMovement)
        {
            bool lastMoving = moving;
            Vector3 deltaPosition = Vector3.zero;

            if (moving)
				currentSpeed += increaseSpeed * Time.deltaTime;

            moving = false;

            CheckMove(forwardButton, ref deltaPosition, transform.forward);
            CheckMove(backwardButton, ref deltaPosition, -transform.forward);
            CheckMove(rightButton, ref deltaPosition, transform.right);
			CheckMove(leftButton, ref deltaPosition, -transform.right);
			CheckMove(upwardsButton, ref deltaPosition, transform.up);
			CheckMove(downwardsButton, ref deltaPosition, -transform.up);


            if (moving)
            {
				if(Input.GetKey(runKey))
				{
					speedMultiplierCurrent = 20;
				}else{
					speedMultiplierCurrent = speedMultiplier;
				}

                if (moving != lastMoving)
					currentSpeed = initialSpeed;

				transform.position += deltaPosition * currentSpeed * Time.deltaTime * speedMultiplierCurrent;
            }
            else currentSpeed = 0f;            
        }

        if (allowRotation)
        {
            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles.x += -Input.GetAxis("Mouse Y") * 359f * cursorSensitivity;
            eulerAngles.y += Input.GetAxis("Mouse X") * 359f * cursorSensitivity;
            transform.eulerAngles = eulerAngles;
        }

        if (cursorToggleAllowed)
        {
            if (Input.GetKey(cursorToggleButton))
            {
                if (!togglePressed)
                {
                    togglePressed = true;
                    Screen.lockCursor = !Screen.lockCursor;
                    Cursor.visible = !Cursor.visible;
                }
            }
            else togglePressed = false;
        }
        else
        {
            togglePressed = false;
            Cursor.visible = false;
        }
    }

    private void CheckMove(KeyCode keyCode, ref Vector3 deltaPosition, Vector3 directionVector)
    {
        if (Input.GetKey(keyCode))
        {
            moving = true;
            deltaPosition += directionVector;
        }
    }
}
