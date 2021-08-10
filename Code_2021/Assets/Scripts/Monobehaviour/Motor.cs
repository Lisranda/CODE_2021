using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent (typeof (Player))]
public class Motor : MonoBehaviour {
    Player player;

    readonly float rotationSpeed = 7f;
    readonly float walkSpeed = 3f;
    readonly float runSpeed = 7f;
    readonly float sprintSpeed = 10f;

    private void Awake () {
        player = GetComponent<Player> ();
    }

    private float GetGravity () {
        if (player.CharacterController.isGrounded) return -0.05f;
        else return -9.8f;
    }

    public void HandleRotation (Quaternion targetRotation) {
        transform.rotation = Quaternion.Slerp (transform.rotation , targetRotation , rotationSpeed * Time.deltaTime);
    }

    public void HandleLocomotion (Vector2 movementInput, State sendingState) {
        float speed;
        if (sendingState.GetType () == typeof (PCWalking)) speed = walkSpeed;
        else if (sendingState.GetType () == typeof (PCRunning)) speed = runSpeed;
        else if (sendingState.GetType () == typeof (PCSprinting)) speed = sprintSpeed;
        else { Debug.Log ("This state doesn't have a speed set"); return; }

        Vector3 movementDirection = new Vector3 (movementInput.x , GetGravity () , movementInput.y);
        player.CharacterController.Move (transform.TransformDirection (movementDirection) * speed * Time.deltaTime);
    }
}
