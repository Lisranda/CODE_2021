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
    const float groundedGravity = -50f;
    const float accelGravity = -9.8f;
    float ySpeed;

    public bool ResetMovementVelocity = true;
    public bool ResetYVelocity = true;

    private void Awake () {
        player = GetComponent<Player> ();
    }

    private void LateUpdate () {
        HandleLocomotion ();
    }

    private void ProcessGravity () {
        if (player.CharacterController.isGrounded) {
            frameVelocity.y = groundedGravity;
        }  else {
            frameVelocity.y += (accelGravity * Time.deltaTime);
        }
    }

    public void SetVelocity (Vector3 movementVelocity , MoveType source) {
        if (source == MoveType.External) frameVelocity = movementVelocity;
        else if (source == MoveType.Internal) frameVelocity = player.transform.TransformDirection (movementVelocity);
    }

    public void AddVelocity (Vector3 movementVelocity , MoveType source) {
        if (source == MoveType.External) frameVelocity += movementVelocity;
        else if (source == MoveType.Internal) frameVelocity += player.transform.TransformDirection (movementVelocity);
    }

    private void HandleLocomotion () {
        ProcessGravity ();
        player.CharacterController.Move (frameVelocity * Time.deltaTime);
        if (ResetMovementVelocity) { frameVelocity.x = 0f; frameVelocity.z = 0f; }
        if (ResetYVelocity) frameVelocity.y = 0f;
    }

    public void HandleRotation (Quaternion targetRotation) {
        transform.rotation = Quaternion.Slerp (transform.rotation , targetRotation , player.Attributes.RotationSpeed.Value * Time.deltaTime);
    }
}
