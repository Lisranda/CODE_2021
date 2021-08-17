using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum MoveType {
    Internal,
    External
}

[RequireComponent (typeof (Player))]
public class Motor : MonoBehaviour {
    Player player;
    Vector3 frameVelocity;
    Vector3 lastFrameVelocity;
    const float groundedGravity = -50f;
    const float accelGravity = -9.8f;

    private bool resetMovementVolocity = true;
    private bool resetYVelocity = true;

    public float FrameVelocityY { get { return frameVelocity.y; } }

    private void Awake () {
        player = GetComponent<Player> ();
    }

    private void LateUpdate () {
        HandleLocomotion ();
    }

    private void ProcessGravity () {
        if (player.CharacterController.isGrounded && resetYVelocity) {
            frameVelocity.y = groundedGravity;
        }  else {
            frameVelocity.y += (accelGravity * Time.deltaTime);
        }
    }

    public void ResetMovementVelocity (bool setValue) {
        resetMovementVolocity = setValue;
        //if (setValue) { frameVelocity.x = 0f; frameVelocity.z = 0f; }
        frameVelocity.x = 0f; frameVelocity.z = 0f;
    }

    public void ResetYVelocity (bool setValue) {
        resetYVelocity = setValue;
        //if (setValue) frameVelocity.y = 0f;
        frameVelocity.y = 0f;
    }

    public void SetVelocity (Vector3 movementVelocity , MoveType source) {
        if (source == MoveType.External) frameVelocity = movementVelocity;
        else if (source == MoveType.Internal) frameVelocity = player.transform.TransformDirection (movementVelocity);
    }

    public void SetVelocityY (float yVelocity) {
        frameVelocity.y = yVelocity;
    }

    public void SetVelocityXZ (float xVelocity, float zVelocity) {
        frameVelocity.x = xVelocity;
        frameVelocity.z = zVelocity;
    }

    public void AddVelocity (Vector3 movementVelocity , MoveType source) {
        if (source == MoveType.External) frameVelocity += movementVelocity;
        else if (source == MoveType.Internal) frameVelocity += player.transform.TransformDirection (movementVelocity);
    }

    public void AddLastFrameMovementVelocity () {
        frameVelocity.x += lastFrameVelocity.x;
        frameVelocity.z += lastFrameVelocity.z;
    }

    public void AddLastFrameYVelocity () {
        frameVelocity.y += lastFrameVelocity.y;
    }

    private void HandleLocomotion () {
        ProcessGravity ();
        player.CharacterController.Move (frameVelocity * Time.deltaTime);

        lastFrameVelocity = frameVelocity;
        if (resetMovementVolocity) { frameVelocity.x = 0f; frameVelocity.z = 0f; }
        if (resetYVelocity) { frameVelocity.y = 0f; }
    }

    public void HandleRotation (Quaternion targetRotation) {
        transform.rotation = Quaternion.Slerp (transform.rotation , targetRotation , player.Attributes.RotationSpeed.Value * Time.deltaTime);
    }
}
