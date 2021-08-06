using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent (typeof (Player))]
[RequireComponent (typeof (CharacterController))]
public class Motor : MonoBehaviour {
    Player player;
    CharacterController characterController;

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
        player.StateGrounded.RotationCallback += HandleRotation;
        player.StateGrounded.LocomotionCallback += HandleLocomotion;
    }

    void HandleRotation (Quaternion targetRotation) {
        transform.rotation = Quaternion.Slerp (transform.rotation , targetRotation , 7f * Time.deltaTime);
    }

    void HandleLocomotion (PCGrounded.LocomotionContext context) {
        float speed = context.IsWalking ? walkSpeed : runSpeed;
        Vector3 movementDirection = new Vector3 (context.MovementInput.x , 0f , context.MovementInput.y);
        characterController.Move (transform.TransformDirection (movementDirection) * speed * Time.deltaTime);
    }
}
