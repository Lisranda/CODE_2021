using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent (typeof (Player))]
[RequireComponent (typeof (CharacterController))]
public class Motor : MonoBehaviour {
    Player player;
    CharacterController characterController;

    readonly float rotationSpeed = 7f;
    readonly float walkSpeed = 3f;
    readonly float runSpeed = 7f;
    readonly float sprintSpeed = 10f;

    void Awake () {
        player = GetComponent<Player> ();
        characterController = GetComponent<CharacterController> ();
    }

    void Start () {
        InitializeCallbacks ();
    }

    void Update () {
    }

    void InitializeCallbacks () {
        player.StateWalking.RotationCallback += HandleRotation;
        player.StateWalking.LocomotionCallback += HandleLocomotion;

        player.StateRunning.RotationCallback += HandleRotation;
        player.StateRunning.LocomotionCallback += HandleLocomotion;

        player.StateSprinting.RotationCallback += HandleRotation;
        player.StateSprinting.LocomotionCallback += HandleLocomotion;
    }

    float GetGravity () {
        if (characterController.isGrounded) return -0.05f;
        else return -9.8f;
    }

    void HandleRotation (Quaternion targetRotation) {
        transform.rotation = Quaternion.Slerp (transform.rotation , targetRotation , rotationSpeed * Time.deltaTime);
    }

    void HandleLocomotion (PCGrounded.LocomotionContext context) {
        float speed;
        if (context.SendingState.GetType () == typeof (PCWalking)) speed = walkSpeed;
        else if (context.SendingState.GetType () == typeof (PCRunning)) speed = runSpeed;
        else if (context.SendingState.GetType () == typeof (PCSprinting)) speed = sprintSpeed;
        else { Debug.Log (""); return; }

        Vector3 movementDirection = new Vector3 (context.MovementInput.x , GetGravity () , context.MovementInput.y);
        characterController.Move (transform.TransformDirection (movementDirection) * speed * Time.deltaTime);
    }
}
